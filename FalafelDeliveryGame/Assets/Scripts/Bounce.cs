using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
  ReadArduino ra;
  TileGenerator tg;
  Death death;
  private int buttonValue;
  private float y_pos;
  private float x_pos;
  public GameObject platform;
  public GameObject startPoint;
    // Start is called before the first frame update
    void Start()
    {
      ra = GameObject.Find("SingleUser").GetComponent<ReadArduino>();
      tg = GameObject.Find("PfDestroyer").GetComponent<TileGenerator>();
      death = GameObject.Find("DdaCollider").GetComponent<Death>();

    }

    // Update is called once per frame
    void Update()
    {
          //Debug.Log("Arduino value is " + gav.getValue());
    }

    float PositionPlatform(){
      return y_pos;
    }

    private void OnCollisionEnter2D(Collision2D collision){

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
          Debug.Log("stay");
          buttonValue = ra.ValuesArduino()[2];


      if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y == 0){
        y_pos = collision.transform.position.y;
        x_pos = platform.transform.position.x;
        //death.lastPlatformPosition( x_pos,  y_pos);
        //tg.LastPlatformPosition(y_pos);
        if(buttonValue == 2 && death.getLifes()> 0){
          collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*600f);

        }
        }
      }
  }
