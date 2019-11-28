using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    TileGenerator tg;

    private float[] coords = new float[2];
    private float y_pos;
    private float x_pos;
    private Rigidbody2D body;
    public GameObject player;
    private float death_interval = 20f;

    // Start is called before the first frame update
    void Start()
    {
        tg = GameObject.Find("PfDestroyer").GetComponent<TileGenerator>();
    }

      public void lastPlatformPosition(){
        coords = tg.getLowestTile();
        x_pos = coords[0];
        y_pos = coords[1];
      }

    // Update is called once per frame
    void Update()
    {
        lastPlatformPosition();
        CheckDeath();

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
