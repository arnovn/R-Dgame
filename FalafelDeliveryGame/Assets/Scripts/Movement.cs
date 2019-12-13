using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public GameObject user;

    private JoystickController joystick;
    private Bounce bounce;
    private Rigidbody2D rigid;

    private float tileSpeed;
    private float joystickSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rigid = user.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      Move(tileSpeed + joystickSpeed);
    }

    public void JoystickMove(float speed){
      joystickSpeed = speed;
    }
    public void TileMovement(float speed){
      tileSpeed = speed;
    }

    public void Move(float speed){
      rigid.velocity = new Vector2(speed, rigid.velocity.y);
    }

    public void Jump(float speed){
      rigid.velocity = new Vector2(rigid.velocity.x, 30f);
    }
}
