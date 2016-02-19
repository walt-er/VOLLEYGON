using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 5f;
	public float jumpPower = 750f;
	private bool isJumping = false;
	public string horiz = "Horizontal_P1";
	public string jumpButton = "Jump_P1";
	public string gravButton = "Grav_P1";
	public int team = 1;
	public float startingGrav = 1;

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = startingGrav;

	}
	


	void FixedUpdate () {
		
		float moveHorizontal = Input.GetAxis (horiz);
//		float moveVertical = Input.GetAxis ("Vertical"); // these return between 0 and 1
//		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
//		rigidbody.velocity.x = moveHorizontal * speed;
		//GetComponent<Rigidbody2D>().AddTorque(moveHorizontal * -8f);

		if (isJumping) {
			GetComponent<Rigidbody2D> ().angularVelocity = (moveHorizontal * -150f * rb.gravityScale);
		}
		Vector3 v3 = GetComponent<Rigidbody2D>().velocity;
		v3.x = moveHorizontal * speed;
//		v3.z = 0.0;
		GetComponent<Rigidbody2D>().velocity = v3;
//		rigidbody.position = new Vector3
//			(
//				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax),
//				0.5f,
//				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
//				);
	}

	void Update(){
		
		if (Input.GetButtonDown (jumpButton)) {
			//Debug.Log ("Jump hit");
			if (isJumping == false){
				Vector3 jumpForce = new Vector3(0f,jumpPower * rb.gravityScale,0f);
				rb.AddForce(jumpForce);
				isJumping = true;
			}
		}

		if (Input.GetButtonDown (gravButton)) {
			rb.gravityScale *= -1f;

		}

		var pos = transform.position;
		if (team == 1) {
			pos.x = Mathf.Clamp (transform.position.x, -200.0f, -1.0f);
			transform.position = pos;
		} else if (team == 2) {
			pos.x = Mathf.Clamp (transform.position.x, 1f, 200f);
			transform.position = pos;
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "ScoringBoundary" || coll.gameObject.tag == "Player") {
			Debug.Log ("a collision!");
			isJumping = false;
			Debug.Log (isJumping);
		}
	}
	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == "ScoringBoundary" || coll.gameObject.tag == "Player") {
			Debug.Log ("a collision ended!");
			if (!isJumping) {
					isJumping = true;   
			}
			Debug.Log (isJumping);
		}
	}
}
