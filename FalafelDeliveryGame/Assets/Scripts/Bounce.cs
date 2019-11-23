using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    GetArduinoValue gav;
    // Start is called before the first frame update
    void Start()
    {
      gav = GameObject.Find("SingleUser").GetComponent<GetArduinoValue>();
      Debug.Log(gav.getValue());
    }

    // Update is called once per frame
    void Update()
    {
          //Debug.Log("Arduino value is " + gav.getValue());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
          //Debug.Log("Collision happended);
            if(gav.getValue() == 3){
              collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*600f);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
      Debug.Log("speed is " + collision.gameObject.GetComponent<Rigidbody2D>().velocity.y);
      Debug.Log("Arduino value is " + gav.getValue());
      if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y == 0){
        if(gav.getValue() == 3){
          Debug.Log("FLY YOU FOOLS");
          collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*600f);
        }
      }

    }
}
