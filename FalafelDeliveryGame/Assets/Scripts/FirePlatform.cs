﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlatform : MonoBehaviour
{
    public GameObject Arduino;
    public GameObject DdaCollider;
    public GameObject User;
    private int buttonValue;
    public float timeStart;
    public float timeLeft;
    bool lostLife = false;
    float testTime = 0f;

    private SUserInterface SUI;
    private ReadArduino ra;
    private Death death;

    public Color StartColor;
    public Color EndColor;

    // Start is called before the first frame update
    void Start()
    {

        ra = Arduino.GetComponent<ReadArduino>();
        death = DdaCollider.GetComponent<Death>();
        SUI =DdaCollider.GetComponent<SUserInterface>();

    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("Arduino value is " + gav.getValue());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        buttonValue = ra.ValuesArduino()[2];
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            testTime += Time.deltaTime;
            if (buttonValue == 2 && death.getLifes() > 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 600f);

            }
            if (lostLife == false)
            {
                User.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.grey, Color.red, testTime / 3f);
            }

            if (testTime >=3f && lostLife== false)
            {
                User.GetComponent<SpriteRenderer>().color = Color.black;
                death.LoseLife();
                int lifes = death.getLifes();
                SUI.DeleteOneLife(lifes);
                lostLife = true;
                Debug.Log(lifes);

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
