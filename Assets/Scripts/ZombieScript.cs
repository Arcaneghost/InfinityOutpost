using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class ZombieScript : MonoBehaviour {

	//parameters
	float distance;
	RaycastHit hit;
	float chaseSpeed = .2f;
	float rotationSpeed = 2f;
	float  attackThreshold = 1.5f;
	float  chaseThreshold = 10f;
	float  giveUpThreshold = 20f;
	bool attacking = false;

	///Waypoint Config
	float accel = 0.8f;
	float inertia = 0.9f;
	float speedLimit = 2f;
	float minSpeed = 1.0f;
	float stopTime = 1.0f;

	private float currentSpeed = 0.0f;
	private bool accelState;
	private bool slowState ;
	private Transform waypoint;
	float rotationDamping = 6.0f;
	bool smoothRotation = true;
	Transform [] waypoints;
	private int WPindexPointer;


	bool timeToChase = false;
	bool timeToAttack = false;
	float  attackRepeatTime = 3f;
	public float  ZombieLife = 3f;
	private float  functionState = 0f;
	private bool chasing = false;
	public Transform target;
	public Transform myTransform;
	public Animator anim;
	public Rigidbody self;


	void Awake(){
		
		anim = gameObject.gameObject.GetComponent<Animator> ();
	}
	void Start (){
		functionState = 0;

		}



	void Update ()
	{


		distance = (target.position - myTransform.position).magnitude;

		if (distance < 50f && distance > chaseThreshold)
			anim.SetBool ("timeToChase", true);
			timeToChase = true;

		if (ZombieLife == 0) {
			Destroy (gameObject);
		}

		//if (timeToChase) {
		 

			//myTransform.position += myTransform.forward * chaseSpeed * Time.deltaTime;
		Vector3 dir = target.position - myTransform.position;
		dir.y = 0f;
		myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (dir), rotationSpeed * Time.deltaTime * rotationDamping);
			

			if (distance <= attackRepeatTime) {
				anim.SetBool ("timeToAttack", true);
				timeToAttack = true;
				chaseSpeed = 0;
				anim.SetBool ("timeToChase", false);
				timeToChase = false;
			}


			if (distance >= chaseThreshold) {
				anim.SetBool ("timeToChase", true);
				timeToChase = true;
				chaseSpeed = 5;
				anim.SetBool ("timeToAttack", false);
				timeToAttack = false;
			}


			if (distance > attackThreshold) {
				anim.SetBool ("timeToChase", true);
				timeToChase = true;
				chaseSpeed = 5;
				anim.SetBool ("timeToAttack", false);
				timeToAttack = false;
			}


		//} else {
		//if (distance == speedLimit) {
		//		currentSpeed = speedLimit;
		//	}
		//}

	}

	void fixedUpdate (){
		Vector3 dir = target.position - myTransform.position;
		self.AddForce(dir.x, 0, dir.z);

	}
//	void OnTriggerEnter(Collider other) {
//
//		if(other.gameObject.CompareTag("Player"))
//			{
//				Debug.Log("You were hit");
//			}
//			if(other.gameObject.CompareTag("Waypoint")){
//
//
//				functionState = 1;
//				WPindexPointer++; ///when it collides with a waypoint, change waypoint to the next
//
//
//				if(WPindexPointer >= waypoints.Length)
//				{
//					WPindexPointer = 0; //reset the active waypoint to the first
//				}
//
//
//			}
//		}
}

		///if declared Slow();

//		function Slow(){
//			if(slowState == false){
//				accelState = false;
//				slowState = true;
//			}
//			///slow down (or speed ip if inertia is set above 1.0 in the inspector)
//			currentSpeed = currentSpeed * inertia * Time.deltaTime;
//			myTransform.Translate(0, 0, Time.deltaTime);
//			if(currentSpeed <= minSpeed)
//			{
//				currentSpeed = 0.0;
//				yield WaitForSeconds(stopTime); //wait for some time before moving to the next waypoint
//				functionState = 0;
//			}
//		}
//