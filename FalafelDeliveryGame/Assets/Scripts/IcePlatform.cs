using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlatform : MonoBehaviour
{
      public GameObject player;
      public GameObject IcePlatformPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            Debug.Log("Collision happended");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000f);
        }
    }
}
