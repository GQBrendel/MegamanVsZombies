using UnityEngine;
using System.Collections;
using Uduino;

public class MultipleArduino : MonoBehaviour
{
    UduinoManager u;
    int sensorOne = 0;
    int sensorTwo = 0;

    void Start()
    {
        //Set up the pinMode of the boards should not be done on Start() or Awake() 
        // but on the delegate function OnBoardConnected(). It should be called only if
        // you use several boards with the default Uduino arduino sketch.
        UduinoManager.Instance.OnBoardConnected += OnBoardConnected;
        UduinoManager.Instance.OnValueReceived += OnValuesReceived;
    }

    void Update()
    {
        if (UduinoManager.Instance.hasBoardConnected())
        {
            UduinoDevice firstDevice = UduinoManager.Instance.GetBoard("myArduinoName");
            UduinoDevice secondDevice = UduinoManager.Instance.GetBoard("myOtherArduino");
            UduinoManager.Instance.Read(firstDevice, "myVariable");
            UduinoManager.Instance.Read(secondDevice, "mySensor");
            Debug.Log(sensorOne);
            Debug.Log(sensorTwo);
        }
    }

    void OnValuesReceived(string data, UduinoDevice device)
    {
        if (device.name == "myArduinoName") sensorOne = int.Parse(data);
        else if (device.name == "myOtherArduino") sensorTwo = int.Parse(data);
    }

    void OnBoardConnected(UduinoDevice connectedDevice)
    {
        if (connectedDevice.name == "uduinoBoard")
        {
            // Set the pinMode of the first board here.
            //  UduinoManager.Instance.pinMode(connectedDevice, 13, PinMode.Input_pullup);
            //
            // You can also add extra settings : 
            // connectedDevice.alwaysRead = false;
            // connectedDevice.readTimeout = 50;
        }
        else if (connectedDevice.name == "uduinoBoard2")
        {
            // Set the pinMode of the second board here.
            //  UduinoManager.Instance.pinMode(connectedDevice, 12, PinMode.Output);
        }
    }
}
