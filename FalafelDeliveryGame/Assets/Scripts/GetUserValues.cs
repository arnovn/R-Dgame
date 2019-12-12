using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUserValues : MonoBehaviour
{
    private int[] UserValues = new int[4];

    public ReadArduino ra;
    public int UserNr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 4; i++)
        {
            UserValues[i] = ra.ValuesArduino()[2 * i + UserNr - 1];
        }
        
    }

    public int[] Values()
    {
        return UserValues;
    }

    public void PlayerDied()
    {
        ra.WriteArduino(UserNr);
        Debug.Log(UserNr);
    }
}
