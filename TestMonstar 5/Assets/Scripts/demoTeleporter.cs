using UnityEngine;
using System.Collections;

public class demoTeleporter : MonoBehaviour {
	bool textDisplayed = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		if(col.tag.Equals("Player")) {
			Debug.Log("test working");
			Invoke ("demoText", 27);
			Invoke ("demoTele", 32);
			textDisplayed = true;
		}
	}

	void demoTele() {
			Application.LoadLevel (4);
	}
	
	void demoText() {
		if(!textDisplayed) {

			GameObject.Find ("Manager").GetComponent<dialogue> ().displayText (39, "Admin");
		}
	}
}
