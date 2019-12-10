using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;


//TODO : move mechanics need to be adapted so it feels natural.

public class JoystickController : MonoBehaviour
{

    public Rigidbody2D user1;
    public Rigidbody2D user2;
    private float moveInput;
    private float speed = 10f;
    private ReadArduino ra;
    private Death death;
    private shootController shootcon1;
    private shootController shootcon2;
    private Death death1;
    private Death death2;
    private string ActiveScene;

    // Start is called before the first frame update
    void Start()
    {
        ActiveScene = SceneManager.GetActiveScene().name;

        if (ActiveScene == "GameScene")
        {
            ra = user1.GetComponent<ReadArduino>();
            death1 = GameObject.Find("DdaCollider").GetComponent<Death>();
            shootcon1 = user1.GetComponent<shootController>();
        }
        else if (ActiveScene == "Splitscreen2")
        {
            //The shootcontrollers for both users
            shootcon1 = user1.GetComponent<shootController>();
            shootcon2 = user2.GetComponent<shootController>();
            //The readArduinon object
            ra = GameObject.Find("UserController").GetComponent<ReadArduino>();
            //Death collider for the players
            death1 = GameObject.Find("DdaCollider1").GetComponent<Death>();
            death2 = GameObject.Find("DdaCollider2").GetComponent<Death>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveUser1(ra.ValuesArduino()[0]);
        MoveUser2(ra.ValuesArduino()[1]);
    }

    public void AddForce()
    {
        //using the physics system
        user1.AddForce(Vector2.up * 600f);

    }

    //Horizontal movement for player 1 (with the analog values from the joystick)
    void MoveUser1(int Direction)
    {

        if (death1.getLifes() > 0)
        {
            if (Direction >= 134)
            {
                user1.velocity = new Vector2(-1 * speed * Direction / 250, user1.velocity.y);
                shootcon1.setDirection(-1);
            }
            else if (Direction <= 123)
            {
                user1.velocity = new Vector2(1 * speed * (255 - Direction * 2) / 250, user1.velocity.y);
                shootcon1.setDirection(-1);
            }
            else if (Direction > 125 && Direction < 135)
            {
                user1.velocity = new Vector2(0 * speed, user1.velocity.y);
            }

        }
    }
    

    //Horizontal movement for player 2 (with the analog values from the joystick)
    void MoveUser2(int Direction)
    {
        if(ActiveScene == "Splitscreen2") {
            if (death2.getLifes() > 0)
            {
                if (Direction >= 134)
                {
                    user2.velocity = new Vector2(-1 * speed * Direction / 250, user2.velocity.y);
                }
                else if (Direction <= 123)
                {
                    user2.velocity = new Vector2(1 * speed * (255 - Direction * 2) / 250, user2.velocity.y);
                }
                else if (Direction > 125 && Direction < 135)
                {
                    user2.velocity = new Vector2(0 * speed, user2.velocity.y);
                }
            }
        }
    }
}
