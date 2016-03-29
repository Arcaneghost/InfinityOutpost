using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shoot : MonoBehaviour {

	public Rigidbody objectToShoot;

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{

		if (objectToShoot != null) 
		{
			if (Input.GetButtonUp ("Fire1")) 
			{
				Rigidbody bullet = Instantiate (objectToShoot, transform.position, transform.rotation) as Rigidbody;					
				bullet.velocity = transform.TransformDirection (Vector3.forward * 240);
			}
		}
	}
}
