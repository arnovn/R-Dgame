using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSprite : MonoBehaviour
{

    public GameObject user;
    public Sprite Steady;
    public Sprite JumpingStraight;
    public Sprite JumpingRight;
    public Sprite JumpingLeft;
    public Sprite SteadyLeft;
    public Sprite SteadyRight;


    private SpriteRenderer spr;
    private Rigidbody2D rigid;

    private float x_direction;
    private float y_direction;

    // Start is called before the first frame update
    void Start()
    {
        spr = user.GetComponent<SpriteRenderer>();
        rigid = user.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSprite();
    }

    private void ChangeSprite(){
      y_direction = rigid.velocity.y;
      x_direction = rigid.velocity.x;

      if(y_direction <= 1f){
        if(x_direction == 0){
          spr.sprite = Steady;
      }
      else if (x_direction < 0f){
          spr.sprite =  SteadyLeft;
      }
      else{
          spr.sprite = SteadyRight;

      }
      Debug.Log(spr.sprite.name);
      }
      else if(y_direction > 1f){
        if(x_direction == 0f){
          spr.sprite = JumpingStraight;
      }
      else if (x_direction < 0f){
          spr.sprite = JumpingLeft;
      }
      else{
          spr.sprite = JumpingRight;
      }
    }

  }
}
