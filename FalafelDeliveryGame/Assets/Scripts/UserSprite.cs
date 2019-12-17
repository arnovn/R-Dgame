using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSprite : MonoBehaviour
{

  public GameObject user;
  public GameObject Arduino;
  public string spriteString;
  public Sprite DefaultSteady;
  public Sprite DefaultJumpSteady;
  public Sprite DefaultJumpRight;
  public Sprite DefaultJumpLeft;
  public Sprite DefaultSteadyLeft;
  public Sprite DefaultSteadyRight;
  public Sprite DefaultJumpLeftShoot;
  public Sprite DefaultJumpRightShoot;
  public Sprite DefaultLeftShoot;
  public Sprite DefaultRightShoot;
  public Sprite SantaSteady;
  public Sprite SantaJumpSteady;
  public Sprite SantaJumpRight;
  public Sprite SantaJumpLeft;
  public Sprite SantaSteadyLeft;
  public Sprite SantaSteadyRight;
  public Sprite SantaJumpLeftShoot;
  public Sprite SantaJumpRightShoot;
  public Sprite SantaLeftShoot;
  public Sprite SantaRightShoot;
  public Sprite AstronautSteady;
  public Sprite AstronautJumpSteady;
  public Sprite AstronautLeft;
  public Sprite AstronautRight;
  public Sprite AstronautJumpLeft;
  public Sprite AstronautJumpRight;
  public Sprite Ninja;
  public Sprite Brakke;

  private SpriteRenderer spr;
  private Rigidbody2D rigid;
  private GetUserValues ra;
  private JoystickController joystick;

  private float x_direction;
  private float y_direction;
  private int shoot;
  private int direction = 1;

  // Start is called before the first frame update
  void Start()
  {
    spr = user.GetComponent<SpriteRenderer>();
    rigid = user.GetComponent<Rigidbody2D>();
    joystick = user.GetComponent<JoystickController>();
    ra = Arduino.GetComponent<GetUserValues>();

  }

  // Update is called once per frame
  void Update()
  {

    int sprite = PlayerPrefs.GetInt(spriteString);
    Debug.Log(sprite);
    shoot = ra.Values()[2];
    int joystickDirection = joystick.getDirection();
    if(joystickDirection != 0){
      direction = joystickDirection;
    }
    switch (sprite)
    {
        case 1:
            DefaultSprite();
            break;
        case 2:
            SantaSprite();
            break;
        case 3:
            AstronautSprite();
            break;
        case 4:
            NinjaSprite();
            break;
        case 5:
            BrakkeSprite();
            break;
        default:
            DefaultSprite();
            break;
    }
  }

  private void DefaultSprite(){
    y_direction = rigid.velocity.y;
    x_direction = rigid.velocity.x;

    if(y_direction <= 1f){
      if(x_direction == 0){
        if(shoot == 1){
          if(direction ==1){
            spr.sprite = DefaultRightShoot;
          }else{
            spr.sprite = DefaultLeftShoot;
          }
        }else{
          spr.sprite = DefaultSteady;
        }
      }
      else if (x_direction < 0f){
        if(shoot == 1){
          spr.sprite = DefaultLeftShoot;
        }else{
          spr.sprite =  DefaultSteadyLeft;
        }
      }
      else{
        if(shoot == 1){
          spr.sprite = DefaultRightShoot;
        }else{
          spr.sprite = DefaultSteadyRight;
        }
      }
    }
    else if(y_direction > 1f){
      if(x_direction == 0f){
        if(shoot == 1){
          if(direction ==1){
            spr.sprite = DefaultJumpRightShoot;
          }else{
            spr.sprite = DefaultJumpLeftShoot;
          }
        }else{
          spr.sprite = DefaultJumpSteady;
        }
      }
      else if (x_direction < 0f){
        if(shoot == 1){
          spr.sprite = DefaultJumpLeftShoot;
        }else{
          spr.sprite = DefaultJumpLeft;

        }
      }
      else{
        if(shoot == 1){
          spr.sprite = DefaultJumpRightShoot;
        }
        else{
          spr.sprite = DefaultJumpRight;
        }
      }
    }
  }

  private void SantaSprite(){
    y_direction = rigid.velocity.y;
    x_direction = rigid.velocity.x;

    if(y_direction <= 1f){
      if(x_direction == 0){
        if(shoot == 1){
          if(direction ==1){
            spr.sprite = SantaRightShoot;
          }else{
            spr.sprite = SantaLeftShoot;
          }
        }else{
          spr.sprite = SantaSteady;
        }
      }
      else if (x_direction < 0f){
        if(shoot == 1){
          spr.sprite = SantaLeftShoot;
        }else{
          spr.sprite =  SantaSteadyLeft;
        }
      }
      else{
        if(shoot == 1){
          spr.sprite = SantaRightShoot;
        }else{
          spr.sprite = SantaSteadyRight;
        }
      }
    }
    else if(y_direction > 1f){
      if(x_direction == 0f){
        if(shoot == 1){
          if(direction ==1){
            spr.sprite = SantaJumpRightShoot;
          }else{
            spr.sprite = SantaJumpLeftShoot;
          }
        }else{
          spr.sprite = SantaJumpSteady;
        }
      }
      else if (x_direction < 0f){
        if(shoot == 1){
          spr.sprite = SantaJumpLeftShoot;
        }else{
          spr.sprite = SantaJumpLeft;

        }
      }
      else{
        if(shoot == 1){
          spr.sprite = SantaJumpRightShoot;
        }
        else{
          spr.sprite = SantaJumpRight;
        }
      }
    }
  }

  private void AstronautSprite(){
    y_direction = rigid.velocity.y;
    x_direction = rigid.velocity.x;

    if(y_direction <= 1f){
        if(x_direction == 0){
          spr.sprite = AstronautSteady;
      }
      else if (x_direction < 0f){
          spr.sprite =  AstronautLeft;
      }
      else{
          spr.sprite = AstronautRight;

      }
      }
      else if(y_direction > 1f){
        if(x_direction == 0f){
          spr.sprite = AstronautJumpSteady;
      }
      else if (x_direction < 0f){
          spr.sprite = AstronautJumpLeft;
      }
      else{
          spr.sprite = AstronautJumpRight;
      }
    }

  }


  private void NinjaSprite(){
    y_direction = rigid.velocity.y;
    x_direction = rigid.velocity.x;
    spr.sprite = Ninja;
  }

  private void BrakkeSprite(){
    y_direction = rigid.velocity.y;
    x_direction = rigid.velocity.x;
    spr.sprite = Brakke;
  }
}
