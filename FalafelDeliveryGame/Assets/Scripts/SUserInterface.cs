using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SUserInterface : MonoBehaviour
{

    //The lives:
    private GameObject life1;
    private GameObject life2;
    private GameObject life3;
    private GameObject life4;
    private GameObject life5;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void ConnectLives()
    {
        life1 = GameObject.Find("Life1");
        life2 = GameObject.Find("Life2");
        life3 = GameObject.Find("Life3");
        life4 = GameObject.Find("Life4");
        life5 = GameObject.Find("Life5");
        Debug.Log(life1.name);
    }

// Update is called once per frame
void Update()
    {

    }


public void DeleteOneLife(int id)
    {
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
    }

 public void AddOneLife(int id)
 {
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
