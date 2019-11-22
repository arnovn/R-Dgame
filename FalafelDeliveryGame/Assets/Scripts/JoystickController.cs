using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


//TODO : move mechanics need to be adapted so it feels natural.

public class JoystickController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private float moveInput;
    private float speed = 10f;

    SerialPort sp = new SerialPort("COM12", 9600);
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        sp.Open();
        sp.ReadTimeout = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                MoveObject(sp.ReadByte());
                
            }
            catch(System.Exception)
            {

            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddForce();
        }
    }

    public void AddForce()
    {
        //using the physics system
        rb2d.AddForce(Vector2.up * 600f);

    }

    void MoveObject(int Direction) {
        if (Direction == 1)
        {
            rb2d.velocity = new Vector2(-1 * speed, rb2d.velocity.y);
        }
        else if (Direction == 2)
        {
            rb2d.velocity = new Vector2(1 * speed, rb2d.velocity.y);
        }
        else if (Direction == 0)
        {
            rb2d.velocity = new Vector2(0 * speed, rb2d.velocity.y);
        }
    }

    void OnApplicationQuit()
    {
        if (sp != null)
            sp.Close();
    }
}
