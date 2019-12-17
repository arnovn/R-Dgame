using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
  //private ReadArduino ra;

  public Rigidbody2D user;
  public GameObject Arduino;
  public GameObject PfDestroyer;
  public GameObject DdaCollider;

  private GetUserValues ra;
  private Death death;
  private Movement movement;

  private int buttonValue;
  private int prevButtonValue = 0;
  public float timeLeft;
  private bool lostLife = false;
  private float testTime = 0f;
  private float speed;
  private float jumpSpeed = 30f;
  private bool finished = false;

  // Start is called before the first frame update
  void Start()
  {

    ra = Arduino.GetComponent<GetUserValues>();
    death = DdaCollider.GetComponent<Death>();
    movement = user.GetComponent<Movement>();

  }

  // Update is called once per frame
  void Update()
  {
        if (Input.GetKeyDown(KeyCode.Space)) {

            movement.Jump(jumpSpeed);

        }
  }

  private void OnCollisionEnter2D(Collision2D collision){

  }

  private void OnCollisionStay2D(Collision2D collision)
  {
    buttonValue = ra.Values()[1];

    if (collision.gameObject.name.StartsWith("Platform"))
    {
      if (buttonValue == 2 && death.getLives() > 0 && prevButtonValue != buttonValue && user.velocity.y <= 0.1f)
      {
        //Debug.Log("ja derin");
        movement.Jump(jumpSpeed);
        FindObjectOfType<AudioManager>().Play("NormalJump");
      }

      if(collision.gameObject.name.Contains("Fire")){
        testTime += Time.deltaTime;
        if (lostLife == false){
          user.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.grey, Color.red, testTime / 0.7f);
          if (testTime >=0.7f && lostLife== false)
          {
            user.GetComponent<SpriteRenderer>().color = Color.black;
            int lives = death.getLives();
            lostLife = true;
            Debug.Log(lives);
            death.Died();
          }
        }
      }

      if(collision.gameObject.name.Contains("Moving")){
        if(user.velocity.y <=0.1f){
          speed = collision.gameObject.GetComponent<Rigidbody2D>().velocity.x;
          movement.TileMovement(speed);
        }
      }
            if (collision.gameObject.name.Contains("finish"))
            {
                finished = true;
            }

      prevButtonValue = buttonValue;
    }
  }

  private void OnCollisionExit2D(Collision2D collision){
    user.GetComponent<SpriteRenderer>().color = Color.white;
    testTime = 0;
    lostLife = false;
    if(collision.gameObject.name.Contains("Moving")){
      //speed = collision.gameObject.GetComponent<Rigidbody2D>().velocity.x;
      movement.TileMovement(0f);
    }
  }

    public bool getFinished()
    {
        return finished;
    }
}
