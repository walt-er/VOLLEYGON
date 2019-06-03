using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class OptionsManagerScript : MonoBehaviour {

	private int whichPlayerIsControlling;
	private JoystickButtons joyButts;

	public GameObject curtain;
	private EventSystem es;

	void Start () {
		curtain.SetActive(true);
		curtain.GetComponent<NewFadeScript>().Fade(0f);

		es = EventSystem.current;

		// determine which controller is 'in control'.
		whichPlayerIsControlling = DataManagerScript.gamepadControllingMenus;
		joyButts = new JoystickButtons (whichPlayerIsControlling);
	}

	// Update is called once per frame
	void Update () {
		// Check for cancel button to go to previous scene
		if (Input.GetButtonDown(joyButts.grav)) {
			SceneManager.LoadSceneAsync ("titleScene");
		}
	}
}
