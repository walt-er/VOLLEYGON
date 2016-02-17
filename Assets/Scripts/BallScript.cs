using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	Rigidbody2D rb;
	float timer;
	private bool isTimerRunning;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.isKinematic = true;
		Invoke("LaunchBall", 3f);
		timer = 30 + Random.value * 10 ; 
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
	}

	void ResetTimer(){
		timer = 30 + Random.value * 10;
		isTimerRunning = true;
	}
	void LaunchBall(){
		rb.isKinematic = false;
		//Send the ball in a random direction 
		ResetTimer();
		//In the future, factor in the gravity factor;
		rb.velocity = new Vector2 (Random.Range(-10.0F, 10.0F), Random.Range(10f*rb.gravityScale, 20F*rb.gravityScale));

	}

	void ResetBall(){
		rb.isKinematic = true;
		gameObject.transform.position = new Vector3 (0, 0, 0);
		rb.velocity = new Vector2 (0, 0);
		Invoke ("LaunchBall", 3f);
		isTimerRunning = false;
	}

	void GravChange(){
		rb.gravityScale *= -1;
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "ScoringBoundary") {
			Debug.Log ("a collision!");
			ResetBall ();

		}
	}
}
