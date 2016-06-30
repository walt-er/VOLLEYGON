using UnityEngine;
using System.Collections;

public class DataManagerScript : MonoBehaviour {

	public static DataManagerScript Instance { get; private set; }

	public static string version; 
	public int teamOneWins;
	public int teamTwoWins;
	public static bool playerOnePlaying = true;
	public static bool playerTwoPlaying = true;
	public static bool playerThreePlaying = true;
	public static bool playerFourPlaying = true;


	public int playerOneType;
	public int playerTwoType;
	public int playerThreeType;
	public int playerFourType;
	public int arenaType;

	// Player stats

	public static int playerOneAces;
	public static int playerOneReturns;
	public static int playerOneBumbles;
	public static int playerOneScores;

	public static int playerTwoAces;
	public static int playerTwoReturns;
	public static int playerTwoBumbles;
	public static int playerTwoScores;

	public static int playerThreeAces;
	public static int playerThreeReturns;
	public static int playerThreeBumbles;
	public static int playerThreeScores;

	public static int playerFourAces;
	public static int playerFourReturns;
	public static int playerFourBumbles;
	public static int playerFourScores;

	// Tournament mode variables
	public bool tournamentMode;
	public static int TM_TeamOneWins;
	public static int TM_TeamTwoWins;


	void Awake(){
		// First we check if there are any other instances conflicting
		if(Instance != null && Instance != this)
		{
			// If that is the case, we destroy other instances
			Destroy(gameObject);
		}

		// Here we save our singleton instance
		Instance = this;

		// Furthermore we make sure that we don't destroy between scenes (this is optional)
		DontDestroyOnLoad(gameObject);
	
	}
	// Use this for initialization
	void Start () {
		version = "V0.7";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetPlayerTypes(){
		playerOneType = 0;
		playerTwoType = 0;
		playerThreeType = 0;
		playerFourType = 0;

	}
	public void ResetStats(){
		 playerOneAces = 0;
		 playerOneReturns = 0;
		 playerOneBumbles = 0;
		 playerOneScores = 0;

		 playerTwoAces = 0;
		 playerTwoReturns = 0;
		 playerTwoBumbles = 0;
		 playerTwoScores = 0;

		 playerThreeAces = 0;
		 playerThreeReturns = 0;
		 playerThreeBumbles = 0;
		 playerThreeScores = 0;

		 playerFourAces = 0;
		 playerFourReturns = 0;
		 playerFourBumbles = 0;
		 playerFourScores = 0;
	}
		
}
