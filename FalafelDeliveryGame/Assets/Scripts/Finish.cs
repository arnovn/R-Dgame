using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Finish : MonoBehaviour
{
    public GameObject user;
    public float ypos;
    public GameObject PfDestroyer;
    public GameObject[] tiles;
    public GameObject finishLinePrefab;
    public GameObject test;
    private Timer timerText;



    private bool isFinished;
    private Rigidbody2D rigid;
    private TileGenerator tg;
    private float x_pos;

        // Start is called before the first frame update
    void Start()
    {
        isFinished = false;
        tg = PfDestroyer.GetComponent<TileGenerator>();
        rigid = user.GetComponent<Rigidbody2D>();
        x_pos = rigid.position.x;
        timerText = user.GetComponent<Timer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (rigid.position.y >= ypos) {
            //Debug.Log("yaaaaayeeeet  " + rigid.gameObject.name);
            if (test == null)
            {
                Debug.Log("Stop Generating");
                tg.StopGenerating();

                test = Instantiate(finishLinePrefab, new Vector3(x_pos, tg.getHighestTilePosition()+5f, 0), Quaternion.identity);


            }
        }

        if(rigid.position.y>= tg.getHighestTilePosition()+5f && test!=null )
        {

            isFinished = true;
            timerText.SetFinished(true);
        }

    }

   public bool GetIsFinished()
    {
        return isFinished;
    }

}
