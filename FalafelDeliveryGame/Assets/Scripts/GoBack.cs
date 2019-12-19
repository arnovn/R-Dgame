using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour
{
    public ChooseCharacter user1;
    public ChooseCharacter user2;

    public GameObject main;
    public GameObject options;

    // Update is called once per frame
    void Update()
    {
        if(user1.GetConfirmed() && user2.GetConfirmed())
        {
            main.SetActive(true);
            options.SetActive(false);
        }
    }
}
