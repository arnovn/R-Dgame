using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class shootController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject user;
    private Rigidbody2D userrgb;
    public GameObject bulletPrefab;
    private GameObject bullet;
    private Rigidbody2D bulletrgb;
    private GameObject enemy;
    private float xPos;
    private float xSpeed;
    private float yPos;
    private float bulletSpeed = 10;
    private List<GameObject> bullets;
    public ReadArduino ra;
    private int buttonValue;
    private static bool shootTimer;
    private static System.Timers.Timer aTimer;

    int direction = -1; //To right

    void Start()
    {
        userrgb = user.GetComponent<Rigidbody2D>();
        bullets = new List<GameObject>();
        //ra = GameObject.Find("SingleUser").GetComponent<ReadArduino>();
        SetTimer();
    }

    // Update is called once per frame
    void Update()
    {

        checkPosition();
        buttonValue = ra.ValuesArduino()[2];

        //Debug.Log(buttonValue + " waarde van buttons");

        if (Input.GetKeyDown(KeyCode.S)||buttonValue == 4 || buttonValue == 2)
        {
            if (shootTimer)
            {
                Shoot();
                shootTimer = false;

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
                    Debug.Log("Na remove: " + bullets.Count);
                    Destroy(b);
                    Debug.Log("Bullet destroyed");
                }
            }
        }



    }

    public void setDirection(int newDirection)
    {
        direction = newDirection;
    }

    private static void SetTimer()
    {
        aTimer = new System.Timers.Timer(250);

        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        aTimer.Enabled = true;

    }

    static void OnTimedEvent(object source, ElapsedEventArgs e) {
    shootTimer = true;

    }




    private void Shoot()
    {
        checkPosition();
        Debug.Log(userrgb.velocity.x);
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
        Debug.Log("Lengte " + bullets.Count);





    }

    private void checkPosition()
    {
        xPos = user.gameObject.transform.position.x;
        yPos = user.gameObject.transform.position.y;
    }
}
