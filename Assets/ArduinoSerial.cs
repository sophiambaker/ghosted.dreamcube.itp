using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System;

public class ArduinoSerial : MonoBehaviour {

// Inputs from Arduino
public static float xInput =0;
public static float yInput =0;
public static float zInput=0;
public static float AccX = 0;
public static float AccY = 0;
public static float AccZ = 0;

private static float firstZInput = -1;
private static float initialYDegrees = 174;
private static float RawMinutes = 0;
private float currentAcceleration = 0;

// Serial Info
private SerialPort stream;
private Thread thread;
private Queue outputQueue;    // From Unity to Arduino
private Queue inputQueue;    // From Arduino to Unity
private int baudRate = 9600;
private string portName = "/dev/tty.usbmodem14101";     // WINDOWS change to COM4
private int timeout = 100;
private bool loop = true;

  void Start() {
    StartThread();
  }

  void Update() {
    string input = ReadFromArduino();
    parseInput(input);
    SendToArduino("ready");
  }

  /*******************************************************************************
   *
   *                 Thread Safe Serial Communication API
   *
   ******************************************************************************/

  void SendToArduino(string command)
  {
      outputQueue.Enqueue(command);

  }

  string ReadFromArduino()
  {
      if (inputQueue.Count == 0)
      {
          return null;
      }

      return (string)inputQueue.Dequeue();
  }

  /*******************************************************************************
   *
   *                 HandShaking/ Serial Communication (w/ Arduino)
   *
   ******************************************************************************/

  void OnApplicationQuit()
  {
      loop = false;
      Debug.Log("Application ending after " + Time.time + " seconds");

  }

  void StartThread()
  {
      outputQueue = Queue.Synchronized(new Queue());
      inputQueue = Queue.Synchronized(new Queue());
      // Creates and starts the thread
      thread = new Thread(ThreadLoop);
      thread.Start();
  }

  void ThreadLoop()
  {
          // Opens the connection on the serial port
      stream = new SerialPort(portName, baudRate);
      stream.ReadTimeout = timeout;
      stream.Open();
      if (stream.IsOpen)
      {
          Debug.Log("Serial Port Open.");
      }

      // Looping
      while (loop)
      {
          // Send to Arduino
          if (outputQueue.Count != 0)
          {
              string command = outputQueue.Dequeue().ToString();
              SendDataToSerialPort(command);
          }

          // Read from Arduino
          string result = ReadFromSerialPort(timeout);
          if (result != null)
              inputQueue.Enqueue(result);
      }
  }

      void SendDataToSerialPort(string command)
  {
      if (stream.IsOpen)
      {
          //Debug.Log("Sending Data to Serial Port.");
          byte[] bites = System.Text.Encoding.UTF8.GetBytes(command);
          stream.Write(bites, 0, 1);


      }
  }

  string ReadFromSerialPort(int timeout)
  //only read when seri is avalible and same thing on arduino
  {
      try {
          string input = stream.ReadLine();
          return input;
      }
      catch(TimeoutException e)
      {
          //Debug.Log("Error: " + e);
          stream.BaseStream.Flush();
          return null;
      }
  }

  /*******************************************************************************
   *
   *                              Data Processing
   *
   ******************************************************************************/

  void parseInput(string input)
  {
      try
      {
          if (input == null)
          {
              return;
          }
          string[] values = input.Split(',');
          float rawZInput;
          if (values.Length >= 6)
          {
              xInput = float.Parse(values[0]);
              yInput = float.Parse(values[1]);
              float z = float.Parse(values[2]);

              AccX = Mathf.Abs(float.Parse(values[3]));
              AccZ = Mathf.Abs(float.Parse(values[4]));
              AccY = float.Parse(values[5]);
              currentAcceleration = AccX + AccZ;
              Debug.Log("Y Acc: " + AccY.ToString());
              //Debug.Log("xInput " + currentAcceleration.ToString());
              //Debug.Log("current Acceleration: " + currentAcceleration.ToString());

              if (firstZInput == -1 && z != 0)
              {
                  firstZInput = z;
              }
              rawZInput = z;
              //Debug.Log("firstZ: " + firstZInput.ToString() + ", LatestZ: " + rawZInput.ToString());
              zInput = initialYDegrees + (firstZInput - rawZInput);
          }
          else
          {
              Debug.Log("Less than 5 values read into Unity");
          }
      }
      catch(Exception e)
      {
          //Debug.Log("Input: " + input);
      }
  }
}
