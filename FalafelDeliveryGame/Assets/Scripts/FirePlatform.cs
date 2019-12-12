using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlatform : MonoBehaviour
{
    private SUserInterface SUI;
    private Death death;
    private ReadArduino ra;
    private GameObject User;
    private Rigidbody2D rb2d;

    private int buttonValue;
    public float timeStart;
    public float timeLeft;
    bool lostLife = false;
    float testTime = 0f;

    public Color StartColor;
    public Color EndColor;

    // Start is called before the first frame update
    void Start()
    {

        ra = GameObject.Find("UserController").GetComponent<ReadArduino>();
        death = GameObject.Find("DdaCollider1").GetComponent<Death>();
        SUI =GameObject.Find("DdaCollider1").GetComponent<SUserInterface>();

    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("Arduino value is " + gav.getValue());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        User = GameObject.Find(collision.gameObject.name);
        rb2d = User.gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //User = GameObject.Find(collision.gameObject.name);
        //rb2d = User.gameObject.GetComponent<Rigidbody2D>();

        if (collision.gameObject.name.StartsWith("User2"))
        {
            death = GameObject.Find("DdaCollider2").GetComponent<Death>();
            SUI = GameObject.Find("DdaCollider2").GetComponent<SUserInterface>();
        }
        else
        {
            death = GameObject.Find("DdaCollider1").GetComponent<Death>();
            SUI = GameObject.Find("DdaCollider1").GetComponent<SUserInterface>();
        }

        buttonValue = ra.ValuesArduino()[2];
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            testTime += Time.deltaTime;
            if (buttonValue == 2 && death.getLifes() > 0 && rb2d.velocity.y <= 0)
            {

                rb2d.velocity = new Vector2(rb2d.velocity.x, 30f);

            }
            if (lostLife == false)
            {
                User.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.grey, Color.red, testTime / 0.7f);
            }

            if (testTime >=0.7f && lostLife== false)
            {
                User.GetComponent<SpriteRenderer>().color = Color.black;
                //death.LoseLife();
                int lifes = death.getLifes();
                //SUI.DeleteOneLife(lifes);
                lostLife = true;
                Debug.Log(lifes);
                death.Died();

                //User.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        User.GetComponent<SpriteRenderer>().color = Color.white;
        testTime = 0;
        lostLife = false;
    }
}
