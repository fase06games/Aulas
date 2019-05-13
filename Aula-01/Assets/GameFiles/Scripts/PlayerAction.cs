using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{

	public GameObject bullet;
	public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
        	GameObject createdBullet = Instantiate(bullet);
        	createdBullet.transform.position = transform.position;

        	Rigidbody rbullet = createdBullet.GetComponent<Rigidbody>();
        	Camera cam = GetComponentInChildren<Camera>();
        	rbullet.velocity = cam.transform.rotation * Vector3.forward * speed;
        }
    }
}
