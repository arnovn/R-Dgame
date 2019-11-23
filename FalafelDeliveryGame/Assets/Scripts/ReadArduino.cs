using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ReadArduino : MonoBehaviour
{
    SerialPort sp = new SerialPort("COM3", 9600);
    public int valArduino;
    // Start is called before the first frame update
    void Start()
    {
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
