using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlatform : MonoBehaviour
{
    ReadArduino ra;
    TileGenerator tg;
    Death death;
    private int buttonValue;
    private float y_pos;
    private float x_pos;
    public GameObject platform;
    public float timeStart;
    public float timeLeft;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        ra = GameObject.Find("SingleUser").GetComponent<ReadArduino>();
        rb2d = GameObject.Find("SingleUser").GetComponent<Rigidbody2D>();
        death = GameObject.Find("DdaCollider").GetComponent<Death>();

    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft < 2)
        {
            timeLeft -= Time.deltaTime;
            Debug.Log(timeLeft);
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

            if (buttonValue == 2 && death.getLifes() > 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 600f);

            }
            if (timeLeft <= 0)
            {
                timeLeft = 1;
                int random = Random.Range(1, 3);
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
        timeLeft = 1;
    }
}
