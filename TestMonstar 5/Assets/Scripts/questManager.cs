using UnityEngine;
using System.Collections;

public class questManager : MonoBehaviour {
	bool[] quests;
	GameObject Jethro, Ezekiel, Abel, Caasi, Isaac;

	// Use this for initialization
	void Start () {

		DontDestroyOnLoad (gameObject); //Dont kill between scenes

	//Jethro Quest, Talk to Jethro, back to Jethro, man in woods, Ezekiel find, Monster, Warlock Find, Ingredients pickup, LifeEnergy
		bool JethroQuest = false, WardenQuest1 = false, WardenQuest2 = false, WardenQuest3 = false, WardenQuest4 = false, WardenQuest5 = false, WardenQuest6 = false, CaasiQuest1 = false, CaasiQuest2 = false;

		quests = new bool[] {JethroQuest, WardenQuest1, WardenQuest2, WardenQuest3, WardenQuest4, WardenQuest5, WardenQuest6, CaasiQuest1, CaasiQuest2};

	}
	
	// Update is called once per frame
	public void completeQuest(int index) {//flips quest status
		quests [index] = true;
	}

	public bool getQuestStatus(int index) {//gets quest status
		return quests [index];
	}

	void Update() {//manage all complete quests
		//if(Application.loadedLevel == 1 ) {
			//in the village
		Jethro = GameObject.Find ("Jethro");
			if(quests[0] == true && Application.loadedLevel == 1) {//Jethro quest finished
				Jethro.GetComponent<person>().setDialogueIndex(3);
			}
			// other quests
		//}
	}
}
