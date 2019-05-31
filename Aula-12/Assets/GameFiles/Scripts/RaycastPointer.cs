using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RaycastPointer : MonoBehaviour
{

	public Button button;
	public Image circleProgress;
	public float totalTime;

	private bool gvrStatus;
	private float gvrTimer;

	public UnityEvent GvrClick;


	public void GvrButtonOn()
	{
		gvrStatus = true;
	}

	public void GvrButtonOff()
	{
		gvrStatus = false;
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gvrStatus)
        {
        	gvrTimer += Time.deltaTime;
        	circleProgress.fillAmount = gvrTimer/totalTime;
        }
        else
        {
        	gvrTimer = 0;
        	circleProgress.fillAmount = 0;
        }

        if(gvrTimer >= totalTime)
        {
        	GvrClick.Invoke();
        }
    }
}
