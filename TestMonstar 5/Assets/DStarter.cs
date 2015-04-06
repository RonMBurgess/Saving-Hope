using UnityEngine;
using System.Collections;

public class DStarter : MonoBehaviour {

   // public dialogue d;
    GameObject gm; 
    GameObject Isaac, Abel;
    GameObject[] dialoguers;
    bool started = false;
    int frames;

    void Awake()
    {
       
    }

	// Use this for initialization
	void Start () {
           
       /// manager.GetComponent<dialogue>().startDialogue(new GameObject[] { Abel, Isaac });
	}
	
	// Update is called once per frame
	void Update () {
             gm = GameObject.Find("Manager");
            Isaac = GameObject.Find("Isaac");
            Abel = GameObject.Find("Abel");
            dialoguers = new GameObject[] { Abel, Isaac };
        frames++;
        if (frames % 30 == 0 && !started)
        {
            for (int i = 0; i < dialoguers.Length; i++ )
            {
                Debug.Log("PRINTED");
                Debug.Log(dialoguers[i].name);
            }
            gm.GetComponent<dialogue>().startDialogue(dialoguers);
            started = true;
        }
	}
}
