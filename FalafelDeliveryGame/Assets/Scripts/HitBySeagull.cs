using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBySeagull : MonoBehaviour
{

    private Death death;
    private int lifes;
    public GameObject ddaCollider;
    private SUserInterface SUI;
    // Start is called before the first frame update
    void Start()
    {
        death = ddaCollider.GetComponent<Death>();
        SUI = ddaCollider.GetComponent<SUserInterface>();
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
            death.LoseLife();
            lifes = death.getLifes();
            SUI.DeleteOneLife(lifes);
          //  Debug.Log("You lost one life, lifes left: " + lifes);
        }
    }

}
