using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    private GameObject user;
    private Death death;


    // Start is called before the first frame update
    void Start()
    {
        user = gameObject;
        //Debug.Log("tis is: "+gameObject);
    }

    // Update is called once per frame
    void Update()
    {



    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name.Contains("enemy seagull"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.name.Contains("Dda")){
          Debug.Log("collided");
          death = collision.gameObject.GetComponent<Death>();
          death.Died();
        }
    }
}
