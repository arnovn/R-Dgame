using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLife : MonoBehaviour
{

    private SUserInterface SUI;
    private GetUserValues ra;
    private Death death;

    public GameObject DdaCollider;
    public GameObject Arduino;
    public GameObject User;

    private int lifes;
    private bool adding;
    private int ldr;
    // Start is called before the first frame update
    void Start()
    {
        lifes = 5;
        SUI = DdaCollider.GetComponent<SUserInterface>();
        ra = Arduino.GetComponent<GetUserValues>();
        death = DdaCollider.GetComponent<Death>();

    }

    // Update is called once per frame
    void Update()
    {
      
        ldr = ra.Values()[3];
        CheckLDR();
        //Debug.Log(ldr);
    }


    void CheckLDR(){
      if(ldr == 1){
            Debug.Log("YEEEEEEEEEET");
        if(!adding){
          lifes = death.getLifes();
          if(lifes <5){
            death.AddLife();
            Debug.Log("lifes : " + lifes);
            SUI.AddOneLife(lifes);
          }
          adding = true;

        }
      }else{
        adding = false;
      }
    }
}
