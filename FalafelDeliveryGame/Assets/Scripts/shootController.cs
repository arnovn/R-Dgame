using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        userrgb = user.GetComponent<Rigidbody2D>();
        bullets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        checkPosition();



        if (Input.GetKeyDown(KeyCode.S))
        {

            Shoot();



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

    private void Shoot()
    {

        bulletSpeed = 10;
        checkPosition();
        Debug.Log(userrgb.velocity.x);
        if (userrgb.velocity.x == 0)
        {
            xSpeed = xSpeed;
        }
        else
        {
            xSpeed = userrgb.velocity.x;
        }
        if (xSpeed < 0)
        {
            bulletSpeed = -bulletSpeed;

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