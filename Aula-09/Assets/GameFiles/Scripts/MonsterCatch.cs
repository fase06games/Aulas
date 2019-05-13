using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCatch : MonoBehaviour
{

	MonsterCounter monsterCounter;

	void Start()
	{
		monsterCounter = FindObjectOfType<MonsterCounter>();
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Monster")
		{
			monsterCounter.Increment();
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		}
	}
}
