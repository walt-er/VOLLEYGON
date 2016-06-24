using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChoosePlayerScript : MonoBehaviour {

	public GameObject fakePlayer1;
	public GameObject fakePlayer2;
	public GameObject fakePlayer3;
	public GameObject fakePlayer4;
	public Image msgBG;

	public Text oneOnOneMessage;
	public Text twoOnOneMessage;

		private string start1 = "Start_P1";
		private string start2 = "Start_P2";
		private string start3 = "Start_P3";
		private string start4 = "Start_P4";

	private bool gameIsStartable = false;
//	public Text player1ReadyText;
//	public Text player2ReadyText;
//	public Text player3ReadyText;
//	public Text player4ReadyText;
//
//	public Mesh meshType1;
//	public Mesh meshType2;
//
//	private int numberOfPlayerTypes = 4;
//
//	private string jumpButton1 = "Jump_P1";
//	private string gravButton1 = "Grav_P1";
//	private string horizAxis1 = "Horizontal_P1";
//	private string horizAxis2 = "Horizontal_P2";
//	private string horizAxis3 = "Horizontal_P3";
//	private string horizAxis4 = "Horizontal_P4";
//
//	private string jumpButton2 = "Jump_P2";
//	private string gravButton2 = "Grav_P2";
//	private string jumpButton3 = "Jump_P3";
//	private string gravButton3 = "Grav_P3";
//	private string jumpButton4 = "Jump_P4";
//	private string gravButton4 = "Grav_P4";
//
//	private bool axis1InUse = false;
//	private bool axis2InUse = false;
//	private bool axis3InUse = false;
//	private bool axis4InUse = false;

	private bool player1Ready = false;
	private bool player2Ready = false;
	private bool player3Ready = false;
	private bool player4Ready = false;

	private int playersOnLeft = 0;
	private int playersOnRight = 0;

	private GameObject[] fakePlayers;
	public static ChoosePlayerScript Instance { get; private set; }
	// Use this for initialization

	void Awake(){
		Instance = this;
	}
	void Start(){
		oneOnOneMessage.enabled = false;
		twoOnOneMessage.enabled = false;
		msgBG.enabled = false;

		DataManagerScript.playerOnePlaying = false;
		DataManagerScript.playerTwoPlaying = false;
		DataManagerScript.playerThreePlaying = false;
		DataManagerScript.playerFourPlaying = false; 

	}
	bool noUnreadyPlayers(){
		if (fakePlayer1.GetComponent<FakePlayerScript> ().taggedIn && !fakePlayer1.GetComponent<FakePlayerScript> ().readyToPlay) {
			return false;
		} else if (fakePlayer2.GetComponent<FakePlayerScript> ().taggedIn && !fakePlayer2.GetComponent<FakePlayerScript> ().readyToPlay) {
			return false;
		} else if (fakePlayer3.GetComponent<FakePlayerScript> ().taggedIn && !fakePlayer3.GetComponent<FakePlayerScript> ().readyToPlay) {
			return false;
		} else if (fakePlayer4.GetComponent<FakePlayerScript> ().taggedIn && !fakePlayer4.GetComponent<FakePlayerScript> ().readyToPlay) {
			return false;
		} else {
			return true;
		}

	}

	public void CheckStartable(){
		playersOnLeft = 0;
		playersOnRight = 0;
		if (fakePlayer1.GetComponent<FakePlayerScript> ().readyToPlay) {
			playersOnLeft++;
		}
		if (fakePlayer2.GetComponent<FakePlayerScript> ().readyToPlay) {
			playersOnLeft++;
		}

		if (fakePlayer3.GetComponent<FakePlayerScript> ().readyToPlay) {
			playersOnRight++;
		}
		if (fakePlayer4.GetComponent<FakePlayerScript> ().readyToPlay) {
			playersOnRight++;
		}
		Debug.Log (playersOnLeft);
		Debug.Log (playersOnRight);
		if (playersOnLeft > 0 && playersOnRight > 0 && noUnreadyPlayers()) {
			Debug.Log ("Game is now startable");
			gameIsStartable = true;
			if (playersOnLeft == 2 && playersOnRight == 1 || playersOnLeft == 1 && playersOnRight == 2) {
				// display 2v1 message
				twoOnOneMessage.enabled = true;
				msgBG.enabled = true;
				Debug.Log ("Showing 2v1 message");
				oneOnOneMessage.enabled = false;
			} else {
				//display press start to begin 1v 1 message
				oneOnOneMessage.enabled = true;
				twoOnOneMessage.enabled = false;
				msgBG.enabled = true;
				Debug.Log ("showing one on one message");
			}
		} else {
			twoOnOneMessage.enabled = false;
			oneOnOneMessage.enabled = false;
			msgBG.enabled = false;
			Debug.Log ("No longer startable. Hiding messages");
			gameIsStartable = false;
		}

	}
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonDown (start1) || Input.GetButtonDown (start2) || Input.GetButtonDown (start3) || Input.GetButtonDown (start4)) {
			if (gameIsStartable){
				Application.LoadLevel ("chooseArenaScene");
			}
		}
			if (fakePlayer1.GetComponent<FakePlayerScript>().readyToPlay && fakePlayer2.GetComponent<FakePlayerScript>().readyToPlay && fakePlayer3.GetComponent<FakePlayerScript>().readyToPlay && fakePlayer4.GetComponent<FakePlayerScript>().readyToPlay) {
			Application.LoadLevel ("chooseArenaScene");
		}
	}
}
