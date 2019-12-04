using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBySeagull : MonoBehaviour
{
   
    private Death death;
    private int lifes;
    // Start is called before the first frame update
    void Start()
    {
        death = GameObject.Find("DdaCollider").GetComponent<Death>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name.Contains("enemy seagull"))
        {
            death.LoseLife();
            death.getLifes();
            Debug.Log("You lost one life, lifes left: " + lifes);
        }
    }

}