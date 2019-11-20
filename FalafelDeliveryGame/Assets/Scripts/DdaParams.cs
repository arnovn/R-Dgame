using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DdaParams : MonoBehaviour
{
    //Connection & variables of player
    public GameObject player;
    private Rigidbody2D body;
    private float x_pos;
    private float y_pos;

    //Platform object for comparison
    private GameObject platform;

    //Definition of different parameters
    private int stationary_hops = 0;
    private int jumpstreak = 0;
    private int amount_of_jumpstreaks = 0;

    // Start is called before the first frame update
    void Start()
    {
        //body = player.GetComponent<Rigidbody2D>();
        x_pos = player.transform.position.x;
        y_pos = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void checkStationary(Collider2D collision)
    {
        
        if (collision.gameObject.name.StartsWith("Platform") || collision.gameObject.name.StartsWith("Bigjump"))
        {
            if (body.velocity.y < 0)
            {

                if (collision.gameObject == platform)
                {
                    stationary_hops++;
                    jumpstreak = 0;
                    Debug.Log("Stationary hops: " + stationary_hops);
                    Debug.Log("Jumpstreak: " + jumpstreak);
                }
                else
                {
                    stationary_hops = 0;
                    jumpstreak++;
                    platform = collision.gameObject;
                    Debug.Log("Stationary hops: " + stationary_hops);
                    Debug.Log("Jumpstreak: " + jumpstreak);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        body = player.GetComponent<Rigidbody2D>();
        checkStationary(collision);
        if (jumpstreak == 2)
        {
            amount_of_jumpstreaks++;
        }
    }
}
