using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
  private ReadArduino ra;
  private TileGenerator tg;
  private Death death;

  public Rigidbody2D user;
  public GameObject Arduino;
  public GameObject PfDestroyer;
  public GameObject DdaCollider;

  private int buttonValue;
  private int prevButtonValue = 0;
  private float y_pos;
  private float x_pos;
  private bool ZeroGone = true;


    // Start is called before the first frame update
    void Start()
    {

      ra = Arduino.GetComponent<ReadArduino>();
      tg = PfDestroyer.GetComponent<TileGenerator>();
      death = DdaCollider.GetComponent<Death>();

    }

    // Update is called once per frame
    void Update()
    {
        while (!ZeroGone)
        {
            if (ra.ValuesArduino()[2] != 0)
            {
                ZeroGone = true;
            }
      }

    }

    private void OnCollisionEnter2D(Collision2D collision){

    }

    private void OnCollisionStay2D(Collision2D collision)
    {


            if (user.gameObject.name == "User1")
            {
                buttonValue = ra.ValuesArduino()[2];

            }
            if (user.gameObject.name == "User2")
            {
                buttonValue = ra.ValuesArduino()[3];
                //Debug.Log(buttonValue);
            }

            if (collision.gameObject.name.StartsWith("Platform"))
            {
                if (buttonValue == 2 && death.getLifes() > 0 && prevButtonValue != buttonValue)
                {
                    user.AddForce(Vector2.up * 600f);
                    Debug.Log(user.name);
                }
            }
            prevButtonValue = buttonValue;
    }

  }
