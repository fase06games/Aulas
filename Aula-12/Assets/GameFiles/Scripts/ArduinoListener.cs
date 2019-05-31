using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoListener : Shootable
{
    
	SerialPort port = new SerialPort("COM4", 9600);

    void Start()
    {
    	try
    	{
			port.Open();
        	port.ReadTimeout = 1;
    	}
        catch
        {
        	Debug.LogError("Conexão com arduino não estabelecida!");
        }
    }

    public override Vector3 GetVrGunRotation()
    {
        return new Vector3(0,0,0);
    }

    public override bool IsShooting()
    {
    	bool response = false;

        if(port.IsOpen)
        {
        	try
        	{
        		if(port.ReadByte() == 1)
        			response = true;
        		else
        			response = false;
        	}
        	catch(System.Exception)
        	{
        		//nhe
        	}
        }
        return response;
    }
}
