using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Bullet : MonoBehaviour
{
	public Rigidbody bullet;
	public GameObject ball;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ( bullet.position.y <= 3.5f)
			Destroy (ball);
		
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "BasicEnemy") 
		{
			Destroy (other.gameObject);
			Destroy (ball);
		}
	}
}