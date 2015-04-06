using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameUIScript : MonoBehaviour {

	public GameObject scrn_Pause, scrn_Play, scrn_Main, pause_Menu, pause_Options, mm_Main, mm_Options, mm_Credits, blinker_Isaac, blinker_Abel, play_textPanel, mm_Loading;
	public Text Play_Name, Play_Text, Play_ObjectiveTip, pause_QuestTitle, pause_QuestInfo, pause_QuestTip;

	private AsyncOperation scene_loader;
	private bool playing, paused;
	private List<GameObject> mmScreens;
	public float dialogueDelay = 12f;//how long it takes for dialogue to disappear.
	private float dDelay;


	void Awake(){
		//dont destory the UI object, or it's parent, or any of it's children. 
		DontDestroyOnLoad(gameObject.transform.parent);
	}

	void OnLevelWasLoaded(int l){
		if(l == 1){
			MainMenu();
		}
		if(l == 2 ){
			PlayScreen();
			//test the indicator
			//TalkingIndicator(false);
			//StartCoroutine("LoadScene",3);

		}
		else if(l == 3){
			PlayScreen();
			//StartCoroutine("LoadScene",2);
		}
	}

	// Use this for initialization
	void Start () {
		dDelay = dialogueDelay;

		mmScreens = new List<GameObject>();
		mmScreens.Add (mm_Main);
		mmScreens.Add (mm_Credits);
		mmScreens.Add (mm_Options);

		//game starts on scene 0, where everything loads up. After everything has loaded, move to scene 1 which is the main menu.
		Application.LoadLevel(1);


	}
	
	// Update is called once per frame
	void Update () {
		if (playing && !paused)
		{
			dDelay -= Time.deltaTime;
			if(dDelay <= 0 && play_textPanel.activeInHierarchy){
				play_textPanel.SetActive(false);
				dDelay = dialogueDelay;
			}
			if (Input.GetKeyUp(KeyCode.Escape))
			{
				PauseGame();
			}
		}
		
		else if (Input.GetKeyUp(KeyCode.Escape))
		{
			if (playing && !paused)
			{
				PauseGame();
			}
			else if (playing && paused)
			{
				ResumeGame();
			}
		}


	}

	public void GUI_QuitOut(){
		Application.Quit();
	}

	public void GUI_Pause_Quit(){
        Time.timeScale = 1f;
		Application.LoadLevel(1);
	}

    //public void GUI_Resume(){
    //    scrn_Play.SetActive(false);
    //    scrn_Pause.SetActive(true);
    //}

	public void GUI_Pause_To_Options(){
		pause_Menu.SetActive(false);
		pause_Options.SetActive(true);
	}

	public void GUI_Back_To_Pause(){
		pause_Menu.SetActive(true);
		pause_Options.SetActive(false);
	}

	public void GUI_MainMenuTransition(string s){
		//start coroutine that fades in/out
		foreach(GameObject w in mmScreens){

			w.SetActive(false);
		}
		switch(s){
			case "Back": mm_Main.SetActive(true); break;
			case "Main": mm_Main.SetActive(true); break;
			case "Options": mm_Options.SetActive(true); break;
			case "Credits": mm_Credits.SetActive(true); break;
			case "Play": PlayGame(); break;
		}

	}

	private void MainMenu(){
		//StartCoroutine("LoadScene", 2);
		mm_Loading.SetActive (false);
		playing = false;
		paused = false;
		scrn_Main.SetActive(true);
		scrn_Pause.SetActive(false);
		scrn_Play.SetActive(false);

		GUI_MainMenuTransition("Main");

	}

	private void PlayScreen(){
		playing = true; paused = false;
		mm_Loading.SetActive (false);
		//turn blinkers off,
		scrn_Main.SetActive(false);
		scrn_Pause.SetActive (false);
		scrn_Play.SetActive(true);
	}

	private void PlayGame(){
		scrn_Main.SetActive(false);
		scrn_Pause.SetActive(false);
		scrn_Play.SetActive(false);
		mm_Loading.SetActive (true);
		Application.LoadLevel ("SceneOne");
	}

	public void Name_And_Text(string n, string t){
		if(playing && !paused){
			Play_Text.text = t;
			Play_Name.text = n;
			play_textPanel.SetActive(true);
			Play_Text.gameObject.SetActive(true);
			Play_Name.gameObject.SetActive(true);
		}
	}

	public void QuestInfo(string qName, string qInformation, string qTip){
		pause_QuestTitle.text = qName;
		pause_QuestInfo.text = qInformation;
		pause_QuestTip.text = qTip;
	}


	public void Quest_Objective(string a, string b = "", string c = ""){
		if(a != ""){
			Play_ObjectiveTip.text = "- " + a;
		}
		if(b != ""){
			Play_ObjectiveTip.text += "\n- " + b;
		}
		if(c != ""){
			Play_ObjectiveTip.text += "\n- " + c;
		}

		if(Play_ObjectiveTip.text != ""){
			Play_ObjectiveTip.transform.parent.gameObject.SetActive(true);
		}
		else{
			Play_ObjectiveTip.transform.parent.gameObject.SetActive(false);
		}
	}

//	private IEnumerator LoadScene(int s){
//		scene_loader = Application.LoadLevelAsync(s);
//		scene_loader.allowSceneActivation = false;
//		yield return scene_loader;
//		Debug.Log ("Loading is complete");

//	}

	private void PauseGame()
	{
		Time.timeScale = 0f;
		paused = true;
		
		scrn_Main.SetActive(false);
		scrn_Pause.SetActive(true);
		scrn_Play.SetActive(false);
	}
	
	public void ResumeGame()
	{
		Time.timeScale = 1.0f;
		paused = false;
		
		scrn_Main.SetActive(false);
		scrn_Pause.SetActive(false);
		scrn_Play.SetActive(true);
	}

	public void TalkingIndicator(bool isIsaac){
		StartCoroutine("Blinker",isIsaac);
	}

	private IEnumerator Blinker(bool isIsaac){
		blinker_Abel.SetActive (false);
		blinker_Isaac.SetActive(false);
		blinker_Isaac.transform.parent.gameObject.SetActive(true);

		GameObject blink;
		if(isIsaac){
			blink = blinker_Isaac;
		}
		else{
			blink = blinker_Abel;
		}

		blink.SetActive(true);
		for(int i = 0; i <= 50; i++){
			//blink.SetActive(!blink.activeInHierarchy);
			blink.GetComponent<Image>().CrossFadeAlpha(.75f,.05f,false);
			yield return new WaitForSeconds(.06f);
			blink.GetComponent<Image>().CrossFadeAlpha(0f,.05f,false);
			yield return new WaitForSeconds(.05f);
		}
		blink.SetActive(false);
		blink.transform.parent.gameObject.SetActive(false);
	}

}
