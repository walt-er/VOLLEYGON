using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 5f;
	public float jumpPower = 750f;
	private bool isJumping = false;
	public string horiz = "Horizontal_P1";
	public string jumpButton = "Jump_P1";
	// Use this for initialization
	void Start () {
	
	}
	


	void FixedUpdate () {
		
		float moveHorizontal = Input.GetAxis (horiz);
//		float moveVertical = Input.GetAxis ("Vertical"); // these return between 0 and 1
//		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
//		rigidbody.velocity.x = moveHorizontal * speed;
		//GetComponent<Rigidbody2D>().AddTorque(moveHorizontal * -8f);

		if (isJumping) {
			GetComponent<Rigidbody2D> ().angularVelocity = (moveHorizontal * -150f);
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
				Vector3 jumpForce = new Vector3(0f,jumpPower,0f);
				GetComponent<Rigidbody2D>().AddForce(jumpForce);
				isJumping = true;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "ground") {
			Debug.Log ("a collision!");
			isJumping = false;
			Debug.Log (isJumping);
		}
	}
	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == "ground") {
			Debug.Log ("a collision ended!");
			if (!isJumping) {
					isJumping = true;   
			}
			Debug.Log (isJumping);
		}
	}
}
