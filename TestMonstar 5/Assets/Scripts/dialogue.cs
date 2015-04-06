using UnityEngine;
using System.Collections;

public class dialogue : MonoBehaviour {
	GameObject player, Jethro = GameObject.Find("Jethro"), Isaac = GameObject.Find("Isaac"),Abel = GameObject.Find("Abel");
	// Use this for initialization
	AudioClip[] audio;
	string[] text;
    private bool inDialogue = false;
    GameObject[] talkers, temp;
	private int index, t = 0;

	void Start () {
		Debug.Log("before time: " + Time.time.ToString());
		//StartCoroutine("delayTime");
		Debug.Log("after time: " +  Time.time.ToString());
        talkers = new GameObject[] { Abel, Isaac, Jethro };
		text = new string[] {
            "",
            //Abel below
			"Isaac, go talk to Jethro. He informed me sometime last night that he saw something strange in the woods.",
            "Isaac, Ive seen this kind of rock before. Either someone is preparing to summon something, or it's already been summoned",
            "Isaac, I need you to go back to the woods. The man I sent out has not returned and has been out of communication for a while now. Go find him.",
            "static It's a shame he's dead. Now I won't be able to help his family, and they'll have to leave.",
            "Because he had a deal with me Isaac. I help him and his family but only if he helps me. I have the same deal with you. If you are somehow unable to continue assisting me, I will no longer be able to assist your daughter. I'd hate for that to happen. Possession is a terrible way to go.",
            "I think this may have something to do with that ritual stone we saw earlier, come back to the village and speak to Ezekiel. He's seen some things, and some stuff...",
            "You heard him Isaac. Stop wasting time. You need to handle this NOW. If anything happens because of this, I may not be able to continue helping you and your daughter.",
            
            //Isaac Below
			"Why does he make me do this? I'm not stupid...",
			"I've never seen a rock glow before. And that writing, I wonder what it means.",
           // "I can't read this, I'm illiterate",
           // "It's still warm. Someone must have been here recently",
            "It feels like the rock is pulling me in, trying to take something from me.",
            
            "Dry heaving I hate blood.",
            "I should go back to the village and tell Jethro what I found. If not, the warden won't be happy.",
            "Hey Jethro... There was some kind of ritual going on. The warden knows and has sent someone to learn more.",
            "I wonder where he could be...",
            "He doesn't seem to be over here. I should probably look somewhere else.",
            "Wait, why do they have to leave? Why can't you help them?",
            "He cant be serious can he?",
            "So what do you think is going on Ezekiel?",
            "So what does that mean?",
            "thinking Oh great... Hope and I are in this situation because of a warlock and we were just bystanders... maybe Ezekiel can offer some help.",
            "Ezekiel, do you have any tips for dealing with this warlock?",
            "Oh great, that's.. thank you Ezekiel",

            
            //End Isaac

            //Jethro 24
            "Well hello there Isaac. I'm glad to see you. I saw a strange glowing rock while I was in the woods yesterday. Please check it out, be careful though. People have been disappearing.",
			"Thanks",
            "Thank you very much Isaac. I'm so glad that you're hear with us now.",
            //End Jethro
			
            //Ezekiel
            "Hello Isaac... the Captain told me about the situation. I have seen so many things, and so much stuff, that it makes sense you would come to me for help.",
            "wheezing The recent disappearances were suspicious, but gave me nothing to go on. The ritual stone and body with missing limbs you found provided the greatest insight to our current situation.", 
            "We are dealing with a warlock, most likely of the necromantic persuasion. And based on how hastily the limbs were removed from that body, and the fact it did not simply disappear like the others, means that this warlock has finished their preparations.",
            "Well Isaac, the basic guidelines for necromancy are duration and proximity. Things brought to life from necromancy cannot travel far from their summoned location and they do not last very long. That leads me to believe we are the targets of this upcoming attack. You need to find this warlock now and put an end to him before they finish their ritual.",
            "Yes, warlocks are tricky, and you can't trust them.",

            
            //End Ezekiel
			"this is the fourth dialogue",
			"this is the fifth dialogue",
			"this is the sixth dialogue",
			"this is the seventh dialogue",
			"this is the eigth dialogue",
			"this is the ninth dialogue",
			"this is the tenth dialogue",
			"this is the eleventh dialogue",
			//39
			"Prepare for a demo boss battle!"

		};
	}
	
	// Update is called once per frame
	void Update() {
		Jethro = GameObject.Find ("Jethro");
		Isaac = GameObject.Find ("Isaac");
		Abel = GameObject.Find ("Abel");

		player = GameObject.Find ("First Person Controller");
        if (inDialogue)
        {
            Talk(talkers);
        }
	}

    void Talk(GameObject[] temp)
    {
				
        //bool flagged = false;
	
		for (int i = 0; i < temp.Length; i++) {
            Debug.Log(temp[i].name);
			Invoke("dialogue" + temp[i].name, t);
			t = t+10;
		}     
       
        inDialogue = false;
    }

    public void startDialogue(GameObject[] dialoguers)
    {
		t = 0;
		
        talkers = dialoguers;
        inDialogue = true;
    }

	private void dialogueIsaac() {
		displayText (Isaac.GetComponent<person> ().getDialogueIndex (), "Isaac");
		Isaac.GetComponent<person> ().setDialogueIndex (Isaac.GetComponent<person> ().getDialogueIndex() + 1);
	}

	private void dialogueAbel() {
		displayText (Abel.GetComponent<person> ().getDialogueIndex (), "Abel");
		Abel.GetComponent<person> ().setDialogueIndex (Abel.GetComponent<person> ().getDialogueIndex() + 1);
	}

	private void dialogueJethro() {
		displayText (Jethro.GetComponent<person> ().getDialogueIndex (), "Jethro");
		Jethro.GetComponent<person> ().setDialogueIndex (Jethro.GetComponent<person> ().getDialogueIndex() + 1);
	}


	public void displayText(int index, string name) {
		StopAllCoroutines();
		StartCoroutine(gameObject.GetComponent<typewriter> ().TypeWriter (text [index], name));
	}

	

	

}
