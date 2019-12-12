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
    private string port;
    private bool found = false;

    // Start is called before the first frame update
    void Start()
    {
        ports = SerialPort.GetPortNames();
        foreach(string p in ports) {
          Debug.Log(p);
            sp = new SerialPort(p, 9600);
            sp.ReadTimeout = 1;
            if (!sp.IsOpen)
            {
                Debug.Log("Opening port");
                sp.Open();
                Debug.Log("Port opened");
            }
            if (sp.IsOpen) {
              for(int i = 0; i<10;i++){
                if (sp.ReadByte() == 10){
                  if(sp.ReadByte() == 23){
                    port = p;
                    Debug.Log("Port found : " + port);
                    found = true;
                    break;
                  }
                }
              }
            }
            if(found){
              break;
            }
        }


        sp = new SerialPort(port,9600);
    }

    // Update is called once per frame
    void Update()
    {
        currentArray = ValuesArduino();
        //Debug.Log(currentArray[2]);
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
                sp.ReadByte(); //Reading the value 23
                for(int i = 0; i<8; i++){
                    values[i] = sp.ReadByte();
                }

              }
                //Debug.Log("Start");
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
