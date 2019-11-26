using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;
using System;

public class ArduinoConnect : MonoBehaviour {

    public SerialPort arduino = new SerialPort("COM6", 9600);   //serial port refference and Baud rate
    public string message;
    public Text txt;
    public string LedControl;


	// Use this for initialization
	void Start () {
        arduino.Open();     //Open serial stream 
        txt.text = "initial";
	}
	
	// Update is called once per frame
	void Update () {
            arduino.Write("1");
            message = ReadArduino();        //Read information in the serial stream;
            //Debug.Log(message);

         arduino.BaseStream.Flush();     //Clear the serial information so we assure we get new information.
    }

    public string ReadArduino(int timeOut = 1)
    {
        arduino.ReadTimeout = timeOut;
        try
        {
            return arduino.ReadLine();
        }
        catch (TimeoutException e)
        {
            return null;
        }
    }

    void OnApplicationQuit()
    {
        arduino.Close();
    }
}
