using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class GetArduinoValue : MonoBehaviour
{

    ReadArduino ra;
    // Start is called before the first frame update
    void Start()
    {
        ra = GetComponent<ReadArduino>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int getValue(){
        return 1;
    }
}
