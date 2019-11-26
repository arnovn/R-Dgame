using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 600f);
            //Debug.Log("Collision happended);
        }
       
    }

        private void OnCollisionStay2D(Collision2D collision)
        {
          if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y == 0){
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 600f);
          }

        }
}