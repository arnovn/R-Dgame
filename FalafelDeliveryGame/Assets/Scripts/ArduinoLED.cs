using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;
using System;

public class ArduinoLED : MonoBehaviour {

    SerialPort arduino = new SerialPort("COM5", 19200);   //serial port refference and Baud rate
    public string message;
    public Text txt;


	// Use this for initialization
	void Start () {
        arduino.Open();     //Open serial stream 
        txt.text = "initial";
	}
	
	// Update is called once per frame
	void Update () {

        message = ReadArduino();       //Read information in the serial stream;
        Debug.Log(message);

        if (message == "Hello Unity") {
            txt.text = "yeet";
        }
        if (message == "Goodbye Unity"){
            txt.text = "neet";
        }

        arduino.BaseStream.Flush();     //Clear the serial information so we assure we get new information.
    }

    public string ReadArduino(int timeOut = 0)
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
    

}
