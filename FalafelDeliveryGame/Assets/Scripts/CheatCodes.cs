using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCodes : MonoBehaviour
{

    public GameObject Arduino;
    public GameObject user;

    private GetUserValues ra;
    private JoystickController joystick;
    private Bounce bounce;

    private int jump = 0;
    private int direction = 0;
    private int shoot = 0;
    private int cheatLevel= 0;

    // Start is called before the first frame update
    void Start()
    {
      ra = Arduino.GetComponent<GetUserValues>();
      joystick = user.GetComponent<JoystickController>();
      bounce = user.GetComponent<Bounce>();
    }

    // Update is called once per frame
    void Update()
    {
      jump = ra.Values()[1];
      direction = joystick.getDirection();
      shoot = ra.Values()[2];

      CheckCheat();
    }

    private void CheckCheat(){
      switch(cheatLevel){
        case 0:
        Debug.Log("jump : " + jump + " direction : " + direction + " shoot : " + shoot);

          if(jump == 2 && direction == 0 && shoot == 2){
            cheatLevel++;
          }
          Debug.Log(cheatLevel);
          break;

        case 1:
          if(jump == 2 && direction == 0 && shoot == 2){
            Debug.Log(cheatLevel);
            break;
          }else if (jump == 1 && direction  == 0 && shoot == 2){
            Debug.Log(cheatLevel);
            break;
          }else if (jump == 1 && direction == 0 && shoot == 1){
            cheatLevel++;
            Debug.Log(cheatLevel);
            break;
          }else{
            cheatLevel = 0;
          }
          break;
        case 2:
          if(jump == 1 && direction == 0 && shoot == 1){
            Debug.Log(cheatLevel);
            break;
          }else if (jump == 1 && direction  == 0 && shoot == 2){
            Debug.Log(cheatLevel);
            break;
          }else if (jump == 1 && direction == 1 && shoot == 2){
            cheatLevel++;
            Debug.Log(cheatLevel);
            break;
          }else{
            cheatLevel = 0;
          }
          Debug.Log(cheatLevel);
          break;
        case 3:
          if(jump == 1 && direction == 1 && shoot == 2){
            Debug.Log(cheatLevel);
            break;
          }else if (jump == 1 && direction  == 0 && shoot == 2){
            Debug.Log(cheatLevel);
            break;
          }else if (jump == 2 && direction == 0 && shoot == 2){
            cheatLevel++;
            Debug.Log(cheatLevel);
            break;
          }else{
            cheatLevel = 0;
          }
          Debug.Log(cheatLevel);
          break;
        case 4:
          if(jump == 2 && direction == 0 && shoot == 2){
            Debug.Log(cheatLevel);
            break;
          }else if (jump == 1 && direction  == 0 && shoot == 2){
            Debug.Log(cheatLevel);
            break;
          }else if (jump == 1 && direction == -1 && shoot == 2){
            cheatLevel++;
            Debug.Log(cheatLevel);
            break;
          }else{
            cheatLevel = 0;
          }
          Debug.Log(cheatLevel);
          break;
        case 5:
          if(jump == 1 && direction == -1 && shoot == 2){
            Debug.Log(cheatLevel);
            break;
          }else if (jump == 1 && direction  == 0 && shoot == 2){
            Debug.Log(cheatLevel);
            break;
          }else if (jump == 1 && direction == 0 && shoot == 1){
            cheatLevel++;
            Debug.Log(cheatLevel);
            break;
          }else{
            cheatLevel = 0;
          }
          Debug.Log(cheatLevel);
          break;
        case 6:
        if(jump == 1 && direction == 0 && shoot == 1){
          Debug.Log(cheatLevel);
          break;
        }else if (jump == 1 && direction  == 0 && shoot == 2){
          Debug.Log(cheatLevel);
          break;
        }else if (jump == 2 && direction == 0 && shoot == 2){
          cheatLevel++;
          Debug.Log(cheatLevel);
          break;
        }else{
          cheatLevel = 0;
        }
        Debug.Log(cheatLevel);
        break;
        case 7:
          bounce.jumpSpeed = 100f;
          cheatLevel = 0;
          break;
        default:
          cheatLevel = 0;
          break;
      }

    }
}
