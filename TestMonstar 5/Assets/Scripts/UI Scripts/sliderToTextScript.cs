using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sliderToTextScript : MonoBehaviour {

	public Text t;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setText(Slider s){
		t.text = Mathf.RoundToInt(s.value * 100f).ToString() + "%";
		//t.text = s.value.ToString("F2") + "%";
	}
}
