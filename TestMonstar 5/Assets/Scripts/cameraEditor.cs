using UnityEngine;
using System.Collections;

public class cameraEditor : MonoBehaviour {
	public Camera mainCamera, cutSceneCamera;
	private Vector3 oldRotation, oldLocation, playerPosition;
	public float rotationSpeed, flipDelay, cameraAngle;
	public bool rotate, returnToOriginal, flipBetweenTwo, lookAt;
	public GameObject targetOne, targetTwo, player;
	private GameObject target;
	public int cutSceneDuration, camDistance;
	private bool flipped;
	//private bool onThingOne;
	// Use this for initialization
	void Start () {
		playerPosition = player.transform.position;
		flipped = false;
		cutSceneCamera.enabled = false;
		mainCamera.enabled = true;
		//onThingOne = true;
		//returnToOriginal = true;
		//rotate = false;
		target = targetOne;
		setCam ();
		PlayerPrefs.SetString ("cutscene", "initiated");
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		if(PlayerPrefs.GetString("cutscene").Equals("initiated")) {
			mainCamera.enabled = false;
			cutSceneCamera.enabled = true;

			//Debug.Log("got here");

			handleCutscene();
			Invoke("EndScene", cutSceneDuration);
		}
	}

	void handleCutscene() {
		if(returnToOriginal) {
			player.transform.position = playerPosition;
		}

		if(lookAt) {
			cutSceneCamera.transform.LookAt(target.transform);
		}
		
		if(!flipped && flipBetweenTwo) {
			Invoke("flipBetweenTwoThings", flipDelay);
			flipped = true;
		}
		
		if(rotate) {



			if(!flipBetweenTwo) {
				cutSceneCamera.transform.RotateAround(targetOne.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
			}
			else {
				cutSceneCamera.transform.RotateAround(target.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
			}

		}
	}
	void setCam() {
		Vector3 temp = target.transform.position;
		temp.z -= camDistance;
		temp.x -= camDistance;
		temp.y += cameraAngle;
		cutSceneCamera.transform.position = temp;
	}

	void flipBetweenTwoThings() {
		setCam();
		if (target == targetOne) {
			target = targetTwo;
		}
		else {
			target = targetOne;
		}

		flipped = false;

	}

	void EndScene() {
		PlayerPrefs.SetString ("cutscene", "off");
		cutSceneCamera.enabled = false;
		mainCamera.enabled = true;
	}
}
