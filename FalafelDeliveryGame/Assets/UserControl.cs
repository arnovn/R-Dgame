using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour
{

    public Rigidbody2D user1;
    public Rigidbody2D user2;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            user1.AddForce(Vector2.up * 600f);
            Debug.Log("yep");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            user2.AddForce(Vector2.up * 600f);
        }
    }
}
