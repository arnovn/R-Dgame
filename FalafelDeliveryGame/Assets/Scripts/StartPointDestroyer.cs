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

    }

    /* Function will check when platform hits platfrom destroyer box collider
     * When it does, it will check which platform has been hit
     * Depending on which one it will replace an existing plaform or create a new one of another type and destroy the other platform.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyStartPoint(collision);

    }

    private void DestroyStartPoint(Collider2D collision)
    {
        //When we collide with normal platform:
        if (collision.gameObject.name.StartsWith("Startpoint"))
        {
            Destroy(collision.gameObject);
        }
    }
}
