using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using Users;

public class TitleManagerScript : MonoBehaviour {

	private JoystickButtons joyButts;
	private JoystickButtons[] gamepads = new JoystickButtons[4];

	private int player = 1;

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

		// Listen for activation
		if (!mainMenuActive) {
			for (int i = 0; i < gamepads.Length; i++) {

				if (Input.GetButtonDown (gamepads[i].jump) || Input.GetButtonDown (gamepads[i].start)) {

					// If the main menu isn't activated, start process of logging in
					ulong id = (ulong)(i + 1);
					if (DataManagerScript.xboxMode) {
 						UsersManager.RequestSignIn(Users.AccountPickerOptions.AllowGuests, id);
 					}

 					// Open main menu
					activateMainMenu(i + 1);
				}
			}
		}

		// Listen for cancel
		if (joyButts != null &&  Input.GetButtonDown (joyButts.grav)) {
			// cancel was pressed
			if (mainMenuActive && !singlePlayerPanel.active) {
				// Canceling out of main menu
				mainMenuActive = false;
				mainMenuPanel.SetActive (false);
			} else if (singlePlayerPanel.active) {
				// Cancelling out of single player menu
				es1.SetSelectedGameObject(null);
				es1.SetSelectedGameObject(es1.firstSelectedGameObject);
				singlePlayerPanel.SetActive (false);
				mainMenuPanel.SetActive (true);
			}
		}
	}

	void activateMainMenu(int player) {
		mainMenuActive = true;
		mainMenuPanel.SetActive (true);

		//activate first button (weird ui thing)
		//firstButton.Select();
		es1.SetSelectedGameObject(null);
		es1.SetSelectedGameObject(es1.firstSelectedGameObject);

		// depending on which controller was tagged in, set the input stringes here
		joyButts = new JoystickButtons (player);
		es1.GetComponent<StandaloneInputModule> ().horizontalAxis = joyButts.horizontal;
		es1.GetComponent<StandaloneInputModule> ().verticalAxis = joyButts.vertical;
		es1.GetComponent<StandaloneInputModule> ().submitButton = joyButts.jump;
		es1.GetComponent<StandaloneInputModule> ().cancelButton = joyButts.grav;
	}

	public void SetUpSinglePlayerMenu (){
		es1.SetSelectedGameObject(soloModeButton);
	}
	public void StartMultiplayerGame(){
		Application.LoadLevel ("ChoosePlayerScene");
	}
	public void StartChallengesGame(){
		DataManagerScript.playerControllingMenus = player;
		DataManagerScript.isChallengeMode = true;
		Application.LoadLevel ("ChooseChallengeScene");

	}
	public void StartOptionsMenu(){
		DataManagerScript.playerControllingMenus = player;
		Application.LoadLevel ("OptionsScene");
	}
}
