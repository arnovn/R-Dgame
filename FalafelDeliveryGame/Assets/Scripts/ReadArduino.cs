using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class ReadArduino : MonoBehaviour
{

    SerialPort sp = new SerialPort("COM3", 9600);

    private int[] values = new int[2];
    private int[] currentArray = new int[2];
    private int[] lastFilledArray = new int[2];
    private
    // Start is called before the first frame update
    void Start()
    {
      sp.Open();
      sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {

        //writeArduino();
        //currentArray = ReadArduino();
        currentArray = ValuesArduino();
    }

    public int[] ValuesArduino(){

      if (sp.IsOpen)
      {
          try
          {
              if(sp.ReadByte() == 10){
                //Debug.Log("Start");
                for(int i = 0; i<2; i++){
                    values[i] = sp.ReadByte();
                    //Debug.Log(values[i]);
                }

              }
              lastFilledArray = values;
              return values;
          }
          catch (System.Exception)
          {
              //Debug.Log("Not open");
              return lastFilledArray;
          }
      }
      else{
        return lastFilledArray;
      }
    }


    void OnApplicationQuit()
    {
        if (sp != null)
            sp.Close();
    }
}
