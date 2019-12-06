using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class ReadArduino : MonoBehaviour
{

    SerialPort sp = new SerialPort("COM14", 9600);

    private int[] values = new int[7];
    private int[] currentArray = new int[7];
    private int[] lastFilledArray = new int[7];

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
        //Debug.Log(currentArray[4]);

    }

    public void WriteArduino(int intje){
      string intjeString = intje.ToString();
      sp.Write(intjeString);
      //Debug.Log((int)sp.ReadByte());
    }

    public int[] ValuesArduino(){

      if (sp.IsOpen)
      {
          try
          {
            //Debug.Log((int)sp.ReadByte());

              if(sp.ReadByte() == 10){
                //Debug.Log("Start");
                for(int i = 0; i<6; i++){
                    values[i] = sp.ReadByte();

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
