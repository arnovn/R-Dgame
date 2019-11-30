using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SUserInterface : MonoBehaviour
{

    //The lives:
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public GameObject life4;
    public GameObject life5;
    private int id;
    private int lifes;

    // Start is called before the first frame update
    void Start()
    {
      lifes = 5;
    }



// Update is called once per frame
void Update()
    {

    }

public void DeleteOneLife(int idLifes)
    {
        id = idLifes;
        id = 5-id;
        if (id == 6)
        {
            life5.active = true;
        }
        switch (id)
        {
            case 1:
                life1.active = false;
                break;
            case 2:
                life2.active = false;
                break;
            case 3:
                life3.active = false;
                break;
            case 4:
                life4.active = false;
                break;
            case 5:
                life5.active = false;
                break;

        }
        id = 0;
    }

 public void AddOneLife(int idLifes)
 {
   id = idLifes;
   id = 6-id;
    if (id == 6)
    {
    life5.active = true;
    }
    switch (id)
    {
        case 2:
            life1.active = true;
            break;
        case 3:
            life2.active = true;
            break;
        case 4:
            life3.active = true;
             break;
        case 5:
            life4.active = true;
            break;
        case 6:
            life5.active = true;
            break;
          }
     }
}
