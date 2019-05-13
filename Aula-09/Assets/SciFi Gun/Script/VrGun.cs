using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // Array.Copy
public class VrGun : MonoBehaviour {

	private Vector3 nextRot;
	public int smoothNumber = 5;
	private Vector3[] angleBuffer;
	private int bufIndex = 0;

	void Start () 
	{
		angleBuffer = new Vector3[smoothNumber];
	}

	//Tranforma "0 -- 1023" para "-512 ... 512" depous para "-51 ... 52"
	float FormatData(float value){
		float v =   value < 1024/2 ? -1*(1024/2 - value): value - 1024/2; 
		return -v/10;
	}

	public void SetRotation(Vector3 rotation)
	{

		float x = FormatData(rotation.x);
		float y = FormatData(rotation.y);
		float z = FormatData(rotation.z);

		Vector3 newRot = new Vector3(x, y, z);

		if (bufIndex < smoothNumber - 1)
		{
			angleBuffer[bufIndex] = newRot;
			bufIndex++;
		}
		else
		{
			Vector3[] newArray = new Vector3[angleBuffer.Length];
			Array.Copy(angleBuffer, 1, newArray, 0, angleBuffer.Length - 1);
			newArray[angleBuffer.Length - 1] = newRot;

			angleBuffer = newArray;

			float X = 0f, Z = 0f, Y = 0f;

			for (int i = 0; i < angleBuffer.Length; i++)
			{
				X += angleBuffer[i].x;
				Y += angleBuffer[i].y;
				Z += angleBuffer[i].z;
			}
			X /= (float)angleBuffer.Length;
			Y /= (float)angleBuffer.Length;
			Z /= (float)angleBuffer.Length;

			nextRot = new Vector3(X,78+ X,Y);
		}   

		transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(nextRot), Time.deltaTime * smoothNumber);
	}

}
