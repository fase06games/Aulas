using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObjects : MonoBehaviour
{

	public GameObject[] objects;
	public int min;
	public int max;
	public float distanceFromSpawn;
	public float spawnInterval;
	private int maxCount;
	private int count = 0;
	private GameObject randomObject;


    // Start is called before the first frame update
    void Start()
    {
        maxCount = Random.Range(min,max);

        if(spawnInterval == 0)
        {
        	for(int i = 0; i < maxCount; i++)
        	{
        		Spawn();
        	}
        }
        else
        {
        	InvokeRepeating("Spawn", 0, spawnInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(count >= maxCount)
        {
        	CancelInvoke();
        }
    }


    void Spawn()
    {
		int index = Random.Range(0, objects.Length);
		randomObject = Instantiate(objects[index]);
		randomObject.transform.parent = transform;
		

		float xpos = Random.Range(transform.position.x - distanceFromSpawn, 
			transform.position.x + distanceFromSpawn);


		float zpos = Random.Range( transform.position.z - distanceFromSpawn, 
			transform.position.z + distanceFromSpawn);

		randomObject.transform.localPosition = new Vector3(xpos, 0, zpos);

		count++;
    }
}
