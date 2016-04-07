using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatsPlayerScript : MonoBehaviour {

	public Sprite squareSprite;
	public Sprite circleSprite;
	public Sprite triangleSprite;
	public Sprite trapezoidSprite;

	public string chooseAxis;

	public string confirmKey;
	public string cancelKey;
	public int playerIdentifier; 
	public Text readyText;
	public Text toJoinText;

	private bool axisInUse = false;
	public bool readyToPlay;
	public bool taggedIn = false;

	private int numberOfPlayerTypes = 4;

	private int whichType;


	SpriteRenderer sr;


	void activateReadyState(){
		if (taggedIn) {
			readyToPlay = true;

				readyText.GetComponent<CanvasRenderer> ().SetAlpha (1.0f);
		

			StatManagerScript.Instance.increasePlayerReady ();
		} 
	}

	void cancelReadyState(){
		if (readyToPlay) {
			readyToPlay = false;
			readyText.GetComponent<CanvasRenderer> ().SetAlpha (0.0f);
			StatManagerScript.Instance.decreasePlayerReady ();
		} 

	}


	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		readyText.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
		sr.sprite = squareSprite;

		sr.enabled = false;

		switch(playerIdentifier){
		
		case 1:
			whichType = DataManagerScript.playerOneType;
						break;
		case 2:
			whichType = DataManagerScript.playerTwoType;
						break;
		case 3:
			whichType = DataManagerScript.playerThreeType;
						break;
		case 4:
			whichType = DataManagerScript.playerFourType;
						break;
					}



		switch (playerIdentifier) {
		case 1:
			if (DataManagerScript.playerOnePlaying) {
				sr.enabled = true;
				taggedIn = true;
			}
			break;
		case 2:
			if (DataManagerScript.playerTwoPlaying) {
				sr.enabled = true;
				taggedIn = true;
			}
			break;
		case 3:
			if (DataManagerScript.playerThreePlaying) {
				sr.enabled = true;
				taggedIn = true;
			}
			break;
		case 4:
			if (DataManagerScript.playerFourPlaying) {
				sr.enabled = true;
				taggedIn = true;
			}
			break;

		}

		if (sr.enabled) {
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

	//	Invoke ("BackToTitle", 8f);

	}

	void BackToTitle(){
		Application.LoadLevel ("titleScene");
	}
	// Update is called once per frame
	void Update () {


		if (Input.GetButtonDown (confirmKey)) {
			activateReadyState ();
		}
		if (Input.GetButtonDown (cancelKey)) {
			cancelReadyState ();
		}
	}
}
