using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechTweaking.Bluetooth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BluetoothController : MonoBehaviour
{

	private BluetoothDevice device;
	public Text statusText;

	void Awake()
	{
		BluetoothAdapter.enableBluetooth();

		device = new BluetoothDevice();
		device.Name = "BT_Controller01";
		device.setEndByte(255);
		device.ReadingCoroutine = ManageConnection;
		DontDestroyOnLoad(this.gameObject);
	}

	public void connect()
	{
		statusText.text = "Status: ...";

		device.connect();
		if(device.IsConnected){
			statusText.text = "Connected with " + device.Name;
		} else{
			statusText.text = "Connection failed";
		}
	}

	public void Play()
	{
		Debug.Log("oi");
		SceneManager.LoadScene("CenaPrincipal");
	}

	public void disconnect()
	{
		device.close();
	}

	public void sendHello()
	{
		device.send(System.Text.Encoding.ASCII.GetBytes("Hello\n"));
		statusText.text = "Status: Sending Hello";
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator ManageConnection(BluetoothDevice device)
    {
    	statusText.text = "Status: Connected & Can Read";
    	while(device.IsConnected && device.IsReading)
    	{
    		BtPackets packets = device.readAllPackets();

    		if(packets != null)
    		{
    			int n = packets.Count - 1;
    			int index = packets.get_packet_offset_index(n);
    			int size = packets.get_packet_size(n);

    			if(size == 2)
    			{
    				int fire = (packets.Buffer[index + 1] << 8) | packets.Buffer[index];
    				fire = fire >> 3;

    				statusText.text = fire.ToString();

    			}
    		}

    		yield return null;
    	}
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
