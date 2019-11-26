using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class ReadArduino : MonoBehaviour
{
    private int joystick1 = 0;
    private int joystick2 = 0;
    private int jumpbutton1 = 0;
    private int jumpbutton2 = 0;
    private int rfidvalue1 = 0;
    private int rfidvalue2 = 0;

    SerialPort sp = new SerialPort("COM13", 9600);
    // Start is called before the first frame update
    void Start()
    {
      sp.Open();
      sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                joystick1 = int.Parse(sp.ReadLine());
                joystick2 = int.Parse(sp.ReadLine());
                jumpbutton1 = int.Parse(sp.ReadLine());
                jumpbutton2 = int.Parse(sp.ReadLine());
                rfidvalue1 = int.Parse(sp.ReadLine());
                rfidvalue2 = int.Parse(sp.ReadLine());
                Debug.Log("Joystick 1 value: "+ joystick1);
                Debug.Log("Joystick 2 value: " + joystick2);
                Debug.Log("Jumpbutton 1 value: " + jumpbutton1);
                Debug.Log("Jumpbutton 2 value: " + jumpbutton2);
                Debug.Log("Rfid 1 value: " + rfidvalue1);
                Debug.Log("Rfid 2 value: " + rfidvalue2);
            }
            catch (System.Exception)
            {
                Debug.Log("Not open");
            }
        }
    }

    public int getJoystick1()
    {
        return joystick1;
    }
    void OnApplicationQuit()
    {
        if (sp != null)
            sp.Close();
    }
}
