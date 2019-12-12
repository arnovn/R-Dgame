using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;


//TODO : move mechanics need to be adapted so it feels natural.

public class JoystickController : MonoBehaviour
{
    public GameObject user;
    public GameObject DdaCollider;
    public GameObject Arduino;

    private GetUserValues ra;
    private Rigidbody2D rb2d;
    private shootController shootcon;
    private Death death;

    private float moveInput;
    private float speed = 10f;
    private string ActiveScene;
    bool ZeroGone = false;

    // Start is called before the first frame update
    void Start()
    {
            ZeroGone = false;
            rb2d = user.GetComponent<Rigidbody2D>();
            ra = Arduino.GetComponent<GetUserValues>();
            death = DdaCollider.GetComponent<Death>();
            shootcon = user.GetComponent<shootController>();


    }

    // Update is called once per frame
    void Update()
    {
          if (ra.Values()[1] != 0)
          {
              ZeroGone = true;
          }
          MoveUser(ra.Values()[0]);

    }
    //Horizontal movement for player 1 (with the analog values from the joystick)
    void MoveUser(int Direction)
    {
      if(ZeroGone){
        if (death.getLifes() > 0)
        {

            if (Direction >= 134)
            {
                rb2d.velocity = new Vector2(-1 * speed * Direction / 250, rb2d.velocity.y);
                shootcon.setDirection(-1);
                Debug.Log("left");
            }
            else if (Direction <= 120)
            {
                rb2d.velocity = new Vector2(1 * speed * (255 - Direction * 2) / 250, rb2d.velocity.y);
                shootcon.setDirection(1);
                Debug.Log("right");
            }
            else if (Direction > 120 && Direction < 135)
            {
                rb2d.velocity = new Vector2(0 * speed, rb2d.velocity.y);
            }

        }
    }
  }

}
