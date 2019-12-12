using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPointDestroyer : MonoBehaviour
{
    public GameObject player;
    public GameObject startPointObject;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(startPointObject.transform.position.y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        DestroyStartPoint(collision);

    }

    private void DestroyStartPoint(Collider2D collision)
    {
        //When we collide with normal platform:
        //Debug.Log("startpoint weg");
        if (collision.gameObject.name.StartsWith("startpoint"))
        {
            Destroy(collision.gameObject);
        }
    }
}
