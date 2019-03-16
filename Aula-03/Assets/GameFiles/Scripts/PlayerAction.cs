using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
	public GameObject bullet;
	public float bulletSpeed = 10.0f;

	public ArduinoListener arduino = null;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") || arduino.IsShooting() )
        {
        	Shoot();
        }
    }

    public void Shoot()
    {
    	GameObject createdBullet = Instantiate(bullet);
        createdBullet.transform.position = transform.position;

        Rigidbody rBullet = createdBullet.GetComponent<Rigidbody>();
        Camera cam = GetComponentInChildren<Camera>();

        rBullet.velocity = cam.transform.rotation * Vector3.forward * bulletSpeed;
    }

    
}
