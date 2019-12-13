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
    private Bounce bounce;
    private Movement movement;

    private float moveInput;
    private float speed = 10f;
    private string ActiveScene;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
            rb2d = user.GetComponent<Rigidbody2D>();
            ra = Arduino.GetComponent<GetUserValues>();
            death = DdaCollider.GetComponent<Death>();
            movement = user.GetComponent<Movement>();
            shootcon = user.GetComponent<shootController>();

    }

    // Update is called once per frame
    void Update()
    {
          MoveUser(ra.Values()[0]);
    }
    //Horizontal movement for player 1 (with the analog values from the joystick)
    void MoveUser(int Direction)
    {
            if (Direction >= 134)
            {
                direction = -1;
            }
            else if (Direction <= 120)
            {
                direction = 1;
            }
            else if (Direction > 120 && Direction < 135)
            {
                direction = 0;
            }
            movement.JoystickMove(direction*speed);
            shootcon.setDirection(direction);
  }

  public int getDirection(){
    return direction;
  }
}
