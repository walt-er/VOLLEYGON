using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class OptionsManagerScript : MonoBehaviour {

	public GameObject curtain;
	public CarouselScript carousel;
	public GameObject options;
	public GameObject breadcrumb;
	public GameObject optionBreadcrumb;

	private int whichPlayerIsControlling;
	private JoystickButtons joyButts;

	private int selectedIndex = 0;
	private bool optionIsOpen = false;

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
		// Show options based on carousel slide selected
		if (es.currentSelectedGameObject) {
			int selectedSlideIndex = es.currentSelectedGameObject.transform.GetSiblingIndex();
			if (selectedIndex != selectedSlideIndex) {
				SelectOption(selectedSlideIndex);
			}
		}

		// Check for cancel button
		if (Input.GetButtonDown(joyButts.grav)) {

			// Show/hide breadcrumbs
			optionBreadcrumb.SetActive(false);
			breadcrumb.SetActive(true);

			if (optionIsOpen) {
				// Go back to carousel controls
				optionIsOpen = false;
			}
			else {
				// Go to previous scene
				SceneManager.LoadSceneAsync ("titleScene");
			}
		}

		// Check for selection to enable option

		if (Input.GetButtonDown(joyButts.jump)) {

			// Show/hide breadcrumbs
			optionBreadcrumb.SetActive(true);
			breadcrumb.SetActive(false);

			optionIsOpen = true;
		}

		// Disable carousel when we have an option open
		es.enabled = !optionIsOpen;
		if (es.enabled) {
			// Reset selected item on re-enable
			es.SetSelectedGameObject(carousel.slides[selectedIndex].gameObject);
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
