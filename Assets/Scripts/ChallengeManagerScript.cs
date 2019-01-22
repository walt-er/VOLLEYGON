using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeManagerScript : MonoBehaviour {

	public GameObject ballPrefab;

	// Store reference to challenge-level UI elements
	public GameObject winPanel;
	public GameObject losePanel;
	public GameObject instructionPanel;
	public GameObject challengeTitle;
	public GameObject challengeNumber;

	// Store a flag the individual challenge can reference to know whether to start or stop the challenge
	public bool challengeRunning = false;

	// Store a reference to the challenges container so we can activate the correct challenge
	public GameObject challengesContainer;

	// Static singleton property
	public static ChallengeManagerScript Instance { get; private set; }

	void Awake(){
		Instance = this;
		// Load the challenge the user requested
		Debug.Log("Switching to challenge " + DataManagerScript.challengeType);
		SwitchToChallenge(DataManagerScript.challengeType);

	}

	void Start () {
		// Display instruction panel
		DisplayChallengeInstructions();

		// For now, just hide the panel in 3 seconds
		Invoke("HideChallengeInstructions", 3f);
	}
	
	void Update () {
		
	}

	public void UpdateChallengeText(string newText){
		challengeTitle.GetComponent<Text>().text = newText;
		// TODO: Make a helper function to format the challenge number string
		challengeNumber.GetComponent<Text>().text = "CHALLENGE 0" + (DataManagerScript.challengeType + 1);
	}

	private void SwitchToChallenge(int whichChallenge){
		Transform challenge = challengesContainer.transform.GetChild (whichChallenge);
		challenge.gameObject.SetActive (true);
	}

	public void DisplayChallengeInstructions(){
		instructionPanel.SetActive(true);
	}

	public void HideChallengeInstructions(){
		instructionPanel.SetActive(false);
		challengeRunning = true;
	}

	public void ChallengeFail(){
		// Display fail text
		losePanel.SetActive(true);
		// For now, just exit the scene
		// Application.LoadLevel("TitleScene");
	}

	public void ChallengeSucceed(){

		// Display success text
		winPanel.SetActive(true);
		// For now, just exit the scene
		// Application.LoadLevel("TitleScene");

	}
}
