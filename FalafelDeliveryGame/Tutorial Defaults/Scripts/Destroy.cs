using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab;
    public GameObject bigBouncePlatformPrefab;
    private GameObject myPlat;
    private float range = 3f;
    private float extra = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Platform"))
        {
            if (Random.Range(1, 7) == 1)
            {
                Destroy(collision.gameObject);
                Instantiate(bigBouncePlatformPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + range + Random.Range(extra - 0.5f, extra)), Quaternion.identity);
            }
            else
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + range + Random.Range(extra-0.5f, extra));
            }
        }
        else if (collision.gameObject.name.StartsWith("BigJump"))
        {
            if (Random.Range(1, 7) == 1)
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + range + Random.Range(extra-0.5f, extra));

                
            }
            else
            {
                Destroy(collision.gameObject);
                Instantiate(platformPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + range  + Random.Range(extra-0.5f, extra)), Quaternion.identity);
            }
        }
    }
}

/*
private void OnTriggerEnter2D(Collider2D collision)
{
    if (Random.Range(1, 6) > 1)
    {
        myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + 10 + Random.Range(0.5f, 1f)), Quaternion.identity);
    }
    else
    {
        myPlat = (GameObject)Instantiate(bigBouncePlatformPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + 10 + Random.Range(0.5f, 1f)), Quaternion.identity);
    }
    Destroy(collision.gameObject);
}
*/