using UnityEngine;
using System.Collections;

public class DataManagerScript : MonoBehaviour {

	public static DataManagerScript dataManager;

	public static string version; 
	public int teamOneWins;
	public int teamTwoWins;
	public static bool playerOnePlaying = true;
	public static bool playerTwoPlaying = true;
	public static bool playerThreePlaying = true;
	public static bool playerFourPlaying = true;


	public static int playerOneType;
	public static int playerTwoType;
	public static int playerThreeType;
	public static int playerFourType;
	public static int arenaType;

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



	void Awake(){
		if (dataManager == null) {
			DontDestroyOnLoad (gameObject);
			dataManager = this;
		} else if (dataManager != this){
			Destroy (gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		version = "V0.5";
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void ResetStats(){
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
