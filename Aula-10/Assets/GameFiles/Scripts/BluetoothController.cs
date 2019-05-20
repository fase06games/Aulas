using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechTweaking.Bluetooth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BluetoothController : Shootable
{

	private BluetoothDevice device;
	public Text statusText;

	private bool isShooting = false;

    public Vector3 vrRotation = new Vector3(0,0,0);

    public override Vector3 GetVrGunRotation()
    {
        return vrRotation;
    }

    public override bool IsShooting()
    {
        return isShooting;
    }

	void Awake()
	{
		BluetoothAdapter.enableBluetooth();

		device = new BluetoothDevice();
		device.Name = "BT_Controller01"; //Colocar o nome do seu bluetooth aqui a esquerda
		device.setEndByte(255);
		device.ReadingCoroutine = ManageConnection;
		DontDestroyOnLoad(this.gameObject);

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


    public void Play()
    {
    	SceneManager.LoadScene("MainScene");
    }

    IEnumerator ManageConnection(BluetoothDevice device){

        statusText.text = "Status: Connected & Can Read";
        while (device.IsConnected && device.IsReading) {

            BtPackets packets = device.readAllPackets ();

            if (packets != null) {
                int N = packets.Count - 1;
                int indx = packets.get_packet_offset_index (N);
                int size = packets.get_packet_size (N);

                if (size == 6) {
                    int fire = (packets.Buffer [indx + 1] << 8) | packets.Buffer [indx];
                    fire = fire >> 3;

                    int acX = (packets.Buffer [indx + 3] << 8) | packets.Buffer [indx + 2];
                    acX = acX >> 3;

                    int acY = (packets.Buffer [indx + 5] << 8) | packets.Buffer [indx + 4];
                    acY = acY >> 3;

                    vrRotation = new Vector3(acX, acY, 0);

                    if (statusText != null){
                        statusText.text = fire.ToString() + ", "
                        + acX.ToString() + ", " + 
                        acY.ToString();

                    }

                    if (fire == 1)
                        isShooting = true;
                    else if (fire == 0)
                        isShooting = false;
                }
            }

            yield return null;
        }
            
    }

    /* Update is called once per frame
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
    */
}
