using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class shootController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject user;
    public GameObject bulletPrefab;
    public GameObject Arduino;

    private GetUserValues ra;
    private Rigidbody2D userrgb;
    private GameObject bullet;
    private Rigidbody2D bulletrgb;
    private GameObject enemy;
    private JoystickController joystick;

    private float xPos;
    private float xSpeed;
    private float yPos;
    private float bulletSpeed = 100f;
    private List<GameObject> bullets;

    private int buttonValue;
    private static bool shootTimer;
    private static System.Timers.Timer aTimer;

    private int direction = -1; //To right

    private int i = 0; //intiger to determine shootTimer

    void Start()
    {
        ra = Arduino.GetComponent<GetUserValues>();
        userrgb = user.GetComponent<Rigidbody2D>();
        joystick = user.GetComponent<JoystickController>();
        bullets = new List<GameObject>();

        //ra = GameObject.Find("SingleUser").GetComponent<ReadArduino>();
    }

    // Update is called once per frame
    void Update()
    {
        int joystickDirection = joystick.getDirection();
        if(joystickDirection != 0){
          direction = joystickDirection;
        }
        checkPosition();
        buttonValue = ra.Values()[2];
        if (buttonValue == 1)
        {
            if (shootTimer)
            {
                Shoot();
                shootTimer = false;

            }
        }

        if (!shootTimer)
        {
            if(i >= 15)
                {
                    shootTimer = true;
                    i = 0;
                }
            else
            {
                i++;
            }
        }
        for (int i = bullets.Count - 1; i >= 0; i--)
        {
            GameObject b = bullets[i];
            if (b != null)
            {
                if (b.transform.position.x > xPos + 550 || b.transform.position.x < xPos - 550)
                {
                    bullets.Remove(b);
                    Destroy(b);
                }
            }
        }
    }

    private void Shoot()
    {
        checkPosition();
        bullet = Instantiate(bulletPrefab, new Vector2(xPos+2f*direction, yPos), Quaternion.identity);
        bulletrgb = bullet.GetComponent<Rigidbody2D>();
        bulletrgb.velocity = new Vector2(bulletSpeed*direction, 0);
        bullets.Add(bullet);
        FindObjectOfType<AudioManager>().Play("Bullet");

    }

    private void checkPosition()
    {
        xPos = user.gameObject.transform.position.x;
        yPos = user.gameObject.transform.position.y;
    }
}
