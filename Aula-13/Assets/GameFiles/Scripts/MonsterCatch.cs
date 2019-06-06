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

    void OnCollisionEnter(Collision col)
    {
    	if(col.gameObject.tag == "Monster")
    	{
    		Destroy(col.gameObject);
    		Destroy(gameObject);
    		monsterCounter.increment();
    	}
    }
}
