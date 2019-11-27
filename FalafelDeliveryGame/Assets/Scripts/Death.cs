using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private float y_pos;
    private float x_pos;
    private Rigidbody2D body;
    public GameObject player;
    private float death_interval = 20f;

    // Start is called before the first frame update
    void Start()
    {

    }

      public void lastPlatformPosition(float x_posi, float y_posi){
        x_pos = x_posi;
        y_pos = y_posi;
      }

    // Update is called once per frame
    void Update()
    {
        CheckDeath();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        y_pos = player.transform.position.y;
        x_pos = player.transform.position.x;
    }
    private void CheckDeath()
    {
        float actual_pos = player.transform.position.y;
        if (y_pos - actual_pos >= death_interval)
        {
            player.transform.position = new Vector2(x_pos, y_pos);
        }
    }
}
