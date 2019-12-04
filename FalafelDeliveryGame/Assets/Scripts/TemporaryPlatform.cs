using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryPlatform : MonoBehaviour
{
    ReadArduino ra;
    TileGenerator tg;
    Death death;
    private int buttonValue;
    private float y_pos;
    private float x_pos;
    public GameObject platform;
    public GameObject startPoint;
    public float timeStart = 2;
    public float timeLeft = 2;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        ra = GameObject.Find("SingleUser").GetComponent<ReadArduino>();
        tg = GameObject.Find("PfDestroyer").GetComponent<TileGenerator>();
        death = GameObject.Find("DdaCollider").GetComponent<Death>();
        rb2d = GameObject.Find("SingleUser").GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft < 2)
        {
            timeLeft -= Time.deltaTime;
        }
        
        //Debug.Log("Arduino value is " + gav.getValue());
    }

    float PositionPlatform()
    {
        return y_pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timeLeft = timeStart - Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        buttonValue = ra.ValuesArduino()[2];
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            y_pos = collision.transform.position.y;
            x_pos = platform.transform.position.x;
            //death.lastPlatformPosition( x_pos,  y_pos);
            //tg.LastPlatformPosition(y_pos);
            if (buttonValue == 2 && death.getLifes() > 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 600f);

            }
            if (timeLeft == 0)
            {
                int random = Random.Range(1, 2);
                if (random == 1)
                {
                    rb2d.AddForce(Vector2.right * 6000f);
                }
                else
                {
                    rb2d.AddForce(Vector2.left * 6000f);
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        timeLeft = 2;
    }
}
