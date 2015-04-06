using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ProfileDataScript : MonoBehaviour {

	public bool resetText;

	public Text nameBox, databox;
	public string name_profile, data, staticText;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SwitchData(){
		nameBox.text = name_profile;
		databox.text = data;
	}

	void OnEnable(){
		if(resetText){
			gameObject.GetComponent<Text>().text = staticText;
		}
	}
}
