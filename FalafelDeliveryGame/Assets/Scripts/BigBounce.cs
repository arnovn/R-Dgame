using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBounce : MonoBehaviour
{

    float y_pos;
    float x_pos;
    public GameObject platform;

      private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    float PositionPlatform(){
      return y_pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2d = collision.gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
     //   Debug.Log("speed is " + collision.gameObject.GetComponent<Rigidbody2D>().velocity.y);
        if (rb2d.velocity.y == 0)
        {
            rb2d.velocity = new Vector2(0f, 50f);
        }

    }
}
