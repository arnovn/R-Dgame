
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float moveInput;
    private float speed =10f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Moving to the left: guy should be facing to the left
        if (moveInput < 0)
        {

        }
        else if (moveInput > 0)
        {
            //Should be faing right
        }
        else
        {
            //Looking at you
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddForce();
        }
    }

    void FixedUpdate()
    {
        movement();
    }

    public void AddForce()
    {
        //using the physics system
        rb2d.AddForce(Vector2.up * 600f);

    }
    public void movement()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
    }
}


