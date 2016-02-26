using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	public float gravTimer;
	public float gameTimer;
	private bool timerRunning = false;
	public int teamOneScore;
	public int teamTwoScore;
	public Text winText;
	public bool isGameOver;
	public int scorePlayedTo = 5;

	// Hold references to each of the players. Activate or de-activate them based on options chosen on the previous page. 
	public GameObject Player1;
	public GameObject Player2;
	public GameObject Player3;
	public GameObject Player4;

	// Static singleton property
	public static GameManagerScript Instance { get; private set; }


	// Use this for initialization
	void Start () {
		launchTimer ();
		winText.GetComponent<CanvasRenderer>().SetAlpha(0.0f);

		// Set up players and their rigidbodies based on character selection choice
		Player1.SetActive (false);
	
		// Set up arena based on options


	}
	void Awake()
	{
		// Save a reference to the AudioHandler component as our singleton instance
		Instance = this;
	}
	void launchTimer(){
		timerRunning = true;

	}

	void LaunchTitleScreen(){
		Application.LoadLevel ("titleScene");
	}
	void teamWins(int whichTeam){

		winText.text = "Team " + whichTeam.ToString () + " Wins!";
		winText.CrossFadeAlpha(1f,.25f,false);
		isGameOver = true;
		//DataManagerScript.dataManager.teamOneWins += 1;
		Invoke ("LaunchTitleScreen", 5f);
	}
	// Update is called once per frame
	void Update () {
		if (timerRunning) {
			gameTimer -= Time.deltaTime;
		}	

		if (teamOneScore >= scorePlayedTo) {
			Debug.Log ("Run team one wins routine here");
			teamWins (1);
		} else if (teamTwoScore >= scorePlayedTo){
			Debug.Log ("Run team two wins routine here");
			teamWins (2);
		}
	}
}
