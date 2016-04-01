using UnityEngine;
using System.Collections;

public class ZombieupdatedScript : MonoBehaviour {
	

	public float fpsTargetDistance;
	public float enemyLookDistance;
	public float attackDistance;
	public float enemyMovementSpeed;
	public float damping;
	public Transform fpsTarget;
	Rigidbody theRigidBody;

	void Awake() {
		
			 }

		// Use this for initialization
	void Start () {
		theRigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		fpsTargetDistance = Vector3.Distance (fpsTarget.position, transform.position);
		if (fpsTargetDistance < enemyLookDistance) 
		{
			lookAtPlayer ();
		}

		if (fpsTargetDistance < attackDistance)
		{
			attackPlease ();
			print ("ATTACK");
		}
	}

	void fixedUpdate (){
		if (fpsTargetDistance < attackDistance) {
			attackPlease ();
			print ("ATTACK");
		}
	}
	void lookAtPlayer()
	{
		Quaternion rotation = Quaternion.LookRotation (fpsTarget.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime*damping);
	}

	void attackPlease()
	{
		theRigidBody.AddForce (transform.forward*enemyMovementSpeed);
	}

}
