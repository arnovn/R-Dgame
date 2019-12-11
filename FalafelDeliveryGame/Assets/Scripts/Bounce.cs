using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
  ReadArduino ra;
  TileGenerator tg;
  Death death;
  public Rigidbody2D user;
  private int buttonValue;
  private float y_pos;
  private float x_pos;
  public GameObject platform;
  public GameObject startPoint;

    private bool ZeroGone = false;
    // Start is called before the first frame update
    void Start()
    {
     
      ra = GameObject.Find("UserController").GetComponent<ReadArduino>();
      tg = GameObject.Find("PfDestroyer1").GetComponent<TileGenerator>();
      death = GameObject.Find("DdaCollider1").GetComponent<Death>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Arduino value is " + gav.getValue());
    }

    /*
    float PositionPlatform(){
      return y_pos;
    }
    */

    private void OnCollisionEnter2D(Collision2D collision){

    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        while (!ZeroGone)
        {
            if (ra.ValuesArduino()[2] != 0)
            {
                ZeroGone = true;
                Debug.Log("Zero is gone");
            }
        }

        if (ZeroGone)
        {
            if (user.gameObject.name == "User1")
            {
                buttonValue = ra.ValuesArduino()[2];

            }
            if (user.gameObject.name == "User2")
            {
                buttonValue = ra.ValuesArduino()[3];
                //Debug.Log(buttonValue);    
            }

            if (collision.gameObject.name.StartsWith("Platform")||collision.gameObject.name.StartsWith("startpoint"))
            {
                y_pos = user.transform.position.y;
                x_pos = collision.transform.position.x;
                //death.lastPlatformPosition( x_pos,  y_pos);
                //tg.LastPlatformPosition(y_pos);
                if ((buttonValue == 3||buttonValue ==4) && death.getLifes() > 0)
                {
                    user.AddForce(Vector2.up * 150f);
                    Debug.Log("jump");

                }
            }
        }
    }

  }
