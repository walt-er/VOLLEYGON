using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class OptionsManagerScript : MonoBehaviour {

	private int whichPlayerIsControlling;
	private JoystickButtons joyButts;

	public GameObject curtain;
	public EventSystem es;

	void Start () {
		curtain.SetActive(true);
		curtain.GetComponent<NewFadeScript>().Fade(0f);

		// determine which controller is 'in control'.
		whichPlayerIsControlling = DataManagerScript.gamepadControllingMenus;
		joyButts = new JoystickButtons (whichPlayerIsControlling);

		// Register axes from controller
		es.GetComponent<StandaloneInputModule> ().horizontalAxis = joyButts.horizontal;
		es.GetComponent<StandaloneInputModule> ().verticalAxis = joyButts.vertical;
		es.GetComponent<StandaloneInputModule> ().submitButton = joyButts.jump;
		es.GetComponent<StandaloneInputModule> ().cancelButton = joyButts.grav;

		//TODO: Will need to handle controller disconnects, etc.
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown(joyButts.grav)) {
			SceneManager.LoadSceneAsync ("titleScene");
		}

		// Check for cancel button to go to previous scene

	}
}
