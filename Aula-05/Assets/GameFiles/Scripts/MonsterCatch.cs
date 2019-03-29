using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCatch : MonoBehaviour
{
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Monster")
		{
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		}
	}
}
