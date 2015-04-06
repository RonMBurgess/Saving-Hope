using UnityEngine;
using System.Collections;

public class questInteractable : MonoBehaviour {
	private bool interacting = false, flagged = false;
	public int questIndex;
	GameObject manager, Jethro, Isaac, Abel;
	// Use this for initialization
	void Awake() {
		manager = GameObject.Find ("Manager");
		Jethro = GameObject.Find ("Jethro");
		Isaac = GameObject.Find ("Isaac");
		Abel = GameObject.Find ("Abel");

	}
	void OnTriggerEnter(Collider col) {

		if (col.tag.Equals ("Player") && !flagged && manager.GetComponent<questManager>().getQuestStatus(questIndex) == false) {
			flagged = true;
			
			//Invoke("setFlagged", 5);
			interacting = true;
			Debug.Log ("triggering");
			//only for the first jethro quest, change for later.
			manager.GetComponent<questManager>().completeQuest((questIndex));
			manager.GetComponent<dialogue> ().startDialogue (new GameObject[]{Isaac, Abel, Isaac});//1 is "e" to interact

		}
		//manager.GetComponent<dialogue>().displayText(1, gameObject.name);//1 is "e" to interact

		//display pickup dialogue here

	}

	void setFlagged() {
		//flagged = false;
	}

	void Update() {
		if(interacting) {
			//manager.GetComponent<dialogue>().displayText(1);//1 is "e" to interact
			if(Input.GetKeyDown(KeyCode.E)) {
				Debug.Log("testing");
				//manager.GetComponent<dialogue>().displayText (0, gameObject.name);
				manager.GetComponent<questManager>().completeQuest(questIndex);
				Debug.Log(manager.GetComponent<questManager>().getQuestStatus(questIndex));
				//manager.GetComponent<dialogue>().displayText (2, gameObject.name);//for testing purposes only
			}
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.tag.Equals ("Player")) interacting = false;

		//manager.GetComponent<dialogue> ().displayText (0, gameObject.name);

	}
}
