using UnityEngine;
using System.Collections;

public class dontKillMePLox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		if(GameObject.FindGameObjectsWithTag("GameController").Length > 1) {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
