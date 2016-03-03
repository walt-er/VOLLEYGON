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
	public int arenaType;
	private float timeSinceLastPowerup;
	private float powerupAppearTime; 
	public GameObject powerupPrefab;

	// Hold references to each of the players. Activate or de-activate them based on options chosen on the previous page. 
	public GameObject Player1;
	public GameObject Player2;
	public GameObject Player3;
	public GameObject Player4;

	// Hold references to each of the arenas
	public GameObject Arena1;
	public GameObject Arena2;
	public GameObject Arena3;
	public GameObject Arena4;


	// Static singleton property
	public static GameManagerScript Instance { get; private set; }


	// Use this for initialization
	void Start () {
		launchTimer ();
		timeSinceLastPowerup = 0f;
		powerupAppearTime = 10f;
		winText.GetComponent<CanvasRenderer>().SetAlpha(0.0f);

		// Set up players and their rigidbodies based on character selection choice
	//	Player1.SetActive (false);


		// Set up arena based on options
		arenaType = DataManagerScript.arenaType;

		switch (arenaType) {

		case 0:
			Arena1.SetActive (true);
			break;

		case 1:
			Arena2.SetActive (true);
			break;

		case 2:
			Arena3.SetActive (true);
			break;

		case 3:
			Arena4.SetActive (true);
			break;

		default:
			Arena1.SetActive (true);
			break;

		}

	}
	void Awake()
	{
		// Save a reference to the AudioHandler component as our singleton instance
		Instance = this;

		Player1.GetComponent<PlayerController>().playerType = DataManagerScript.playerOneType;
		Player2.GetComponent<PlayerController>().playerType = DataManagerScript.playerTwoType;
		Player3.GetComponent<PlayerController>().playerType = DataManagerScript.playerThreeType;
		Player4.GetComponent<PlayerController>().playerType = DataManagerScript.playerFourType;
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

		timeSinceLastPowerup += Time.deltaTime;

		if (timerRunning) {
			gameTimer -= Time.deltaTime;
		}	

		if (teamOneScore >= scorePlayedTo) {
			//Debug.Log ("Run team one wins routine here");
			teamWins (1);
		} else if (teamTwoScore >= scorePlayedTo){
		//	Debug.Log ("Run team two wins routine here");
			teamWins (2);
		}

		if (!isGameOver) {
			ConsiderAPowerup ();
		}
	}

	void ConsiderAPowerup(){
		if (timeSinceLastPowerup >= powerupAppearTime) {

			// spawn a powerup
			Instantiate(powerupPrefab, new Vector3(Random.Range(-17f, 17f), Random.Range(-5f,5f), 0), Quaternion.identity);
			timeSinceLastPowerup = 0f;
			powerupAppearTime = 10f + Random.value * 20f;
		}
	}
}
