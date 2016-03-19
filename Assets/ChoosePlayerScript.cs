using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChoosePlayerScript : MonoBehaviour {

	public GameObject fakePlayer1;
	public GameObject fakePlayer2;
	public GameObject fakePlayer3;
	public GameObject fakePlayer4;

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

	private GameObject[] fakePlayers;

	// Use this for initialization



	// Update is called once per frame
	void Update () {

		if (fakePlayer1.GetComponent<FakePlayerScript>().readyToPlay && fakePlayer2.GetComponent<FakePlayerScript>().readyToPlay && fakePlayer3.GetComponent<FakePlayerScript>().readyToPlay && fakePlayer4.GetComponent<FakePlayerScript>().readyToPlay) {
			Application.LoadLevel ("chooseArenaScene");
		}
	}
}
