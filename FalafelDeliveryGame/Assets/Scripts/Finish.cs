using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject user1;
    public float yPos1;
    public TileGenerator tileG;
    public GameObject[] tiles;
    public GameObject finishLinePrefab;
    public GameObject test;
    public Timer timerText;
    
        // Start is called before the first frame update
    void Start()
    {
        tileG = user1.GetComponentInChildren<TileGenerator>();

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
        if (yPos1 >= 150) {
            if (tileG != null)
            { Destroy(tileG); }
            if (test == null)
            {
                test = Instantiate(finishLinePrefab, new Vector3(0.15f, 165, 0), Quaternion.identity);
                Destroy(timerText);
                
            }
            
           

        }



    }
}

