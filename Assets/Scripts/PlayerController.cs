using UnityEngine;
using System.Collections;
using PigeonCoopToolkit.Effects.Trails;

public class PlayerController : MonoBehaviour {

	public float speed = 5f;
	public float spinPower = -150f;
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
	public int playerID;
	public Mesh meshTypeOne;
	public Mesh meshTypeTwo;
	public int playerType = 0;
	public PolygonCollider2D trianglePC, trapezoidPC;

	public TextMesh pandemoniumCounter;

	public GameObject trail;

	public Sprite squareSprite;
	public Sprite circleSprite;
	public Sprite triangleSprite;
	public Sprite trapezoidSprite;

	public float penaltyTimer;
	private bool penaltyTimerActive = false;

	private float speedPowerupTimer;
	private bool speedPowerupActive = false; 

	private float sizePowerupTimer;
	private bool sizePowerupActive = false; 

	private float pandemoniumTimer;
	private bool pandemoniumPowerupActive = false;

	// Different base stats for each playerType

	private float squareJumpPower = 2000f;
	private float squareSpeed = 15f;
	private float squareSpinRate = -150f;

	private float circleJumpPower = 2200f;
	private float circleSpeed = 18f;
	private float circleSpinRate = -100f;

	private float triangleJumpPower = 2000f;
	private float triangleSpeed = 18f;
	private float triangleSpinRate = -200f;

	private float trapezoidJumpPower = 1800f;
	private float trapezoidSpeed = 12f;
	private float trapezoidSpinRate = -150f;


	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		PolygonCollider2D pg = GetComponent<PolygonCollider2D> ();
		rb.gravityScale = startingGrav;
		startMass = rb.mass;

		pandemoniumCounter.GetComponent<TextMesh> ().color = new Vector4(0f, 0f, 0f, 0f);


		if (playerType == 0) {
			gameObject.GetComponent<BoxCollider2D> ().enabled = true;
			//gameObject.GetComponent<CircleCollider2D> ().enabled = true;
			//gameObject.GetComponent<MeshFilter> ().mesh = meshTypeOne;
			gameObject.GetComponent<SpriteRenderer> ().sprite = squareSprite;

			jumpPower = squareJumpPower;
			speed = squareSpeed;
			spinPower = squareSpinRate;
		}

		if (playerType == 1) {
			gameObject.GetComponent<CircleCollider2D> ().enabled = true;
		//	gameObject.GetComponent<MeshFilter> ().mesh = meshTypeTwo;
			gameObject.GetComponent<SpriteRenderer> ().sprite = circleSprite;
			jumpPower = circleJumpPower;
			speed = circleSpeed;
			spinPower = circleSpinRate;
		}

		if (playerType == 2) {
			trianglePC.enabled = true;
			//gameObject.GetComponent<MeshFilter> ().mesh = meshTypeTwo;
			gameObject.GetComponent<SpriteRenderer> ().sprite = triangleSprite;
			jumpPower = triangleJumpPower;
			speed = triangleSpeed;
			spinPower = triangleSpinRate;
		}

		if (playerType == 3) {
			trapezoidPC.enabled = true;
			//gameObject.GetComponent<MeshFilter> ().mesh = meshTypeTwo;
			gameObject.GetComponent<SpriteRenderer> ().sprite = trapezoidSprite;
			jumpPower = trapezoidJumpPower;
			speed = trapezoidSpeed;
			spinPower = trapezoidSpinRate;
		}

		startJumpPower = jumpPower;
		startSpeed = speed; 

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
			GetComponent<Rigidbody2D> ().angularVelocity = (moveHorizontal * spinPower * rb.gravityScale);
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

		ClampPosition ();


		ManagePowerups ();
	}

	void checkPenalty(){
		switch (team) {
		case 1:
			if (transform.position.x > -1.0f){
				penaltyTimerActive = true;
				penaltyTimer = 10f;
				gameObject.GetComponent<SpriteRenderer> ().enabled = false;
				trail.GetComponent<Trail>().ClearSystem (true);
				trail.SetActive (false);
				gameObject.GetComponent<BoxCollider2D> ().enabled = false;


			}
			break;

		case 2:
			if (transform.position.x < 1.0f){
				penaltyTimerActive = true;
				penaltyTimer = 10f;
				gameObject.GetComponent<SpriteRenderer> ().enabled = false;
				trail.GetComponent<Trail>().ClearSystem (true);
				trail.SetActive (false);
				gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			}

			break;
		}
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "ScoringBoundary" || coll.gameObject.tag == "Player") {
			Debug.Log ("a collision!");
			isJumping = false;
			Debug.Log (isJumping);
		}

		if (coll.gameObject.tag == "Ball") {
			// update the ball's touch information
			BallScript ball = coll.gameObject.GetComponent<BallScript>();
			ball.secondToLastTouch = ball.lastTouch;
			ball.lastTouch = playerID;
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

	void ClampPosition(){

		// Only clamp position if pandemonium is not active;
		if (!pandemoniumPowerupActive){
			var pos = transform.position;
			if (team == 1) {
				pos.x = Mathf.Clamp (transform.position.x, -200.0f, -1.0f);
				transform.position = pos;
			} else if (team == 2) {
				pos.x = Mathf.Clamp (transform.position.x, 1f, 200f);
				transform.position = pos;
			}
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

		if (pandemoniumPowerupActive){
			pandemoniumTimer -= Time.deltaTime;
			pandemoniumCounter.GetComponent<TextMesh> ().color = new Vector4(1f, 1f, 1f, .25f);
			pandemoniumCounter.GetComponent<TextMesh> ().text = Mathf.Floor(pandemoniumTimer).ToString();
			if (pandemoniumTimer <= 0) {
			    pandemoniumCounter.GetComponent<TextMesh> ().color = new Vector4(0f, 0f, 0f, 0f);
				pandemoniumPowerupActive = false;
				// run 'punishment' check if player is offsides.
				checkPenalty();
			}
		}

		if (penaltyTimerActive) {
			penaltyTimer -= Time.deltaTime;

			if (penaltyTimer <= 0) {
				penaltyTimerActive = false;
				ReturnFromPenalty ();
			}
		}
	}

	void ReturnFromPenalty(){
		switch (team) {
		case 1:
			transform.position = new Vector3 (-6f, 0f, -0.5f);


			break;

		case 2:
			transform.position = new Vector3 (6f, 0f, -0.5f);

			break;
		}
			rb.velocity = Vector3.zero;
			rb.gravityScale = startingGrav;
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		
			trail.SetActive (true);
			trail.GetComponent<Trail>().ClearSystem (true);
			gameObject.GetComponent<BoxCollider2D> ().enabled = true;

	}

	void ApplyPowerup(int whichPowerup){
		Debug.Log (whichPowerup);
		switch (whichPowerup) {

		case 1:
			speedPowerupActive = true;
			speed = 22f;
			speedPowerupTimer = 20f; 

			break;

		case 2:
			
			sizePowerupActive = true;
			gameObject.transform.localScale = new Vector3 (2f, 2f, 1f);
			rb.mass = startMass * 2f;
			jumpPower = startJumpPower * 1.75f;
			sizePowerupTimer = 20f;

			break;
		
		case 3:
			pandemoniumPowerupActive = true;
			pandemoniumTimer = 20f;
			break;
		default:
			

			break;
		}
	
	}
}
