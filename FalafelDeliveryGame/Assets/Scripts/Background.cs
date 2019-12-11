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



    // Start is called before the first frame update
    void Start()
    {
        userrb2d = user.GetComponent<Rigidbody2D>();
        backgroundrb2d = background.GetComponent<Rigidbody2D>();
        skyscraper1rb2d = skyscraper1.GetComponent<Rigidbody2D>();
        skyscraper2rb2d = skyscraper2.GetComponent<Rigidbody2D>();
        skyscraper3rb2d = skyscraper3.GetComponent<Rigidbody2D>();
        skyscraper4rb2d = skyscraper4.GetComponent<Rigidbody2D>();

        backgroundrb2d.gravityScale = 0f;
        skyscraper1rb2d.gravityScale = 0f;
        skyscraper2rb2d.gravityScale = 0f;
        skyscraper3rb2d.gravityScale = 0f;
        skyscraper4rb2d.gravityScale = 0f;

    }

    // Update is called once per frame
    void Update()
    {
      Debug.Log(userrb2d.velocity.y);

        backgroundrb2d.velocity = new Vector2(0f, userrb2d.velocity.y*0.9f);
        skyscraper1rb2d.velocity = new Vector2(0f, userrb2d.velocity.y*0.7f);
        skyscraper2rb2d.velocity = new Vector2(0f, userrb2d.velocity.y*0.7f);
        skyscraper3rb2d.velocity = new Vector2(0f, userrb2d.velocity.y*0.7f);
        skyscraper4rb2d.velocity = new Vector2(0f, userrb2d.velocity.y*0.7f);
      }
}
