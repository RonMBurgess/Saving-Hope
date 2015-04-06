using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class typewriter : MonoBehaviour {
	public float underloaf;
	private bool flagged;
	public int typeIncrement;
	public Text typedText;
	private string ph;

	void Start() {
		typedText.text = "";
		flagged = false;
	}
	

	public IEnumerator TypeWriter(string s, string n) {
		flagged = true;
		ph = "";
		Debug.Log ("asdf");
		//timeAnchor = Time.time;
		int index = 0;
		char[] a = s.ToCharArray ();

		for(int i = 0; i <a.Length; i++) {
			yield return new WaitForSeconds(underloaf);
			if(flagged) {
			ph+=a[i];
			GameObject.Find("GameGui").GetComponentInChildren<GameUIScript>().Name_And_Text(n,ph);
			}
		}
	}
	

}
