using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechTweaking.Bluetooth;
using UnityEngine.UI;

public class BluetoothController : MonoBehaviour
{

	private BluetoothDevice device;
	public Text statusText;

	void Awake()
	{
		BluetoothAdapter.enableBluetooth();

		device = new BluetoothDevice();
		device.Name = "BT_Controller01"; //Colocar o nome do seu bluetooth aqui a esquerda

	}

	public void Connect()
	{
		statusText.text = "Status: ...";
		device.connect();
		if(device.IsConnected)
		{
			statusText.text = "Connected with " + device.Name;
		}
		else
		{
			statusText.text = "Connection failed";
		}
	}

	public void Disconnect()
	{
		device.close();
	}

	public void SendHello()
	{
		device.send(System.Text.Encoding.ASCII.GetBytes("Hello\n"));
		statusText.text = "Status: sending hello";
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(device.IsConnected && device.IsReading){
        	byte[] msg = device.read();
        	if(msg != null){
        		string content = System.Text.ASCIIEncoding.ASCII.GetString(msg);
        		statusText.text = "Received: " + content;
        	}
        }
    }
}
