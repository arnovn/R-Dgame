using System.Collections;
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
  public float timeLeft;
  bool lostLife = false;
  float testTime = 0f;


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
    }

    private void OnCollisionEnter2D(Collision2D collision){

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        buttonValue = ra.Values()[1];

        if (collision.gameObject.name.StartsWith("Platform"))
        {
            if (buttonValue == 2 && death.getLifes() > 0 && prevButtonValue != buttonValue && user.velocity.y <= 0.1f)
            {
                user.velocity = new Vector2(user.velocity.x, 30f);
                FindObjectOfType<AudioManager>().Play("NormalJump");
                Debug.Log(user.name);
            }

            if(collision.gameObject.name.Contains("Fire")){


              testTime += Time.deltaTime;

                if (lostLife == false){
                  user.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.grey, Color.red, testTime / 0.7f);

                }

                if (testTime >=0.7f && lostLife== false)
                {
                    user.GetComponent<SpriteRenderer>().color = Color.black;
                    int lifes = death.getLifes();
                    lostLife = true;
                    Debug.Log(lifes);
                    death.Died();
                  }

        }
        prevButtonValue = buttonValue;
    }
  }
    private void OnCollisionExit2D(Collision2D collision){
      user.GetComponent<SpriteRenderer>().color = Color.white;
      testTime = 0;
      lostLife = false;
    }

  }
