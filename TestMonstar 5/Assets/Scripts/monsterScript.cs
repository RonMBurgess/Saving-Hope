using UnityEngine;
using System.Collections;

public class monsterScript : MonoBehaviour {

	private Animator anim;
	private bool idle = true, walk, run;
	private Vector3 targetPos;
	private GameObject player;
	private int roarTrigger, chargeBool, walkBool, dieTrigger;

	public AudioClip[] demonSounds; //0 is roar, 1 & 2 are taunts
	private AudioSource aSource;
	public float movespeed = 5f, rotatespeed = 90f, chargeTime, walkTime, idleTime;
	private float chargeD, walkD, idleD;


	void Awake(){
		player = GameObject.FindGameObjectWithTag("Player");
		anim = GetComponent<Animator>();
		aSource = GetComponent<AudioSource>();
	}

	// Use this for initialization
	void Start () {
		chargeD = chargeTime;
		walkD = walkTime;
		idleD = idleTime;

		roarTrigger = Animator.StringToHash ("RoarTrigger");
		chargeBool = Animator.StringToHash("RunningBool");
		walkBool = Animator.StringToHash("WalkingBool");
		dieTrigger = Animator.StringToHash("DieTrigger");

	}
	
	// Update is called once per frame
	void Update () {
		targetPos = player.transform.position;
		targetPos.y = transform.position.y;


		facePlayer();
		if(run){
			Charge();
		}
		if(walk){
			Walk();
		}

		if(idle){
			idleD -= Time.deltaTime;
			if(idleD <= 0){
				idleD = idleTime;
				idle = false;
				walk = true;
				anim.SetBool(walkBool,true);
			}
		}
	}

	void facePlayer(){
		Vector3 targetDir = targetPos - transform.position;
		float rSpeed;
		if(run){
			rSpeed = rotatespeed /175f;
		}
		else{
			rSpeed = movespeed;
		}

		float step = rSpeed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		Debug.DrawRay(transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation(newDir);
	}

	void Charge(){
		chargeD -= Time.deltaTime;
		if(chargeD >= 0){
			GetComponent<Rigidbody>().velocity = transform.forward * movespeed * 4f;
		}
		else{
			GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
			run = false;
			chargeD = chargeTime;
			anim.SetBool(chargeBool,false);
			idle = true;
		}

	}

	void Walk(){
		walkD -= Time.deltaTime;
		if(walkD >=0){
			GetComponent<Rigidbody>().velocity = transform.forward * movespeed;
		}
		else{
			GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
			walk = false;
			walkD = walkTime;
			anim.SetBool (walkBool,false);
			anim.SetTrigger(roarTrigger);

		}

	}

	void DoneRoaring(){
		run = true;
		anim.SetBool(chargeBool,true);
	}

	void MakeSound(){
		//if(){
		aSource.clip = demonSounds[Random.Range(0,3)];
		//}
//		else{
		//aSource.clip = demonSounds[0];
//		}
		Debug.Log ("Playing sound");
		aSource.Play();
	}
}
