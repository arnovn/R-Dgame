using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    private TileGenerator tg;
    private GetUserValues ra;
    private SUserInterface SUI;
    private Rigidbody2D rb2d;
    private DdaParams ddaparams;
    private Background background;

    private float[] coords = new float[2];
    private float y_pos;
    private float x_pos;
    private float death_interval = 100f;
    private int lives = 5;

    public GameObject player;
    public GameObject PfDestroyer;
    public GameObject DdaCollider;
    public GameObject Arduino;

    // Start is called before the first frame update
    void Start()
    {

        tg = PfDestroyer.GetComponent<TileGenerator>();
        ra = Arduino.GetComponent<GetUserValues>();
        SUI = DdaCollider.GetComponent<SUserInterface>();
        ddaparams = DdaCollider.GetComponent<DdaParams>();
        rb2d = player.GetComponent<Rigidbody2D>();
        background = player.GetComponent<Background>();

        for (int i = 0; i<5; i++)
        {
            //SUI.AddOneLife(i);
        }

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

    public int getLives(){
      return lives;
    }

    public void AddLife(){
        if (lives < 5)
        {
            lives++;
        }
    }
    /*
    public void LoseLife() {
      if(lifes>0){
        lifes--;
      }
    }
    */
    private void CheckDeath()
    {
        float actual_pos = player.transform.position.y;
        if (tg.returnLowestYPosition() - actual_pos >= death_interval)
        {
            Died();

        }
    }
    public void Died()
    {
        lives--;

        SUI.DeleteOneLife(lives);
        ra.PlayerDied();
        player.transform.position = new Vector2(tg.returnLowestXPosition(), tg.returnLowestYPosition() + 3f);
        rb2d.velocity = new Vector2(0f, 25f);
        background.UserDied();
        ddaparams.Died();
        ddaparams.ReduceSkill();
        FindObjectOfType<AudioManager>().Play("Died");
    }
}
