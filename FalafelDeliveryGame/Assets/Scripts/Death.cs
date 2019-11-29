using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    TileGenerator tg;
    ReadArduino ra;

    private float[] coords = new float[2];
    private float y_pos;
    private float x_pos;
    private Rigidbody2D body;
    public GameObject player;
    private float death_interval = 50f;

    // Start is called before the first frame update
    void Start()
    {
        tg = GameObject.Find("PfDestroyer").GetComponent<TileGenerator>();
        ra = GameObject.Find("SingleUser").GetComponent<ReadArduino>();
    }

      public void lastPlatformPosition(float x_posi, float y_posi){
        //Debug.Log("Coords: ");
        x_pos = x_posi;
        //Debug.Log(x_pos);
        y_pos = y_posi + 2f;
        //Debug.Log(y_pos);
      }

    // Update is called once per frame
    void Update()
    {
        CheckDeath();

    }

    private void CheckDeath()
    {
        float actual_pos = player.transform.position.y;
        if (y_pos - actual_pos >= death_interval)
        {
            ra.WriteArduino(1);
            player.transform.position = new Vector2(x_pos, y_pos);
        }
    }
}
