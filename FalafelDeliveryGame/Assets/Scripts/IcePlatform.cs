using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlatform : MonoBehaviour
{
      private Rigidbody2D rb2d;
      private float speed = 10f;
      private bool right;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GameObject.Find("SingleUser").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.x <= 0){
          right = false;
        }else{
          right = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (right){
          rb2d.AddForce(Vector2.left * 6000f);
        }
        else{
          rb2d.AddForce(Vector2.right * 6000f);
        }
    }

}
