using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class OptionsManagerScript : MonoBehaviour {

	private int whichPlayerIsControlling;
	private JoystickButtons joyButts;

	public GameObject options;

	private int selectedIndex = 0;

	public GameObject curtain;
	private EventSystem es;

	void Start () {
		curtain.SetActive(true);
		curtain.GetComponent<NewFadeScript>().Fade(0f);

		es = EventSystem.current;
		if (es && es.currentSelectedGameObject) {
			selectedIndex = es.currentSelectedGameObject.transform.GetSiblingIndex();
		}

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

		// Show options based on carousel slide selected
		if (es.currentSelectedGameObject) {
			int selectedSlideIndex = es.currentSelectedGameObject.transform.GetSiblingIndex();
			if (selectedIndex != selectedSlideIndex) {
				SelectOption(selectedSlideIndex);
			}
		}
	}

	void SelectOption(int newIndex) {

		// Show new option
		Transform selectedOption = options.transform.GetChild(newIndex);
		foreach (Transform child in options.transform) {
			child.gameObject.SetActive(false);
		}
		selectedOption.gameObject.SetActive(true);

		// Save new index
		selectedIndex = newIndex;
	}
}
