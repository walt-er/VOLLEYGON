using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeManagerScript : MonoBehaviour {

	public GameObject ballPrefab;

	// Store a reference to the challenges container so we can activate the correct challenge
	public GameObject challengesContainer;

	// Static singleton property
	public static ChallengeManagerScript Instance { get; private set; }

	void Awake(){
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		
		// Load the challenge the user requested
		Debug.Log("Switching to challenge " + DataManagerScript.challengeType);
		SwitchToChallenge(DataManagerScript.challengeType);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void SwitchToChallenge(int whichChallenge){
		Transform challenge = challengesContainer.transform.GetChild (whichChallenge);
		challenge.gameObject.SetActive (true);
	}

	public void DisplayChallengeInstructions(){

	}

	public void HideChallengeInstructions(){

	}

	public void ChallengeFail(){
		// For now, just exit the scene
		Application.LoadLevel("TitleScene");
	}

	public void ChallengeSucceed(){

	}
}
