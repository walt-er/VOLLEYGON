using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallScript : MonoBehaviour {

	public Text scoreText;

	Rigidbody2D rb;
	float timer;
	private bool isTimerRunning;
	public float gravScale = 0.8f;
	private float originalGrav;
	private int bounces = 0;
	public float baseTimeBetweenGravChanges = 10f;
	private float lastXPos;
	public Sprite originalSprite;
	public Sprite reverseGravSprite;
	public Sprite changingSprite;
	private Sprite theSprite;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		scoreText.GetComponent<CanvasRenderer>().SetAlpha(0.0f);

		theSprite = GetComponent<SpriteRenderer>().sprite;
		rb.isKinematic = true;
		Invoke("LaunchBall", 3f);
		timer = baseTimeBetweenGravChanges + Random.value * 10 ; 
		rb.gravityScale = gravScale;
		originalGrav = gravScale;

		scoreText.text = GameManagerScript.Instance.teamOneScore.ToString () + " - " + GameManagerScript.Instance.teamTwoScore.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isTimerRunning) {
			timer -= Time.deltaTime;
			//Debug.Log (timer);
		}

		if (timer <= 3) {
			if (GetComponent<SpriteRenderer> ().sprite == reverseGravSprite) {
				Debug.Log ("a buhhh");
				GetComponent<SpriteRenderer>().sprite = originalSprite;
			} else {
				Debug.Log ("a buhhh 2!");
				GetComponent<SpriteRenderer> ().sprite = reverseGravSprite;
			};
		}
		if (timer <= 0){
			GravChange ();
			ResetTimer ();
			//Debug.Log (timer);
		}

		CheckForSideChange ();
		lastXPos = transform.position.x; 
	}

	void ResetTimer(){
		timer = baseTimeBetweenGravChanges + Random.value * 10;
		isTimerRunning = true;
	}
	void LaunchBall(){
		rb.isKinematic = false;
		//Send the ball in a random direction 

		ResetTimer();
		//In the future, factor in the gravity factor;
		rb.velocity = new Vector2 (Random.Range(-10.0F, 10.0F), Random.Range(10f*rb.gravityScale, 20F*rb.gravityScale));

	}

	void CheckForSideChange(){
		if (Mathf.Sign (transform.position.x) != Mathf.Sign (lastXPos)) {
			bounces = 0;
			Debug.Log ("Bounces reset!");
			GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, 1f);
		}
		
	}

	void FadeOutScore(){
		scoreText.CrossFadeAlpha(0f,.25f,false);
	}
	void ResetBall(){
		rb.isKinematic = true;
		gameObject.transform.position = new Vector3 (0, 0, 0);
		rb.velocity = new Vector2 (0, 0);
		bounces = 0;
		timer = 10; // arbitrary high number
		GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f) ;
		Invoke ("LaunchBall", 3f);
		Invoke ("FadeOutScore", 2f);
		isTimerRunning = false;
		int signValue = Random.Range (0, 2) * 2 - 1;
		rb.gravityScale = originalGrav * signValue;
		if (Mathf.Sign (rb.gravityScale) < 0) {
			Debug.Log ("changing sprite?");
			GetComponent<SpriteRenderer>().sprite = reverseGravSprite;
		} else {
			GetComponent<SpriteRenderer>().sprite = originalSprite;
		}
	}

	void GravChange(){
		rb.gravityScale *= -1;
		Debug.Log ("sign of gravity scale is " + Mathf.Sign (rb.gravityScale));
		if (Mathf.Sign (rb.gravityScale) < 0) {
			Debug.Log ("changing sprite?");
			GetComponent<SpriteRenderer>().sprite = reverseGravSprite;
		} else {
			GetComponent<SpriteRenderer>().sprite = originalSprite;
		}
	}
	void GameOver(){
		//Application.LoadLevel ("titleScene");
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "ScoringBoundary") {
			Debug.Log ("a collision!");
			bounces += 1;
			GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, .8f);
			if (bounces >= 2){

				// Award a score.

				if (Mathf.Sign (transform.position.x) < 0) {
					GameManagerScript.Instance.teamTwoScore += 1; 
				} else {
					GameManagerScript.Instance.teamOneScore += 1; 
				}
				if (GameManagerScript.Instance.teamTwoScore < GameManagerScript.Instance.scorePlayedTo && GameManagerScript.Instance.teamOneScore < GameManagerScript.Instance.scorePlayedTo) {
					scoreText.CrossFadeAlpha (0.6f, .25f, false);
					scoreText.text = GameManagerScript.Instance.teamOneScore.ToString () + " - " + GameManagerScript.Instance.teamTwoScore.ToString ();
					ResetBall ();
				} else {
					transform.position = new Vector3 (-20f, -20f, 0f);
					//Invoke ("GameOver", 5f);
				}
			}

		}
	}
}
