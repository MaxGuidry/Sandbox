using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    public float heightBounce = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    this.transform.position = new Vector3(this.transform.position.x,Mathf.Sin(Time.time/4f) * heightBounce,this.transform.position.z);
	}
}
