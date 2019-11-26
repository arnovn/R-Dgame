using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
  ReadArduino ra;
  private int buttonValue;
    // Start is called before the first frame update
    void Start()
    {
      ra = GameObject.Find("SingleUser").GetComponent<ReadArduino>();
    }

    // Update is called once per frame
    void Update()
    {
          //Debug.Log("Arduino value is " + gav.getValue());
    }



    private void OnCollisionStay2D(Collision2D collision)
    {

          buttonValue = ra.ValuesArduino()[1];

      
      if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y == 0){
        if(buttonValue == 2){
          collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*600f);

        }
        }
      }
  }
