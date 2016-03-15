using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 5f;
	private float startSpeed;
	private float startMass;
	private float startJumpPower;
	public float jumpPower = 750f;
	public bool isJumping = false;
	public string horiz = "Horizontal_P1";
	public string jumpButton = "Jump_P1";
	public string gravButton = "Grav_P1";
	public int team = 1;
	public float startingGrav = 1;
	public Mesh meshTypeOne;
	public Mesh meshTypeTwo;
	public int playerType = 0;
	public PolygonCollider2D trianglePC, trapezoidPC;

	private float speedPowerupTimer;
	private bool speedPowerupActive = false; 

	private float sizePowerupTimer;
	private bool sizePowerupActive = false; 

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		PolygonCollider2D pg = GetComponent<PolygonCollider2D> ();
		rb.gravityScale = startingGrav;
		startMass = rb.mass;
		startJumpPower = jumpPower;
		startSpeed = speed; 

		if (playerType == 0) {
			gameObject.GetComponent<BoxCollider2D> ().enabled = true;
			gameObject.GetComponent<MeshFilter> ().mesh = meshTypeOne;
		}

		if (playerType == 1) {
			gameObject.GetComponent<CircleCollider2D> ().enabled = true;
			gameObject.GetComponent<MeshFilter> ().mesh = meshTypeTwo;
		}

		if (playerType == 2) {
			trianglePC.enabled = true;
			gameObject.GetComponent<MeshFilter> ().mesh = meshTypeTwo;
		}

		if (playerType == 3) {
			trapezoidPC.enabled = true;
			gameObject.GetComponent<MeshFilter> ().mesh = meshTypeTwo;
		}

		//polygon collider

		//Vector2[] thePoints = pg.points;
		// do stuff with myPoints array
//		Vector2[] thePoints = new Vector2[] {
//			new Vector2 (0f, -1f),
//			new Vector2 (1f, -1f),
//			new Vector2 (-1f, -1f)
//
//		};
//		pg.pathCount = 3;
//		pg.points = thePoints;

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

		ManagePowerups ();
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "ScoringBoundary" || coll.gameObject.tag == "Player") {
			Debug.Log ("a collision!");
			isJumping = false;
			Debug.Log (isJumping);
		}

	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Powerup") {
			int whichPowerup = coll.gameObject.GetComponent<powerupScript> ().powerupType;
			Destroy (coll.gameObject);
			ApplyPowerup (whichPowerup);
		}
	}
	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == "ScoringBoundary" || coll.gameObject.tag == "Player") {
			//Debug.Log ("a collision ended!");
			if (!isJumping) {
					//isJumping = true;   
			}
			Debug.Log (isJumping);
		}
	}

	void ManagePowerups(){
		if (speedPowerupActive) {
			speedPowerupTimer -= Time.deltaTime;

			if (speedPowerupTimer <= 0){
				speedPowerupActive = false;
				speed = startSpeed;
			}
		}

		if (sizePowerupActive) {
			sizePowerupTimer -= Time.deltaTime;

			if (sizePowerupTimer <= 0){
				sizePowerupActive = false;
				// Restore scale to starting size
				gameObject.transform.localScale = new Vector3 (1f, 1f, 1f);
				rb.mass = startMass;
				jumpPower = startJumpPower;

			}
		}
	}

	void ApplyPowerup(int whichPowerup){
		Debug.Log (whichPowerup);
		switch (whichPowerup) {

		case 1:
			speedPowerupActive = true;
			speed = 25f;
			speedPowerupTimer = 20f; 

			break;

		case 2:
			
			sizePowerupActive = true;
			gameObject.transform.localScale = new Vector3 (2f, 2f, 1f);
			rb.mass = startMass * 2f;
			jumpPower = startJumpPower * 1.75f;
			sizePowerupTimer = 20f;

			break;
		default:

			break;
		}
	
	}
}
