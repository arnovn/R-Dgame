using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject user1;
    public float yPos1;
    public TileGenerator tg;
    public GameObject[] tiles;
    public GameObject finishLinePrefab;
    public GameObject test;
    public Timer timerText;

        // Start is called before the first frame update
    void Start()
    {
        tg = GameObject.Find("PfDestroyer").GetComponent<TileGenerator>();


        UpdatePosition();
    }

    private void UpdatePosition()
    {
        yPos1 = user1.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        if (yPos1 >= 2000) {

            if (test == null)
            {
                tg.StopGenerating();
                test = Instantiate(finishLinePrefab, new Vector3(0.15f, 2050, 0), Quaternion.identity);
                Destroy(timerText);

            }
        }

    }
}
