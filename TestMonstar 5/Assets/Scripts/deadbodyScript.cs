using UnityEngine;
using System.Collections;

public class deadbodyScript : MonoBehaviour {

	GameObject abel = GameObject.Find ("Abel"), isaac = GameObject.Find ("Isaac"), gm = GameObject.Find ("Manager");

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c){
		//if(c.tag.Equals("Player")){
			Debug.Log("I AM A DEAD BODY");
			gm.GetComponent<dialogue>().startDialogue(new GameObject[] {abel,isaac,abel,isaac,abel});
		//}
	}
}
