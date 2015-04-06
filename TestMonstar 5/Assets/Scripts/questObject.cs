using UnityEngine;
using System.Collections;

public class questObject : MonoBehaviour {
	//private bool interacting = false;
	public int questIndex;
	GameObject manager;
	// Use this for initialization
	void Awake() {
		manager = GameObject.Find ("Manager");
	}
	void OnTriggerEnter(Collider col) {
		//Debug.Log ("triggering");
		//if (col.tag.Equals ("Player")) interacting = true;
		manager.GetComponent<dialogue>().displayText(1, gameObject.name);//1 is "e" to interact
		manager.GetComponent<questManager> ().completeQuest (questIndex);
		//finish according quest ^^

		Destroy (gameObject);
	}
}
