using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public GameObject user;
    public GameObject background;
    public GameObject skyscraper1;
    public GameObject skyscraper2;
    public GameObject skyscraper3;
    public GameObject skyscraper4;

    private Rigidbody2D userrb2d;
    private Rigidbody2D backgroundrb2d;
    private Rigidbody2D skyscraper1rb2d;
    private Rigidbody2D skyscraper2rb2d;
    private Rigidbody2D skyscraper3rb2d;
    private Rigidbody2D skyscraper4rb2d;

    private float y_user;
    private float y_background;
    private float y_skyscraper1;
    private float y_skyscraper2;
    private float y_skyscraper3;
    private float y_skyscraper4;

    private float x_background;
    private float x_skyscraper1;
    private float x_skyscraper2;
    private float x_skyscraper3;
    private float x_skyscraper4;

    private bool death;
    private float previous_y_user;

    // Start is called before the first frame update
    void Start()
    {
        backgroundrb2d = background.GetComponent<Rigidbody2D>();
        skyscraper1rb2d = skyscraper1.GetComponent<Rigidbody2D>();
        skyscraper2rb2d = skyscraper2.GetComponent<Rigidbody2D>();
        skyscraper3rb2d = skyscraper3.GetComponent<Rigidbody2D>();
        skyscraper4rb2d = skyscraper4.GetComponent<Rigidbody2D>();

        y_background = backgroundrb2d.position.y;
        y_skyscraper1 = skyscraper1rb2d.position.y;
        y_skyscraper2 = skyscraper2rb2d.position.y;
        y_skyscraper3 = skyscraper3rb2d.position.y;
        y_skyscraper4 = skyscraper4rb2d.position.y;

        x_background = backgroundrb2d.position.x;
        x_skyscraper1 = skyscraper1rb2d.position.x;
        x_skyscraper2 = skyscraper2rb2d.position.x;
        x_skyscraper3 = skyscraper3rb2d.position.x;
        x_skyscraper4 = skyscraper4rb2d.position.x;

        backgroundrb2d.gravityScale = 0f;
        skyscraper1rb2d.gravityScale = 0f;
        skyscraper2rb2d.gravityScale = 0f;
        skyscraper3rb2d.gravityScale = 0f;
        skyscraper4rb2d.gravityScale = 0f;

        death = false;
    }

    // Update is called once per frame
    void Update()
    {
        userrb2d = user.GetComponent<Rigidbody2D>();
        y_user = userrb2d.position.y;

        if(death){
          if(y_user - previous_y_user > 10f){
            backgroundrb2d.MovePosition(new Vector2(x_background, y_background + y_user)) ;
            skyscraper1rb2d.MovePosition(new Vector2(x_skyscraper1, y_skyscraper1 + y_user)) ;
            skyscraper2rb2d.MovePosition(new Vector2(x_skyscraper2, y_skyscraper2 + y_user)) ;
            skyscraper3rb2d.MovePosition(new Vector2(x_skyscraper3, y_skyscraper3 + y_user)) ;
            skyscraper4rb2d.MovePosition(new Vector2(x_skyscraper4, y_skyscraper4 + y_user)) ;
            death = false;
          }
        }
        else{
          backgroundrb2d.velocity = new Vector2(0f, userrb2d.velocity.y*0.8f);
          skyscraper1rb2d.velocity = new Vector2(0f, userrb2d.velocity.y*0.65f);
          skyscraper2rb2d.velocity = new Vector2(0f, userrb2d.velocity.y*0.65f);
          skyscraper3rb2d.velocity = new Vector2(0f, userrb2d.velocity.y*0.65f);
          skyscraper4rb2d.velocity = new Vector2(0f, userrb2d.velocity.y*0.65f);
        }
        previous_y_user = y_user;
    }

    public void UserDied(){
      death = true;

    }
    public void resetVelocity(){
      backgroundrb2d.velocity = new Vector2(0f, 0f);
      skyscraper1rb2d.velocity = new Vector2(0f, 0f);
      skyscraper2rb2d.velocity = new Vector2(0f, 0f);
      skyscraper3rb2d.velocity = new Vector2(0f, 0f);
      skyscraper4rb2d.velocity = new Vector2(0f, 0f);
    }    
}
