using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChoosePlayerScript : MonoBehaviour {

	public GameObject fakePlayer1;
	public GameObject fakePlayer2;
	public GameObject fakePlayer3;
	public GameObject fakePlayer4;

	public Text player1ReadyText;
	public Text player2ReadyText;
	public Text player3ReadyText;
	public Text player4ReadyText;

	public Mesh meshType1;
	public Mesh meshType2;

	private int numberOfPlayerTypes = 4;

	private string jumpButton1 = "Jump_P1";
	private string gravButton1 = "Grav_P1";
	private string horizAxis1 = "Horizontal_P1";
	private string horizAxis2 = "Horizontal_P2";
	private string horizAxis3 = "Horizontal_P3";
	private string horizAxis4 = "Horizontal_P4";

	private string jumpButton2 = "Jump_P2";
	private string gravButton2 = "Grav_P2";
	private string jumpButton3 = "Jump_P3";
	private string gravButton3 = "Grav_P3";
	private string jumpButton4 = "Jump_P4";
	private string gravButton4 = "Grav_P4";

	private bool axis1InUse = false;
	private bool axis2InUse = false;
	private bool axis3InUse = false;
	private bool axis4InUse = false;

	private bool player1Ready = false;
	private bool player2Ready = false;
	private bool player3Ready = false;
	private bool player4Ready = false;

	private GameObject[] fakePlayers;
	void UpdatePlayerType(int whichPlayer, int whichType){
		if (whichPlayer == 1 && !player1Ready) {
			DataManagerScript.playerOneType = whichType;
			if (whichType == 0) {
				fakePlayer1.GetComponent<MeshFilter> ().mesh = meshType1;
			} else if (whichType == 1) {
				fakePlayer1.GetComponent<MeshFilter> ().mesh = meshType2;
			}
		}
		if (whichPlayer == 2 && !player2Ready) {
			DataManagerScript.playerTwoType = whichType;
			if (whichType == 0) {
				fakePlayer2.GetComponent<MeshFilter> ().mesh = meshType1;
			} else if (whichType == 1) {
				fakePlayer2.GetComponent<MeshFilter> ().mesh = meshType2;
			}
		}
		if (whichPlayer == 3 && !player3Ready) {
			DataManagerScript.playerThreeType = whichType;
			if (whichType == 0) {
				fakePlayer3.GetComponent<MeshFilter> ().mesh = meshType1;
			} else if (whichType == 1) {
				fakePlayer3.GetComponent<MeshFilter> ().mesh = meshType2;
			}
		}
		if (whichPlayer == 4 && !player4Ready) {
			DataManagerScript.playerFourType = whichType;
			if (whichType == 0) {
				fakePlayer4.GetComponent<MeshFilter> ().mesh = meshType1;
			} else if (whichType == 1) {
				fakePlayer4.GetComponent<MeshFilter> ().mesh = meshType2;
			}
		}
		Debug.Log (DataManagerScript.playerOneType);
	}
	// Use this for initialization

	void toggleReadyState(int whichPlayer){
		if (whichPlayer == 1) {
			player1Ready = !player1Ready;
			if (player1Ready) {
				player1ReadyText.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
			} else {
				player1ReadyText.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
			}
		}

		if (whichPlayer == 2) {
			player2Ready = !player2Ready;
			if (player2Ready) {
				player2ReadyText.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
			} else {
				player2ReadyText.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
			}
		}

		if (whichPlayer == 3) {
			player3Ready = !player3Ready;
			if (player3Ready) {
				player3ReadyText.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
			} else {
				player3ReadyText.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
			}
		}

		if (whichPlayer == 4) {
			player4Ready = !player4Ready;
			if (player4Ready) {
				player4ReadyText.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
			} else {
				player4ReadyText.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
			}
		}
}
	void Start () {
		player1ReadyText.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
		player2ReadyText.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
		player3ReadyText.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
		player4ReadyText.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
	}

	// Update is called once per frame
	void Update () {

		if (player1Ready && player2Ready && player3Ready && player4Ready) {
			Application.LoadLevel("chooseArenaScene");
		}
		if (Input.GetAxisRaw (horizAxis1) == 1) {
			

			if (axis1InUse == false) {
				// Call your event function here.
				axis1InUse = true;

				if (!player1Ready) {
					DataManagerScript.playerOneType += 1; 
					DataManagerScript.playerOneType = DataManagerScript.playerOneType % numberOfPlayerTypes;
					Debug.Log (DataManagerScript.playerOneType);

					UpdatePlayerType (1, DataManagerScript.playerOneType);
				}
			}
		}

		if (Input.GetAxisRaw (horizAxis1) == -1) {


			if (axis1InUse == false) {
				// Call your event function here.
				axis1InUse = true;

				if (!player1Ready) {
					DataManagerScript.playerOneType -= 1; 
					if (DataManagerScript.playerOneType < 0) {
						DataManagerScript.playerOneType = numberOfPlayerTypes - 1;
					}
					DataManagerScript.playerOneType = DataManagerScript.playerOneType % numberOfPlayerTypes;
					Debug.Log ("YES!" + DataManagerScript.playerOneType);
					UpdatePlayerType (1, DataManagerScript.playerOneType);
				}
			}
		}

		if (Input.GetAxisRaw (horizAxis1) == 0) {
			

			axis1InUse = false;
		}

		if (Input.GetAxisRaw (horizAxis2) == 1) {


			if (axis2InUse == false) {
				// Call your event function here.
				axis2InUse = true;

				if (!player2Ready) {
					DataManagerScript.playerTwoType += 1; 
					DataManagerScript.playerTwoType = DataManagerScript.playerTwoType % numberOfPlayerTypes;
					Debug.Log (DataManagerScript.playerTwoType);

					UpdatePlayerType (2, DataManagerScript.playerTwoType);
				}
			}
		}

		if (Input.GetAxisRaw (horizAxis2) == -1) {


			if (axis2InUse == false) {
				// Call your event function here.
				axis2InUse = true;

				if (!player2Ready) {
					DataManagerScript.playerTwoType -= 1; 
					if (DataManagerScript.playerTwoType < 0) {
						DataManagerScript.playerTwoType = numberOfPlayerTypes - 1;
					}
					DataManagerScript.playerTwoType = DataManagerScript.playerTwoType % numberOfPlayerTypes;
					Debug.Log ("YES!" + DataManagerScript.playerTwoType);
					UpdatePlayerType (2, DataManagerScript.playerTwoType);
				}
			}
		}

		if (Input.GetAxisRaw (horizAxis2) == 0) {


			axis2InUse = false;
		}

		if (Input.GetAxisRaw (horizAxis3) == 1) {


			if (axis3InUse == false) {
				// Call your event function here.
				axis3InUse = true;

				if (!player3Ready) {
					DataManagerScript.playerThreeType += 1; 
					DataManagerScript.playerThreeType = DataManagerScript.playerThreeType % numberOfPlayerTypes;
					Debug.Log (DataManagerScript.playerThreeType);

					UpdatePlayerType (3, DataManagerScript.playerThreeType);
				}
			}
		}

		if (Input.GetAxisRaw (horizAxis3) == -1) {


			if (axis3InUse == false) {
				// Call your event function here.
				axis3InUse = true;

				if (!player3Ready) {
					DataManagerScript.playerThreeType -= 1; 
					if (DataManagerScript.playerThreeType < 0) {
						DataManagerScript.playerThreeType = numberOfPlayerTypes - 1;
					}
					DataManagerScript.playerThreeType = DataManagerScript.playerThreeType % numberOfPlayerTypes;
					Debug.Log ("YES!" + DataManagerScript.playerThreeType);
					UpdatePlayerType (3, DataManagerScript.playerThreeType);
				}
			}
		}

		if (Input.GetAxisRaw (horizAxis3) == 0) {


			axis3InUse = false;
		}

		if (Input.GetAxisRaw (horizAxis4) == 1) {


			if (axis4InUse == false) {
				// Call your event function here.
				axis4InUse = true;

				if (!player4Ready) {
					DataManagerScript.playerFourType += 1; 
					DataManagerScript.playerFourType = DataManagerScript.playerFourType % numberOfPlayerTypes;
					Debug.Log (DataManagerScript.playerFourType);

					UpdatePlayerType (4, DataManagerScript.playerFourType);
				}
			}
		}

		if (Input.GetAxisRaw (horizAxis4) == -1) {


			if (axis4InUse == false) {
				// Call your event function here.
				axis4InUse = true;
				if (!player4Ready) {
					DataManagerScript.playerFourType -= 1; 
					if (DataManagerScript.playerFourType < 0) {
						DataManagerScript.playerFourType = numberOfPlayerTypes - 1;
					}
					DataManagerScript.playerFourType = DataManagerScript.playerFourType % numberOfPlayerTypes;
					Debug.Log ("YES!" + DataManagerScript.playerFourType);
					UpdatePlayerType (4, DataManagerScript.playerFourType);
				}
			}
		}

		if (Input.GetAxisRaw (horizAxis4) == 0) {


			axis4InUse = false;
		}





		if (Input.GetButtonDown (jumpButton1)) {
			toggleReadyState (1);
		}
		if (Input.GetButtonDown (gravButton1)) {
			toggleReadyState (1);
		}
		if (Input.GetButtonDown (jumpButton2)) {
			toggleReadyState (2);
		}
		if (Input.GetButtonDown (gravButton2)) {
			toggleReadyState (2);
		}
		if (Input.GetButtonDown (jumpButton3)) {
			toggleReadyState (3);
		}
		if (Input.GetButtonDown (gravButton3)) {
			toggleReadyState (3);
		}
		if (Input.GetButtonDown (jumpButton4)) {
			toggleReadyState (4);
		}
		if (Input.GetButtonDown (gravButton4)) {
			toggleReadyState (4);
		}
	}
}
