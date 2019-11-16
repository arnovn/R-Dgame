using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSDestroy : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab;
    public GameObject bigBouncePlatformPrefab;
    private GameObject myPlat;
    private float range = 9f;
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
        Debug.Log("Should be triggered1");
        if (collision.gameObject.name.StartsWith("Platform"))
        {
            Debug.Log("Should be triggered2");
            if (Random.Range(1, 7) == 1)
            {
                Debug.Log("Should be triggered3");
                Destroy(collision.gameObject);
                Instantiate(bigBouncePlatformPrefab, new Vector2(player.transform.position.x + Random.Range(-5.5f, 5.5f), player.transform.position.y + range + Random.Range(extra - 0.5f, extra)), Quaternion.identity);
            }
            else
            {
                Debug.Log("Should be triggered4");
                collision.gameObject.transform.position = new Vector2(player.transform.position.x + Random.Range(-5.5f, 5.5f), player.transform.position.y + range + Random.Range(extra - 0.5f, extra));
            }
        }
        else if (collision.gameObject.name.StartsWith("BigJump"))
        {
            Debug.Log("Should be triggered5");
            if (Random.Range(1, 7) == 1)
            {
                Debug.Log("Should be triggered6");
                collision.gameObject.transform.position = new Vector2(player.transform.position.x + Random.Range(-5.5f, 5.5f), player.transform.position.y + range + Random.Range(extra - 0.5f, extra));


            }
            else
            {
                Debug.Log("Should be triggered7");
                Destroy(collision.gameObject);
                Instantiate(platformPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + range + Random.Range(extra - 0.5f, extra)), Quaternion.identity);
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
