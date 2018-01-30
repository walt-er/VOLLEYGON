using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

using Users;

public class TitleManagerScript : MonoBehaviour {

	private JoystickButtons controllingGamepad;
	private JoystickButtons[] gamepads = new JoystickButtons[4];

	public Text versionText;
	public GameObject mainMenuPanel;
	public GameObject singlePlayerPanel;
	public GameObject soloModeButton;

	private bool mainMenuActive = false;

	public EventSystem es1;

	public Button firstButton;


	// Use this for initialization
	void Start () {
		MusicManagerScript.Instance.FadeOutEverything ();
		versionText.text = DataManagerScript.version;
		DataManagerScript.ResetStats ();
		DataManagerScript.ResetPlayerTypes ();
		DataManagerScript.isChallengeMode = false;

		// Init controller maps
		for (int i = 0; i < 4; i++) {
			gamepads[i] = new JoystickButtons(i+1);
		}

		//Cursor.visible = false;
		//Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () {
		MusicManagerScript.Instance.FadeOutEverything ();

		// Iterate over all inputs for actions
		for (int i = 0; i < gamepads.Length; i++) {

            // Listen for activation
            if (!mainMenuActive) {

				if (
					Input.GetButtonDown (gamepads[i].jump)
					|| Input.GetButtonDown (gamepads[i].grav)
					|| Input.GetButtonDown (gamepads[i].start)
				) {

					// Xbox numbering from 1
					int gamepadIndex = i + 1;

					#if UNITY_XBOXONE

						// Trigger Xbox signin
						if (XboxOneInput.GetUserIdForGamepad((uint)gamepadIndex) == 0) {
							DataManagerScript.shouldActivateMenu = true;
							UsersManager.RequestSignIn(Users.AccountPickerOptions.None, (ulong)gamepadIndex);
						}

					#endif

                    // Open main menu
                    activateMainMenu(gamepadIndex);
				}
			}
			else {

				#if UNITY_XBOXONE
					// Listen for user change (Y button)
					if (Input.GetButtonDown (controllingGamepad.y)) {

						// Xbox numbering from 1
						int gamepadIndex = i + 1;

						// Back out and log in again if active player presses Y
						if (gamepadIndex == DataManagerScript.gamepadControllingMenus) {
							cancelCurrentMenu(true);
							DataManagerScript.shouldActivateMenu = true;
							UsersManager.RequestSignIn(Users.AccountPickerOptions.None, (ulong)gamepadIndex);
						}
					}
				#endif

				// Listen for cancel
				if (controllingGamepad != null &&  Input.GetButtonDown (controllingGamepad.grav)) {
					cancelCurrentMenu(false);
				}
			}
		}
	}

	void cancelCurrentMenu(bool cancelAll) {
		if (!singlePlayerPanel.activeSelf || cancelAll) {
			// Canceling out of main menu
			mainMenuActive = false;
			mainMenuPanel.SetActive (false);
			singlePlayerPanel.SetActive (false);
		} else {
			// Cancelling out of single player menu
			es1.SetSelectedGameObject(null);
			es1.SetSelectedGameObject(es1.firstSelectedGameObject);
			singlePlayerPanel.SetActive (false);
			mainMenuPanel.SetActive (true);
		}
	}

	public void activateMainMenu(int gamepad) {

		// Addign gamepad to menus
		DataManagerScript.gamepadControllingMenus = gamepad;

		// Save "active" user if on xbox
		#if UNITY_XBOXONE
			int userId = XboxOneInput.GetUserIdForGamepad((uint)gamepad);
			DataManagerScript.userControllingMenus = UsersManager.FindUserById(userId);
		#endif

		// activate menu and its first button (weird ui thing)
		mainMenuActive = true;
		mainMenuPanel.SetActive (true);
		es1.SetSelectedGameObject(null);
		es1.SetSelectedGameObject(es1.firstSelectedGameObject);

		// depending on which controller was tagged in, set the input stringes here
		controllingGamepad = new JoystickButtons (gamepad);
		es1.GetComponent<StandaloneInputModule> ().horizontalAxis = controllingGamepad.horizontal;
		es1.GetComponent<StandaloneInputModule> ().verticalAxis = controllingGamepad.vertical;
		es1.GetComponent<StandaloneInputModule> ().submitButton = controllingGamepad.jump;
		es1.GetComponent<StandaloneInputModule> ().cancelButton = controllingGamepad.grav;
	}

	public void SetUpSinglePlayerMenu (){
		es1.SetSelectedGameObject(soloModeButton);
	}
	public void StartMultiplayerGame(){
		SceneManager.LoadSceneAsync ("ChoosePlayerScene");
	}
	public void StartChallengesGame(){
		DataManagerScript.isChallengeMode = true;
		SceneManager.LoadSceneAsync ("ChooseChallengeScene");

	}
	public void StartOptionsMenu(){
		SceneManager.LoadSceneAsync ("OptionsScene");
	}
}
