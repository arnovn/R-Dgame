using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class SelectManager : MonoBehaviour
{
    private Button[] Menu;
    private ReadArduino ra;
    private int ButtonCount = 0;
    private int SlowButtonRead = 0;

    private void Awake()
    {
        //Initialise array of buttons per menu
        Menu = new Button[this.GetComponentsInChildren<Button>().Length];
        Menu = this.GetComponentsInChildren<Button>();

        ra = GameObject.Find("Canvas").GetComponent<ReadArduino>();
    }

    private void OnEnable()
    {
        Menu[0].Select(); 
        Menu[0].OnSelect(null);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SlowButtonRead);
        if (SlowButtonRead > 15)
        {
            if (ra.ValuesArduino()[2] == 2 || ra.ValuesArduino()[3] == 2)
            {
                ButtonCount++;
                if (ButtonCount == Menu.Length)
                {
                    ButtonCount = 0;
                }
                SlowButtonRead = 0;
            }

            if(ra.ValuesArduino()[4] == 1 || ra.ValuesArduino()[5] == 1)
            {
                Menu[ButtonCount].onClick.Invoke();
                SlowButtonRead = 0;
            }
        }
        else { SlowButtonRead++; }
        Menu[ButtonCount].Select();
    }
}
