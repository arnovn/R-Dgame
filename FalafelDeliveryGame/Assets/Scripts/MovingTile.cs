using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO : move mechanics need to be adapted so it feels natural.

public class MovingTile : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private float speed = 10f;
    public GameObject platform;
    private int direction = 1;
    private Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        rb2d.GetVector(position);
        if(rb2d.position.x   > 5.5f)
        {
            direction = -1;
        }
        if(rb2d.position.x < -5.5f)
        {
            direction = 1;
        }
        
        rb2d.velocity = new Vector2(50 * (direction) * speed / 250, rb2d.velocity.x);
    }
}