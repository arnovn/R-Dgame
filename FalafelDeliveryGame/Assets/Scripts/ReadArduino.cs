using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class ReadArduino : MonoBehaviour
{

    SerialPort sp = new SerialPort("COM3", 9600);

    private int[] values = new int[5];
    private int[] currentArray = new int[5];
    private int[] lastFilledArray = new int[5];

    // Start is called before the first frame update
    void Start()
    {
      sp.Open();
      sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {

        currentArray = ValuesArduino();
    }

    public void WriteArduino(int intje){
      string intjeString = intje.ToString();
      sp.Write(intjeString);
      Debug.Log((int)sp.ReadByte());
    }

    public int[] ValuesArduino(){

      if (sp.IsOpen)
      {
          try
          {
            //Debug.Log((int)sp.ReadByte());
            /*
              if(sp.ReadByte() == 10){
                //Debug.Log("Start");
                for(int i = 0; i<4; i++){
                    values[i] = sp.ReadByte();

                }

              }

              lastFilledArray = values;
              return values;
              */
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
