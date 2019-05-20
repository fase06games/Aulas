using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Shootable : MonoBehaviour
{

	abstract public bool IsShooting();
	abstract public Vector3 GetVrGunRotation();

   
}
