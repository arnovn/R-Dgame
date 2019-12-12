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

    private float xPos;
    private float xSpeed;
    private float yPos;
    private float bulletSpeed = 10;
    private List<GameObject> bullets;

    private int buttonValue;
    private static bool shootTimer;
    private static System.Timers.Timer aTimer;

    int direction = -1; //To right

    private int i = 0; //intiger to determine shootTimer

    void Start()
    {
        ra = Arduino.GetComponent<GetUserValues>();
        userrgb = user.GetComponent<Rigidbody2D>();
        bullets = new List<GameObject>();
        //ra = GameObject.Find("SingleUser").GetComponent<ReadArduino>();
    }

    // Update is called once per frame
    void Update()
    {

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
                if (b.transform.position.x > xPos + 20 || b.transform.position.x < xPos - 20)
                {
                    bullets.Remove(b);
                    Destroy(b);
                }
            }
        }
    }

    public void setDirection(int newDirection)
    {
        direction = newDirection;
    }

    private void Shoot()
    {
        checkPosition();
        if (direction == -1)
        {
            bulletSpeed = -10;
        }
        else if (direction == 1)
        {
            bulletSpeed = 10;
        }
        else
        {
            bulletSpeed = 10;
        }

        bullet = Instantiate(bulletPrefab, new Vector2(xPos, yPos), Quaternion.identity);
        bulletrgb = bullet.GetComponent<Rigidbody2D>();
        bulletrgb.velocity = new Vector2(bulletSpeed, 0);
        bullets.Add(bullet);
    }

    private void checkPosition()
    {
        xPos = user.gameObject.transform.position.x;
        yPos = user.gameObject.transform.position.y;
    }
}
