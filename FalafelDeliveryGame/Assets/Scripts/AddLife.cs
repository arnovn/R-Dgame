using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLife : MonoBehaviour
{

    private SUserInterface SUI;
    public ReadArduino ra;
    private Death death;
    private int lifes;
    private bool adding;
    // Start is called before the first frame update
    void Start()
    {
        lifes = 5;
        SUI = GameObject.Find("DdaCollider").GetComponent<SUserInterface>();
        //ra = GameObject.Find("SingleUser").GetComponent<ReadArduino>();
        death = GameObject.Find("DdaCollider").GetComponent<Death>();

    }

    // Update is called once per frame
    void Update()
    {
      CheckLDR();
    }

    void CheckLDR(){
      if(ra.ValuesArduino()[4] == 1){
        if(!adding){
          lifes = death.getLifes();
          if(lifes <5){
            death.AddLife();
            Debug.Log(lifes);
            SUI.AddOneLife(lifes);
          }
          adding = true;

        }
      }else{
        adding = false;
      }
    }
}
