using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBounce : MonoBehaviour
{
    //TileGenerator tg;
    Death death;

    float y_pos;
    float x_pos;
    public GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        //tg = GameObject.Find("PfDestroyer").GetComponent<TileGenerator>();
        death = GameObject.Find("DdaCollider").GetComponent<Death>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    float PositionPlatform(){
      return y_pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            y_pos = collision.transform.position.y;
            x_pos = platform.transform.position.x;
            //death.lastPlatformPosition(x_pos,y_pos);
            //tg.LastPlatformPosition(y_pos);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000f);
        }
    }
}
