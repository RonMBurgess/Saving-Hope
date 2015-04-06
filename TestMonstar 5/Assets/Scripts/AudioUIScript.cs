using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioUIScript : MonoBehaviour {

	private Image flasher;
	private Color col_flash, col_invis;
	private AudioSource a_source;

	void Awake(){
		a_source = GetComponent<AudioSource>();
		if(a_source == null){
			Debug.LogWarning("Could not find audiosource");
		}

		flasher = GetComponent<Image>();
	}

	// Use this for initialization
	void Start () {
		col_flash = flasher.color;
		col_invis = new Color(col_flash.r,col_flash.g,col_flash.b,0f);
		//flasher.enabled = false;
		flasher.CrossFadeColor(col_invis,1f,false,true);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
