using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManagerSpecial : MonoBehaviour
{
    private Button[] Menu;
    public ReadArduino ra;
    private int ButtonCount = 0;
    private int SlowButtonRead = 0;
    private bool ZeroGone = false;

    private void Awake()
    {
        //Initialise array of buttons per menu
        Menu = new Button[this.GetComponentsInChildren<Button>().Length];
        Menu = this.GetComponentsInChildren<Button>();
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
        if (ZeroGone)
        {
            if (SlowButtonRead > 17)
            {
                ButtonManager();

                if (ra.ValuesArduino()[4] == 1 || ra.ValuesArduino()[5] == 1)
                {
                    FindObjectOfType<AudioManager>().Play("Button");
                    Menu[ButtonCount].onClick.Invoke();
                    SlowButtonRead = 0;
                }
            }
            else { SlowButtonRead++; }
            Menu[ButtonCount].Select();
        }

        if (!ZeroGone && ra.ValuesArduino()[8] != 0) { ZeroGone = true; }
    }

    void ButtonManager()
    {
        if(ButtonCount == 0 || ButtonCount == 1 || ButtonCount == 2)
        {
            if (ra.ValuesArduino()[0] <= 60  || ra.ValuesArduino()[1] <= 60)
            {
                MoveRight();
            }
            if(ra.ValuesArduino()[0] >= 200 || ra.ValuesArduino()[1] >= 200)
            {
                MoveLeft();
            }
            if(ra.ValuesArduino()[8] <= 60 || ra.ValuesArduino()[9] <= 60)
            {
                ButtonCount = 3;
                SlowButtonRead = 0;
            }
            if(ra.ValuesArduino()[8] >= 200 || ra.ValuesArduino()[9] >= 200)
            {
                ButtonCount = 4;
                SlowButtonRead = 0;
            }
        }
        else
        {
            if (ra.ValuesArduino()[8] <= 60 || ra.ValuesArduino()[9] <= 60)
            {
                MoveDown();
            }
            if (ra.ValuesArduino()[8] >= 200 || ra.ValuesArduino()[9] >= 200)
            {
                MoveUp();
            }
        }
    }

    void MoveRight()
    {
        ButtonCount++;
        if (ButtonCount > 2)
        {
            ButtonCount = 0;
        }
        SlowButtonRead = 0;
    }

    void MoveLeft()
    {
        ButtonCount--;
        if (ButtonCount < 0)
        {
            ButtonCount = 2;
        }
        SlowButtonRead = 0;
    }

    void MoveUp()
    {
        ButtonCount--;
        if(ButtonCount == 2)
        {
            ButtonCount = 1;
        }
        SlowButtonRead = 0;
    }

    void MoveDown()
    {
        ButtonCount++;
        if (ButtonCount == Menu.Length)
        {
            ButtonCount = 1;
        }
        SlowButtonRead = 0;
    }

}
