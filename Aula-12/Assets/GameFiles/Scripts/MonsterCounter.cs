using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCounter : MonoBehaviour
{

	public int counter;
	public TextMesh hudText;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    public void increment()
    {
    	counter += 1;
    	hudText.text = counter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
