using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlhoNoAlvo : MonoBehaviour
{
    public PlayerAction player;

    RaycastHit hit;
       Ray ray;

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(ray, out hit))
        {
        	if(hit.collider.tag == "Alvo")
        	{
        		Debug.Log(hit.collider);
        		player.Shoot();
        	}
        }
    }

    void OnDrawGizmos()
    {
    	Gizmos.DrawRay(ray);
    }
}
