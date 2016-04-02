using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

	// Use this for initialization
	void Start () {
		PopulateStats ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void PopulateStats(){
		// if player active...
		if (DataManagerScript.playerOnePlaying) {
			player1Aces.text = DataManagerScript.playerOneAces.ToString (); 
			player1Scores.text = DataManagerScript.playerOneScores.ToString ();
			player1Returns.text = DataManagerScript.playerOneReturns.ToString ();
			player1Bumbles.text = DataManagerScript.playerOneBumbles.ToString ();
		} else {
			player1Title.enabled = false; 
			player1Labels.enabled = false;
		}

		if (DataManagerScript.playerTwoPlaying) {
			player2Aces.text = DataManagerScript.playerTwoAces.ToString (); 
			player2Scores.text = DataManagerScript.playerTwoScores.ToString ();
			player2Returns.text = DataManagerScript.playerTwoReturns.ToString ();
			player2Bumbles.text = DataManagerScript.playerTwoBumbles.ToString ();
		} else {
			player2Title.enabled = false; 
			player2Labels.enabled = false;
		}

		if (DataManagerScript.playerThreePlaying) {
			player3Aces.text = DataManagerScript.playerThreeAces.ToString (); 
			player3Scores.text = DataManagerScript.playerThreeScores.ToString ();
			player3Returns.text = DataManagerScript.playerThreeReturns.ToString ();
			player3Bumbles.text = DataManagerScript.playerThreeBumbles.ToString ();
		} else {
			player3Title.enabled = false; 
			player3Labels.enabled = false;
		}

		if (DataManagerScript.playerFourPlaying) {
			player4Aces.text = DataManagerScript.playerFourAces.ToString (); 
			player4Scores.text = DataManagerScript.playerFourScores.ToString ();
			player4Returns.text = DataManagerScript.playerFourReturns.ToString ();
			player4Bumbles.text = DataManagerScript.playerFourBumbles.ToString ();
		} else {
			player4Title.enabled = false; 
			player4Labels.enabled = false;
		}
	}
}
