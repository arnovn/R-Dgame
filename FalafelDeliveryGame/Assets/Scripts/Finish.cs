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
    public Timer timerText;

    private Rigidbody2D rigid;
    private TileGenerator tg;
    private float x_pos;

        // Start is called before the first frame update
    void Start()
    {
        tg = PfDestroyer.GetComponent<TileGenerator>();
        rigid = user.GetComponent<Rigidbody2D>();
        x_pos = rigid.position.x;
    }
    // Update is called once per frame
    void Update()
    {
        if (rigid.position.y >= ypos) {
            Debug.Log("yaaaaayeeeet  " + rigid.gameObject.name);
            if (test == null)
            {
                tg.StopGenerating();
                test = Instantiate(finishLinePrefab, new Vector3(x_pos, tg.getHighestTilePosition()+5f, 0), Quaternion.identity);
                Destroy(timerText);

            }
        }

    }
}
