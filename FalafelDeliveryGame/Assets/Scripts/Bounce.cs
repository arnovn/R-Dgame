using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
  ReadArduino ra;
  TileGenerator tg;
  Death death;
  Rigidbody2D rigid;
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
      rigid = GameObject.Find("SingleUser").GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Arduino value is " + gav.getValue());
        if (Input.GetKeyDown("space"))
        {
            rigid.AddForce(Vector2.up * 60f);
        }

    }

    float PositionPlatform(){
      return y_pos;
    }

    private void OnCollisionEnter2D(Collision2D collision){

    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        buttonValue = ra.ValuesArduino()[2];
        /*
        if (Input.GetKeyDown("space"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 600f);
        }*/

        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y == 0){
        y_pos = collision.transform.position.y;
        x_pos = platform.transform.position.x;
        //death.lastPlatformPosition( x_pos,  y_pos);
        //tg.LastPlatformPosition(y_pos);
        if((buttonValue == 3 ||buttonValue == 4) && death.getLifes()> 0){
          collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*600f);
          FindObjectOfType<AudioManager>().Play("NormalJump");
        }
        }
      }
  }
