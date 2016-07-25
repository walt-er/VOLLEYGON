using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FakePlayerScript : MonoBehaviour {

	public Sprite squareSprite;
	public Sprite circleSprite;
	public Sprite triangleSprite;
	public Sprite trapezoidSprite;

	public Image readyBG;
	public string chooseAxis;

	public string confirmKey;
	public string cancelKey;
	public int playerIdentifier; 
	public Text readyText;
	public Text toJoinText;
	public Text playerDescription;
	public Text playerDifficulty;

	private bool axisInUse = false;
	public bool readyToPlay;
	public bool taggedIn = false;
	private AudioSource audio;
	public AudioClip tickUp;
	public AudioClip tickDown;
	public AudioClip tagInSound;
	public AudioClip readySound;

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
				playerDescription.text = "CLASSIC\nDEFENSIVE";
				playerDifficulty.text = "EASY";
			} else if (whichType == 1) {
				sr.sprite = circleSprite;
				playerDescription.text = "ALL-AROUND\nVERSATILE";
				playerDifficulty.text = "MEDIUM";
				//change sprite here
			} else if (whichType == 2){
				sr.sprite = triangleSprite;
				playerDescription.text = "AIRBORNE\nAGGRESSIVE";
				playerDifficulty.text = "HARD";
				//change sprite here
			} else if (whichType == 3){
				sr.sprite = trapezoidSprite;
				playerDescription.text = "CRAZY!\nWEIRD!";
				playerDifficulty.text = "EXPERTS ONLY";
				//change sprite here
			}
		}
	}


	void activateReadyState(){
		if (taggedIn) {
			if (!readyToPlay) {
				audio.PlayOneShot (readySound);
			}
			readyToPlay = true;
			playerDescription.enabled = false;
			playerDifficulty.enabled = false;

	
			if (readyToPlay) {
				readyText.GetComponent<CanvasRenderer> ().SetAlpha (1.0f);
				readyBG.GetComponent<CanvasRenderer> ().SetAlpha (1.0f);
			} else {
				
				readyText.GetComponent<CanvasRenderer> ().SetAlpha (0.0f);
				readyBG.GetComponent<CanvasRenderer> ().SetAlpha (0.0f);
			}
		} else {
			taggedIn = true;
			audio.PlayOneShot (tagInSound);
			toJoinText.GetComponent<CanvasRenderer> ().SetAlpha (0.0f);
			playerDescription.enabled = true;
			playerDifficulty.enabled = true;
			sr.enabled = true;
			switch(playerIdentifier){

			case 1:
				DataManagerScript.playerOnePlaying = true;
				break;
			case 2:
				DataManagerScript.playerTwoPlaying = true;
				break;
			case 3:
				DataManagerScript.playerThreePlaying = true;
				break;
			case 4:
				DataManagerScript.playerFourPlaying = true;
				break;
			}
		}
		ChoosePlayerScript.Instance.CheckStartable ();

	}

	void cancelReadyState(){
		if (readyToPlay) {
			readyToPlay = false;
			readyText.GetComponent<CanvasRenderer> ().SetAlpha (0.0f);
			readyBG.GetComponent<CanvasRenderer> ().SetAlpha (0.0f);
			playerDescription.enabled = true;
			playerDifficulty.enabled = true;
		} else if (taggedIn) {
			taggedIn = false;
			toJoinText.GetComponent<CanvasRenderer> ().SetAlpha (1.0f);
			sr.enabled = false;
			playerDescription.enabled = false;
			playerDifficulty.enabled = false;
			switch(playerIdentifier){

			case 1:
				DataManagerScript.playerOnePlaying = false;
				break;
			case 2:
				DataManagerScript.playerTwoPlaying = false;
				break;
			case 3:
				DataManagerScript.playerThreePlaying = false;
				break;
			case 4:
				DataManagerScript.playerFourPlaying = false;
				break;
			}
		}
		ChoosePlayerScript.Instance.CheckStartable ();
	}


	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		readyText.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
		sr.sprite = squareSprite;
		readyBG.GetComponent<CanvasRenderer> ().SetAlpha (0.0f);
		sr.enabled = false;
		playerDescription.enabled = false;
		playerDifficulty.enabled = false;

		audio = GetComponent<AudioSource> ();

	}

	// Update is called once per frame
	void Update () {

		// only allow input if game isn't already starting
		//Debug.Log(ChoosePlayerScript.Instance.locked);
		if (!ChoosePlayerScript.Instance.locked) {
			if (Input.GetAxisRaw (chooseAxis) == 1) {



				if (axisInUse == false) {
					// Call your event function here.
					axisInUse = true;

					if (!readyToPlay && taggedIn) {
						if (playerIdentifier == 1) {
							DataManagerScript.playerOneType += 1; 
							DataManagerScript.playerOneType = DataManagerScript.playerOneType % numberOfPlayerTypes;
							Debug.Log (DataManagerScript.playerOneType);
							audio.PlayOneShot (tickUp);
							UpdatePlayerType (DataManagerScript.playerOneType);
						} else if (playerIdentifier == 2) {
							DataManagerScript.playerTwoType += 1; 
							DataManagerScript.playerTwoType = DataManagerScript.playerTwoType % numberOfPlayerTypes;
							Debug.Log (DataManagerScript.playerTwoType);
							audio.PlayOneShot (tickUp);
							UpdatePlayerType (DataManagerScript.playerTwoType);

						} else if (playerIdentifier == 3) {
							DataManagerScript.playerThreeType += 1; 
							DataManagerScript.playerThreeType = DataManagerScript.playerThreeType % numberOfPlayerTypes;
							Debug.Log (DataManagerScript.playerThreeType);
							audio.PlayOneShot (tickUp);
							UpdatePlayerType (DataManagerScript.playerThreeType);

						} else if (playerIdentifier == 4) {
							DataManagerScript.playerFourType += 1; 
							DataManagerScript.playerFourType = DataManagerScript.playerFourType % numberOfPlayerTypes;
							Debug.Log (DataManagerScript.playerFourType);
							audio.PlayOneShot (tickUp);
							UpdatePlayerType (DataManagerScript.playerFourType);
						}
					}
				}
			}

			if (Input.GetAxisRaw (chooseAxis) == -1) {


				if (axisInUse == false) {
					// Call your event function here.
					axisInUse = true;
					if (!readyToPlay && taggedIn) {
						if (playerIdentifier == 1) {
							DataManagerScript.playerOneType -= 1; 
							if (DataManagerScript.playerOneType < 0) {
								DataManagerScript.playerOneType = numberOfPlayerTypes - 1;

							}
							Debug.Log (DataManagerScript.playerOneType);
							audio.PlayOneShot (tickDown);
							UpdatePlayerType (DataManagerScript.playerOneType);
						} else if (playerIdentifier == 2) {
							DataManagerScript.playerTwoType -= 1; 
							if (DataManagerScript.playerTwoType < 0) {
								DataManagerScript.playerTwoType = numberOfPlayerTypes - 1;
						
							}
							Debug.Log (DataManagerScript.playerTwoType);
							audio.PlayOneShot (tickDown);
							UpdatePlayerType (DataManagerScript.playerTwoType);

						} else if (playerIdentifier == 3) {
							DataManagerScript.playerThreeType -= 1; 
							if (DataManagerScript.playerThreeType < 0) {
								DataManagerScript.playerThreeType = numberOfPlayerTypes - 1;

							}
							Debug.Log (DataManagerScript.playerThreeType);
							audio.PlayOneShot (tickDown);
							UpdatePlayerType (DataManagerScript.playerThreeType);

						} else if (playerIdentifier == 4) {
							DataManagerScript.playerFourType -= 1; 
							if (DataManagerScript.playerFourType < 0) {
								DataManagerScript.playerFourType = numberOfPlayerTypes - 1;

							}
							Debug.Log (DataManagerScript.playerFourType);
							audio.PlayOneShot (tickDown);
							UpdatePlayerType (DataManagerScript.playerFourType);
						}
					}
//				if (!readyToPlay && taggedIn) {
//					DataManagerScript.playerOneType -= 1; 
//					if (DataManagerScript.playerOneType < 0) {
//						DataManagerScript.playerOneType = numberOfPlayerTypes - 1;
//					}
//					DataManagerScript.playerOneType = DataManagerScript.playerOneType % numberOfPlayerTypes;
//					Debug.Log ("YES!" + DataManagerScript.playerOneType);
//					UpdatePlayerType (DataManagerScript.playerOneType);
//				}
				}
			}

			if (Input.GetAxisRaw (chooseAxis) == 0) {


				axisInUse = false;
			}





			if (Input.GetButtonDown (confirmKey)) {
				activateReadyState ();
			}
			if (Input.GetButtonDown (cancelKey)) {
				cancelReadyState ();
			}
		}
	}
}
