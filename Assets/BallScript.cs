using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "ScoringBoundary") {
			Debug.Log ("a collision!");
			gameObject.transform.position = new Vector3 (0, 0, 0);
			rb.velocity = new Vector2 (0, 0);
		}
	}
}
