using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class StatManagerScript : MonoBehaviour {

	public Text player1Aces;
	public Text player2Aces;
	public Text player3Aces;
	public Text player4Aces;

	public Text player1Scores;
	public Text player2Scores;
	public Text player3Scores;
	public Text player4Scores;

	public Text player1Returns;
	public Text player2Returns;
	public Text player3Returns;
	public Text player4Returns;

	public Text player1Bumbles;
	public Text player2Bumbles;
	public Text player3Bumbles;
	public Text player4Bumbles;

	public Text player1Labels;
	public Text player2Labels;
	public Text player3Labels;
	public Text player4Labels;

	public Text player1Title;
	public Text player2Title;
	public Text player3Title;
	public Text player4Title;

	public Text Player1MVP;
	public Text Player2MVP;
	public Text Player3MVP;
	public Text Player4MVP;

	//private int[] aces = { 1, 2, 3, 4, 5, 6, 7 };
	public int[] aces;
	private int[] scores;
	private int[] returns;
	private int[] bumbles;

	public int playersPlaying = 0;
	public int playersReady = 0;

	private float scoreWeight = 1f;
	private float aceWeight = 1f;
	private float returnWeight = .25f;
	private float bumbleWeight = .5f;

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;


//	nums.Max(); // Will result in 7
//	nums.Min(); // Will result in 1

	public static StatManagerScript Instance { get; private set; }
	// Use this for initialization

	void Awake(){
		Instance = this;
	}

	void Start () {

		Player1MVP.GetComponent<CanvasRenderer> ().SetAlpha (0f);
		Player2MVP.GetComponent<CanvasRenderer> ().SetAlpha (0f);
		Player3MVP.GetComponent<CanvasRenderer> ().SetAlpha (0f);
		Player4MVP.GetComponent<CanvasRenderer> ().SetAlpha (0f);

		PopulateStats ();

		// Determine how many players are playing.
		if (DataManagerScript.playerOnePlaying) {
			playersPlaying++; 
		}
		if (DataManagerScript.playerTwoPlaying) {
			playersPlaying++; 
		}
		if (DataManagerScript.playerThreePlaying) {
			playersPlaying++; 
		}
		if (DataManagerScript.playerFourPlaying) {
			playersPlaying++; 
		}

		Invoke ("BackToTitle", 30f);

	}
	
	// Update is called once per frame

	void Update () {
		if (playersReady == playersPlaying) {
			BackToTitle ();
		}
	}

	public void CheckStartable(){
		
	}

	public void increasePlayerReady(){
		playersReady++;

	}

	public void decreasePlayerReady(){
		playersReady--;
	}

	void DetermineMVP(){
		float p1Score = DataManagerScript.playerOneAces * aceWeight + DataManagerScript.playerOneScores * scoreWeight + DataManagerScript.playerOneReturns * returnWeight - DataManagerScript.playerOneBumbles * bumbleWeight; 
		float p2Score = DataManagerScript.playerTwoAces * aceWeight + DataManagerScript.playerTwoScores * scoreWeight + DataManagerScript.playerTwoReturns * returnWeight - DataManagerScript.playerTwoBumbles * bumbleWeight; 
		float p3Score = DataManagerScript.playerThreeAces * aceWeight + DataManagerScript.playerThreeScores * scoreWeight + DataManagerScript.playerThreeReturns * returnWeight - DataManagerScript.playerThreeBumbles * bumbleWeight; 
		float p4Score = DataManagerScript.playerFourAces * aceWeight + DataManagerScript.playerFourScores * scoreWeight + DataManagerScript.playerFourReturns * returnWeight - DataManagerScript.playerFourBumbles * bumbleWeight; 
	
		float[] scores = { p1Score, p2Score, p3Score, p4Score };

		if (p1Score == scores.Max ()) {
			activateMVP (1);
		}

		if (p2Score == scores.Max ()) {
			activateMVP (2);
		}

		if (p3Score == scores.Max ()) {
			activateMVP (3);
		}

		if (p4Score == scores.Max ()) {
			activateMVP (4);
		}
	}

	void activateMVP(int whichPlayer){
		switch (whichPlayer) {
		case 1:
			Player1MVP.GetComponent<CanvasRenderer> ().SetAlpha (1.0f);
			break;
		case 2:
			Player2MVP.GetComponent<CanvasRenderer> ().SetAlpha (1.0f);
			break;
		case 3:
			Player3MVP.GetComponent<CanvasRenderer> ().SetAlpha (1.0f);
			break;
		case 4:
			Player4MVP.GetComponent<CanvasRenderer> ().SetAlpha (1.0f);
			break;

		}
	}

	void BackToTitle(){
		Application.LoadLevel ("titleScene");
	}

	void PopulateStats(){

		int[] aces = {
			DataManagerScript.playerOneAces,
			DataManagerScript.playerTwoAces,
			DataManagerScript.playerThreeAces,
			DataManagerScript.playerFourAces
		};

		int[] scores = {
			DataManagerScript.playerOneScores,
			DataManagerScript.playerTwoScores,
			DataManagerScript.playerThreeScores,
			DataManagerScript.playerFourScores
		};

		int[] returns = {
			DataManagerScript.playerOneReturns,
			DataManagerScript.playerTwoReturns,
			DataManagerScript.playerThreeReturns,
			DataManagerScript.playerFourReturns
		};

		int[] bumbles = {
			DataManagerScript.playerOneBumbles,
			DataManagerScript.playerTwoBumbles,
			DataManagerScript.playerThreeBumbles,
			DataManagerScript.playerFourBumbles
		};


		// if player active...
		if (DataManagerScript.playerOnePlaying) {
			player1Aces.text = DataManagerScript.playerOneAces.ToString (); 
			player1Scores.text = DataManagerScript.playerOneScores.ToString ();
			player1Returns.text = DataManagerScript.playerOneReturns.ToString ();
			player1Bumbles.text = DataManagerScript.playerOneBumbles.ToString ();

			if (DataManagerScript.playerOneAces == aces.Max()){
				player1Aces.color = new Color (0f, 1f, 0f, 1f);
			}

			if (DataManagerScript.playerOneReturns == returns.Max()){
				player1Returns.color = new Color (0f, 1f, 0f, 1f);
			}

			if (DataManagerScript.playerOneScores == scores.Max()){
				player1Scores.color = new Color (0f, 1f, 0f, 1f);
			}

			if (DataManagerScript.playerOneBumbles == bumbles.Max()){
				player1Bumbles.color = new Color (1f, 0f, 0f, 1f);
			}

		} else {
			player1Title.enabled = false; 
			player1Labels.enabled = false;
		}

		if (DataManagerScript.playerTwoPlaying) {
			player2Aces.text = DataManagerScript.playerTwoAces.ToString (); 
			player2Scores.text = DataManagerScript.playerTwoScores.ToString ();
			player2Returns.text = DataManagerScript.playerTwoReturns.ToString ();
			player2Bumbles.text = DataManagerScript.playerTwoBumbles.ToString ();

			if (DataManagerScript.playerTwoAces == aces.Max()){
				player2Aces.color = new Color (0f, 1f, 0f, 1f);
			}

			if (DataManagerScript.playerTwoReturns == returns.Max()){
				player2Returns.color = new Color (0f, 1f, 0f, 1f);
			}

			if (DataManagerScript.playerTwoScores == scores.Max()){
				player2Scores.color = new Color (0f, 1f, 0f, 1f);
			}

			if (DataManagerScript.playerTwoBumbles == bumbles.Max()){
				player2Bumbles.color = new Color (1f, 0f, 0f, 1f);
			}

		} else {
			player2Title.enabled = false; 
			player2Labels.enabled = false;
		}

		if (DataManagerScript.playerThreePlaying) {
			player3Aces.text = DataManagerScript.playerThreeAces.ToString (); 
			player3Scores.text = DataManagerScript.playerThreeScores.ToString ();
			player3Returns.text = DataManagerScript.playerThreeReturns.ToString ();
			player3Bumbles.text = DataManagerScript.playerThreeBumbles.ToString ();

			if (DataManagerScript.playerThreeAces == aces.Max()){
				player3Aces.color = new Color (0f, 1f, 0f, 1f);
			}

			if (DataManagerScript.playerThreeReturns == returns.Max()){
				player3Returns.color = new Color (0f, 1f, 0f, 1f);
			}

			if (DataManagerScript.playerThreeScores == scores.Max()){
				player3Scores.color = new Color (0f, 1f, 0f, 1f);
			}

			if (DataManagerScript.playerThreeBumbles == bumbles.Max()){
				player3Bumbles.color = new Color (1f, 0f, 0f, 1f);
			}

		} else {
			player3Title.enabled = false; 
			player3Labels.enabled = false;
		}

		if (DataManagerScript.playerFourPlaying) {
			player4Aces.text = DataManagerScript.playerFourAces.ToString (); 
			player4Scores.text = DataManagerScript.playerFourScores.ToString ();
			player4Returns.text = DataManagerScript.playerFourReturns.ToString ();
			player4Bumbles.text = DataManagerScript.playerFourBumbles.ToString ();

			if (DataManagerScript.playerFourAces == aces.Max()){
				player4Aces.color = new Color (0f, 1f, 0f, 1f);
			}

			if (DataManagerScript.playerFourReturns == returns.Max()){
				player4Returns.color = new Color (0f, 1f, 0f, 1f);
			}

			if (DataManagerScript.playerFourScores == scores.Max()){
				player4Scores.color = new Color (0f, 1f, 0f, 1f);
			}

			if (DataManagerScript.playerFourBumbles == bumbles.Max()){
				player4Bumbles.color = new Color (1f, 0f, 0f, 1f);
			}

		} else {
			player4Title.enabled = false; 
			player4Labels.enabled = false;
		}

		DetermineMVP ();
	}
}
