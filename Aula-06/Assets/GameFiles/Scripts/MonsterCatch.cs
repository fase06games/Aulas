using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCatch : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
    	if(col.gameObject.tag == "Monster")
    	{
    		Destroy(col.gameObject);
    		Destroy(gameObject);
    	}
    }
}
