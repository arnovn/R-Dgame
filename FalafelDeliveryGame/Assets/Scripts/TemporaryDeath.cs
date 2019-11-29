using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemporaryDeath : MonoBehaviour
{

    TileGenerator tg;
    SUserInterface singleInterface;

    private float[] coords = new float[2];
    private float y_pos;
    private float x_pos;
    private int lifecounter;
    private Rigidbody2D body;
    public GameObject player;
    public GameObject lives;
    private float death_interval = 20f;

    // Start is called before the first frame update
    void Start()
    {
        tg = GameObject.Find("PfDestroyer").GetComponent<TileGenerator>();
        singleInterface = this.GetComponent<SUserInterface>();
        singleInterface.ConnectLives();
        lifecounter = 1;
    }

   

    public void lastPlatformPosition()
    {
        coords = tg.getLowestTile();
        x_pos = coords[0];
        y_pos = coords[1];
    }

    // Update is called once per frame
    void Update()
    {
      //  lastPlatformPosition();
        CheckDeath();

    }

    private void CheckDeath()
    {
        float actual_pos = player.transform.position.y;
        if (actual_pos < -2f)
        {
            player.transform.position = new Vector2(-60f, 27f);
            DeleteLife(lifecounter);
        }
        else if (actual_pos > 35f)
        {
            AddLife(lifecounter);
        }
    }


    private void DeleteLife(int id)
    {
        singleInterface.DeleteOneLife(id);
        lifecounter++;
    }
    private void AddLife(int id)
    {
        singleInterface.AddOneLife(id);
        if (lifecounter > 0)
        {
            lifecounter--;
        }
            
    }
}
