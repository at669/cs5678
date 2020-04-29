// Deprecated; cannot use Link

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

// https://www.alanzucconi.com/2015/10/07/how-to-integrate-arduino-with-unity/
public class ArduinoReader : MonoBehaviour
{
    SerialPort stream;

    // Start is called before the first frame update
    void Start()
    {
        stream = new SerialPort("COM4", 9600); 
        stream.ReadTimeout = 50;
        stream.Open();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WriteToArduino(string message) {
        stream.WriteLine(message);
        stream.BaseStream.Flush();
    }

    public string ReadFromArduino (int timeout = 0) {
        stream.ReadTimeout = timeout;        
        try {
            return stream.ReadLine();
        }
        catch (TimeoutException e) {
            return null;
        }
    }

}
