using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManagerDifficulty : MonoBehaviour
{
  private Button[] Menu;
  public ReadArduino ra;
  private int ButtonCount = 0;
  private int SlowButtonRead = 0;
  private bool ZeroGone = false;

  private void Awake(){

    Menu = new Button[this.GetComponentsInChildren<Button>().Length];
    Menu = this.GetComponentsInChildren<Button>();
  }
  // Start is called before the first frame update
  private void OnEnable()
  {
    Menu[0].Select();
    Menu[0].OnSelect(null);
  }

  // Update is called once per frame
  void Update()
  {
    if (ZeroGone)
    {
      if (SlowButtonRead > 17)
      {
        if (ra.ValuesArduino()[8] < 110 || ra.ValuesArduino()[9] < 110)
        {
          ButtonCount++;
          if (ButtonCount == Menu.Length)
          {
            ButtonCount = 0;
          }
          SlowButtonRead = 0;
        }

        if (ra.ValuesArduino()[8] > 150 || ra.ValuesArduino()[9] > 150)
        {
          ButtonCount--;
          if (ButtonCount < 0)
          {
            ButtonCount = Menu.Length - 1;
          }
          SlowButtonRead = 0;
        }

        if (ra.ValuesArduino()[4] == 1 || ra.ValuesArduino()[5] == 1)
        {
          Menu[ButtonCount].onClick.Invoke();
          SlowButtonRead = 0;
        }
      }
      else { SlowButtonRead++; }
      Menu[ButtonCount].Select();
    }

    if(!ZeroGone && ra.ValuesArduino()[8] != 0) { ZeroGone = true; }

  }

  public void Pressed(){
    PlayerPrefs.SetInt("Difficulty", ButtonCount);
    Debug.Log("Difficulty : " + PlayerPrefs.GetInt("Difficulty"));
    SlowButtonRead = 0;
    FindObjectOfType<AudioManager>().Play("Button");
    switch(ButtonCount){
      default:
      break;

      case 0:
      FindObjectOfType<AudioManager>().Play("Easy");
      break;

      case 1:
      FindObjectOfType<AudioManager>().Play("Medium");
      break;

      case 2:
      FindObjectOfType<AudioManager>().Play("Hard");
      break;

    }
  }
}
