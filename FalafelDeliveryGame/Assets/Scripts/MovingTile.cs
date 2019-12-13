using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO : move mechanics need to be adapted so it feels natural.

public class MovingTile : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private Vector2 position;

    public GameObject platform;
    public float speed;

    private int direction = 1;
    private bool user1;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        if(rb2d.position.x > 250f){
            user1 = false;
        }
        else{
            user1 = true;
        }

    }
    // Update is called once per frame
    void Update()
    {
      if(user1){
        rb2d.GetVector(position);
        if(rb2d.position.x   > 5.5f)
        {
            direction = -1;
        }
        if(rb2d.position.x < -5.5f)
        {
            direction = 1;
        }


      }
      else{
        rb2d.GetVector(position);
        if(rb2d.position.x   > 505.5f)
        {
            direction = -1;
        }
        if(rb2d.position.x < 494.5f)
        {
            direction = 1;
        }
      }
      rb2d.velocity = new Vector2(50 * (direction) * speed / 250, rb2d.velocity.x);

    }

    public void setSpeed(float newSpeed){
      speed = newSpeed;
    }
}
