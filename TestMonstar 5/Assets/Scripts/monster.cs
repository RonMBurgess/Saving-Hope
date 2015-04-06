using UnityEngine;
using System.Collections;

public class monster : MonoBehaviour {
	public int speed;
	public float delay;
	private Vector3 target, playerPos;
	public GameObject player;
	private bool charging = false, normal = true, chargeFlag = false;


	//Added by Ron
	private int runningHash, walkingHash, dieHash, roarhash, idlehash;
	private Animator anim;
	private bool prepareCharge;
	//End Ron

	// Use this for initialization

	void Awake(){
		//Ron
		anim = GetComponent<Animator>();
		//End Ron
	}

	void Start () {
		//Ron
		runningHash = Animator.StringToHash("RunningBool");
		walkingHash = Animator.StringToHash("WalkingBool");
		roarhash = Animator.StringToHash("RoarTrigger");
		dieHash = Animator.StringToHash("DieTrigger");
		//End Ron
	}
	
	// Update is called once per frame
	void Update () {
		playerPos = player.transform.position;
		playerPos.y = transform.position.y;
		Vector3 targDir = playerPos - transform.position;
		//Vector3 newDir = new Vector3(0,0,0);

		if(!chargeFlag) {
			Invoke("charge",delay);
			chargeFlag = true;
		}
		if (normal) {

			Vector3 newDir = Vector3.RotateTowards(transform.forward, targDir, 120f*Time.deltaTime,0.0f);
			transform.rotation = Quaternion.LookRotation(newDir);

		}

		else if(charging) { 
			gameObject.transform.position = Vector3.MoveTowards(transform.position, target, (speed*5) * Time.deltaTime);
//			Vector3 newDir = Vector3.RotateTowards(transform.forward, targDir, 10f*Time.deltaTime,0.0f);
//			transform.rotation = Quaternion.LookRotation(newDir);
		}

		if(charging && transform.position.Equals(target)) {
			normalize();
		}





	}

	void OnTriggerEnter(Collider col) {
		if(col.tag.Equals("hazard")) {
			//put stuff here that kills the monster\
			Debug.Log("monster is dead");
			Destroy (gameObject);
			//monster gets hit by hazard
			//col.GetComponent<hazard>().invokeHazard();
		}
		else if(col.tag.Equals("Player")){
			//kill the player
			Debug.Log("the player is dead");
		}
	}

	void charge() {
		target = player.transform.position;
		target.y = transform.position.y;
		normal = false;
		charging = true;

		//Ron
		anim.SetBool(runningHash,true);
		anim.SetBool(walkingHash, false);
		//End Ron
	}

	void normalize() {
		charging = false;
		chargeFlag = false;
		//Ron
		anim.SetBool(runningHash,false);
		anim.SetBool(walkingHash, false);
		//End Ron
		Invoke ("setToNormal", 2);
	}

	void setToNormal() {
		normal = true;
		//Ron
		anim.SetBool(runningHash,false);
		anim.SetBool(walkingHash, true);
		//End Ron
	}
}
