using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{

	public GameObject bullet;
	public float speed;

	public ArduinoListener arduino = null;

    private Shootable gun = null;

    private VrGun vrGun;

    public GameObject firePosition;

    public int playerSpeed;

    // Start is called before the first frame update
    void Start()
    {

        vrGun = GameObject.FindGameObjectWithTag("Gun").GetComponent<VrGun>();
        
        try{
            //gun = GetComponent<ArduinoListener>();
            gun = GameObject.Find("BT_Object").GetComponent<BluetoothController>();

        }catch(System.Exception){
            Debug.Log("BT_Object não foi encontrado");
        }
    }

    void Move()
    {
    	transform.position += Camera.main.transform.forward * playerSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
    	if(Input.GetButtonDown("Fire1") || arduino.IsShooting() == true)
        {
        	Shoot();
        }

        if(gun != null)
        {

        	if(vrGun != null)
        	{
        		vrGun.SetRotation(gun.GetVrGunRotation());

        		
        	}

        	if(gun.IsShooting())
        	{
        		Shoot();
        	}
        }

        Move();
    }


    void Shoot()
    {

        	GameObject createdBullet = Instantiate(bullet);
        	createdBullet.transform.position = firePosition.transform.position;

        	Rigidbody rbullet = createdBullet.GetComponent<Rigidbody>();
        	Camera cam = GetComponentInChildren<Camera>();
        	rbullet.velocity = firePosition.transform.rotation * Vector3.forward * speed;
     }    	

    
}
