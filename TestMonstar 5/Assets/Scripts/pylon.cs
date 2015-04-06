using UnityEngine;
using System.Collections;

public class pylon : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col) {
		Debug.Log (col.gameObject.name);
		if (col.gameObject.name.Equals ("demon")) {
			Application.LoadLevel(0);
			//Kite demon into pylon, win game.
		}
	}
}
