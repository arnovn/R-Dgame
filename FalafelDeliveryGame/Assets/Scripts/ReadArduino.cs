using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ReadArduino : MonoBehaviour
{

    SerialPort sp = new SerialPort("COM3", 9600);
    public int valArduino;
    string[] portNames;
    // Start is called before the first frame update
    void Start()
    {
        portNames = SerialPort.GetPortNames();
      Debug.Log("The following serial ports were found:");

            // Display each port name to the console.
                foreach(string port in portNames){
                  Debug.Log(port);

                }
      sp.Open();
      sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int ValueArduino(){
      if (sp.IsOpen)
      {
          try
          {
              valArduino = sp.ReadByte();

          }
          catch(System.Exception)
          {

          }
      }
      return valArduino;
    }

    void OnApplicationQuit()
    {
        if (sp != null)
            sp.Close();
    }
}
