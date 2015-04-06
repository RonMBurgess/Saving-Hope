using UnityEngine;
using System.Collections;

public class person : MonoBehaviour {
	public int questIndex;
	public int dialogueIndex;
	GameObject manager;
	void Start() {
		manager = GameObject.Find ("Manager");
	}
	public int getQuestIndex() {
		return questIndex;
	}
	public int getDialogueIndex() {
		return dialogueIndex;
	}
	public void setQuestIndex(int i) {
		questIndex = i;
	}
	public void setDialogueIndex(int i) {
		dialogueIndex = i;
	}

	void OnTriggerEnter(Collider col) {
		if(col.tag.Equals("Player")) {
			Debug.Log(dialogueIndex);
			manager.GetComponent<dialogue>().displayText(dialogueIndex, gameObject.name);
            if (manager.GetComponent<questManager>().getQuestStatus(questIndex)) { dialogueIndex++; };
		}
						
	}

	void OnTriggerExit(Collider col) {
		if(col.tag.Equals("Player")) {
			StopAllCoroutines();
			//manager.GetComponent<dialogue>().displayText(0, "");// 0 is blank text;

		}
	}
}
