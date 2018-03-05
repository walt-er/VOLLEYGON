using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeManagerScript : MonoBehaviour {

	public GameObject ballPrefab;
	// Static singleton property
	public static ChallengeManagerScript Instance { get; private set; }

	void Awake(){
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
