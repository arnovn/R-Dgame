using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class ReadArduino : MonoBehaviour
{

    SerialPort sp;
    private string activePort;
    private int[] values = new int[8];
    private int[] currentArray = new int[8];
    private int[] lastFilledArray = new int[8 ];
    private string[] ports;

    // Start is called before the first frame update
    void Start()
    {
        ports = SerialPort.GetPortNames();
        foreach(string p in ports) {
            sp = new SerialPort(p, 9600);
            sp.ReadTimeout = 1;
            sp.Open();
            if (sp.IsOpen) { activePort = p; }
            sp.Close();
        }
      sp.Open();
      sp.ReadTimeout = 1;
        Debug.Log(sp.PortName+ sp.IsOpen);
    }

    // Update is called once per frame
    void Update()
    {

        currentArray = ValuesArduino();
        //Debug.Log(currentArray[0]);

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
                for(int i = 0; i<8; i++){
                    values[i] = sp.ReadByte();
                  //  Debug.Log("Arduino index " + i + " is " + values[i]);
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
