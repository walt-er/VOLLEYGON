using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FakePlayerScript : MonoBehaviour {

	public Sprite squareSprite;
	public Sprite circleSprite;
	public Sprite triangleSprite;
	public Sprite trapezoidSprite;

	public string chooseAxis;

	public string confirmKey;
	public string cancelKey;
	public int playerIdentifier; 
	public Text readyText;

	private bool axisInUse = false;
	public bool readyToPlay;

	private int numberOfPlayerTypes = 4;

	SpriteRenderer sr;

	void UpdatePlayerType(int whichType){
		if (!readyToPlay) {
			switch(playerIdentifier){

			case 1:
				DataManagerScript.playerOneType = whichType;
				break;
			case 2:
				DataManagerScript.playerTwoType = whichType;
				break;
			case 3:
				DataManagerScript.playerThreeType = whichType;
				break;
			case 4:
				DataManagerScript.playerFourType = whichType;
				break;
			}
			if (whichType == 0) {
//				fakePlayer1.GetComponent<MeshFilter> ().mesh = meshType1;
				//change sprite here
				sr.sprite = squareSprite;
			} else if (whichType == 1) {
				sr.sprite = circleSprite;
				//change sprite here
			} else if (whichType == 2){
				sr.sprite = triangleSprite;
				//change sprite here
			} else if (whichType == 3){
				sr.sprite = trapezoidSprite;
				//change sprite here
			}
		}
	}


	void toggleReadyState(){
		readyToPlay = !readyToPlay;
			if (readyToPlay) {
				readyText.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
			} else {
				readyText.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
			}
		}


	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		readyText.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
		sr.sprite = squareSprite;
	}

	// Update is called once per frame
	void Update () {

	
		if (Input.GetAxisRaw (chooseAxis) == 1) {


			if (axisInUse == false) {
				// Call your event function here.
				axisInUse = true;

				if (!readyToPlay) {
					if (playerIdentifier == 1) {
						DataManagerScript.playerOneType += 1; 
						DataManagerScript.playerOneType = DataManagerScript.playerOneType % numberOfPlayerTypes;
						Debug.Log (DataManagerScript.playerOneType);

						UpdatePlayerType (DataManagerScript.playerOneType);
					} else if (playerIdentifier == 2) {
						DataManagerScript.playerTwoType += 1; 
						DataManagerScript.playerTwoType = DataManagerScript.playerTwoType % numberOfPlayerTypes;
						Debug.Log (DataManagerScript.playerTwoType);

						UpdatePlayerType (DataManagerScript.playerTwoType);

					} else if (playerIdentifier == 3) {
						DataManagerScript.playerThreeType += 1; 
						DataManagerScript.playerThreeType = DataManagerScript.playerThreeType % numberOfPlayerTypes;
						Debug.Log (DataManagerScript.playerThreeType);

						UpdatePlayerType (DataManagerScript.playerThreeType);

					} else if (playerIdentifier == 4) {
						DataManagerScript.playerFourType += 1; 
						DataManagerScript.playerFourType = DataManagerScript.playerFourType % numberOfPlayerTypes;
						Debug.Log (DataManagerScript.playerFourType);

						UpdatePlayerType (DataManagerScript.playerFourType);
					}
				}
			}
		}

		if (Input.GetAxisRaw (chooseAxis) == -1) {


			if (axisInUse == false) {
				// Call your event function here.
				axisInUse = true;

				if (!readyToPlay) {
					DataManagerScript.playerOneType -= 1; 
					if (DataManagerScript.playerOneType < 0) {
						DataManagerScript.playerOneType = numberOfPlayerTypes - 1;
					}
					DataManagerScript.playerOneType = DataManagerScript.playerOneType % numberOfPlayerTypes;
					Debug.Log ("YES!" + DataManagerScript.playerOneType);
					UpdatePlayerType (DataManagerScript.playerOneType);
				}
			}
		}

		if (Input.GetAxisRaw (chooseAxis) == 0) {


			axisInUse = false;
		}





		if (Input.GetButtonDown (confirmKey)) {
			toggleReadyState ();
		}
		if (Input.GetButtonDown (cancelKey)) {
			toggleReadyState ();
		}
	}
}
