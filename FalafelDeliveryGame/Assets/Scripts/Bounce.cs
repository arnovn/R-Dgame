﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
  //private ReadArduino ra;
  private TileGenerator tg;
  private Death death;

  public Rigidbody2D user;
  public GameObject Arduino;
  public GameObject PfDestroyer;
  public GameObject DdaCollider;

  private GetUserValues ra;
  private int buttonValue;
  private int prevButtonValue = 0;
  private float y_pos;
  private float x_pos;
  private bool ZeroGone = true;


    // Start is called before the first frame update
    void Start()
    {

      ra = Arduino.GetComponent<GetUserValues>();
      tg = PfDestroyer.GetComponent<TileGenerator>();
      death = DdaCollider.GetComponent<Death>();

    }
    
    // Update is called once per frame
    void Update()
    {
        /*
        while (!ZeroGone)
        {
            if (ra.Values()[0] != 0)
            {
                ZeroGone = true;
            }
      }*/

    }

    private void OnCollisionEnter2D(Collision2D collision){

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        buttonValue = ra.Values()[1];

        if (collision.gameObject.name.StartsWith("Platform") || collision.gameObject.name.StartsWith("startpoint"))
        {
            if (buttonValue == 2 && death.getLifes() > 0 && prevButtonValue != buttonValue && user.velocity.y <= 0f)
            {
                user.velocity = new Vector2(user.velocity.x, 30f);
                FindObjectOfType<AudioManager>().Play("NormalJump");
                Debug.Log(user.name);
            }
        }
        prevButtonValue = buttonValue;
    }

  }
