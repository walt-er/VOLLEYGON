using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	Rigidbody2D rb;
	float timer;
	private bool isTimerRunning;
	public float gravScale = 0.8f;
	private int bounces = 0;
	private float lastXPos;
	public Sprite originalSprite;
	public Sprite reverseGravSprite;
	private Sprite theSprite;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		theSprite = GetComponent<SpriteRenderer>().sprite;
		rb.isKinematic = true;
		Invoke("LaunchBall", 3f);
		timer = 3 + Random.value * 10 ; 
		rb.gravityScale = gravScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (isTimerRunning) {
			timer -= Time.deltaTime;
			Debug.Log (timer);
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
		timer = 3 + Random.value * 10;
		isTimerRunning = true;
	}
	void LaunchBall(){
		rb.isKinematic = false;
		//Send the ball in a random direction 
		ResetTimer();
		//In the future, factor in the gravity factor;
		rb.velocity = new Vector2 (Random.Range(-10.0F, 0.0F), Random.Range(10f*rb.gravityScale, 20F*rb.gravityScale));

	}

	void CheckForSideChange(){
		if (Mathf.Sign (transform.position.x) != Mathf.Sign (lastXPos)) {
			bounces = 0;
			Debug.Log ("Bounces reset!");
		}
		
	}
	void ResetBall(){
		rb.isKinematic = true;
		gameObject.transform.position = new Vector3 (0, 0, 0);
		rb.velocity = new Vector2 (0, 0);
		bounces = 0;
		Invoke ("LaunchBall", 3f);
		isTimerRunning = false;
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

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "ScoringBoundary") {
			Debug.Log ("a collision!");
			bounces += 1;
			if (bounces >= 2){
				ResetBall ();
			}

		}
	}
}
