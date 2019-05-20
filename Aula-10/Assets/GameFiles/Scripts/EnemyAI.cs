using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
	public float wanderRadius = 20;
	public float wanderTimer = 1;
	private NavMeshAgent agent;
	private Transform target;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		InvokeRepeating("Walk", 0, wanderTimer);
	}

	void Walk(){
		Vector3 newPos = RandomNavSphere( transform.position, wanderRadius);
		agent.SetDestination(newPos);
	}

	public Vector3 RandomNavSphere( Vector3 origin, float dist ){
		 Vector3 randDirection = Random.insideUnitSphere * dist;
		 randDirection += origin;
		 NavMeshHit navHit;
		 if ( NavMesh.SamplePosition(randDirection, out navHit, dist, -1)){
		 	return navHit.position;
		 }else {
		 	return origin;
		 }
	}
}
