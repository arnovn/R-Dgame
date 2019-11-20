using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab;
    public GameObject bigBouncePlatformPrefab;
    private GameObject myPlat;
    private float range = 9f;
    private float extra = 1f;
    private float generation_axis;

    // Start is called before the first frame update
    void Start()
    {
        if (player.name == "User1")
        {
            generation_axis = 0f;
        }
        else if (player.name == "User2")
        {
            generation_axis = 56f;
        }
        else if (player.name == "SingleUser")
        {
            generation_axis = 0f;
            range = 3f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* Function will check when platform hits platfrom destroyer box collider
     * When it does, it will check which platform has been hit
     * Depending on which one it will replace an existing plaform or create a new one of another type and destroy the other platform.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GenerateNewPlatform(collision);
        
    }

    private void GenerateNewPlatform(Collider2D collision)
    {
        //When we collide with normal platform:
        if (collision.gameObject.name.StartsWith("Platform"))
        {
            //1 in 7 we will generate 'bigjump' platform
            if (Random.Range(1, 7) == 1)
            {
                Destroy(collision.gameObject);
                Instantiate(bigBouncePlatformPrefab, new Vector2(generation_axis + Random.Range(-5.5f, 5.5f), player.transform.position.y + range + Random.Range(extra - 0.5f, extra)), Quaternion.identity);
            }
            else
            {
                collision.gameObject.transform.position = new Vector2(generation_axis + Random.Range(-5.5f, 5.5f), player.transform.position.y + range + Random.Range(extra - 0.5f, extra));
            }
        }
        //When we collide with bigjump platform
        else if (collision.gameObject.name.StartsWith("BigJump"))
        {
            //1 in 7 we will replace this bigjump platform, 6 in 7 generate new normal platform.
            if (Random.Range(1, 7) == 1)
            {
                collision.gameObject.transform.position = new Vector2(generation_axis + Random.Range(-5.5f, 5.5f), player.transform.position.y + range + Random.Range(extra - 0.5f, extra));
            }
            else
            {
                Destroy(collision.gameObject);
                Instantiate(platformPrefab, new Vector2(generation_axis + Random.Range(-5.5f, 5.5f), player.transform.position.y + range + Random.Range(extra - 0.5f, extra)), Quaternion.identity);
            }
        }
    }
}