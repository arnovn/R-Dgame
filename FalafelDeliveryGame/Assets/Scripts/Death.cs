using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    private TileGenerator tg;
    private ReadArduino ra;
    private SUserInterface SUI;
    private Rigidbody2D body;
    private DdaParams ddaparams;
    private float[] coords = new float[2];
    private float y_pos;
    private float x_pos;
    private float death_interval = 50f;
    private int lifes = 5;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        tg = GameObject.Find("PfDestroyer1").GetComponent<TileGenerator>();
        ra = GameObject.Find("UserController").GetComponent<ReadArduino>();
        SUI = GameObject.Find("DdaCollider1").GetComponent<SUserInterface>();
        ddaparams = GameObject.Find("DdaCollider1").GetComponent<DdaParams>();
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

    public int getLifes(){
      return lifes;
    }

    public void AddLife(){
      lifes++;
    }

    public void LoseLife() {
        lifes--;
    }

    private void CheckDeath()
    {
        float actual_pos = player.transform.position.y;
        if (y_pos - actual_pos >= death_interval)
        {
            lifes --;
            //Debug.Log(lifes);
            SUI.DeleteOneLife(lifes);
            ra.WriteArduino(1);
            player.transform.position = new Vector2(tg.returnLowestXPosition(), tg.returnLowestYPosition() + 3f);
            ddaparams.Died();
            ddaparams.ReduceSkill();
        }
    }
}
