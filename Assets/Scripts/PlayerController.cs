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
	private string horiz_Xbox;
	private string jumpButton_Xbox;
	private string gravButton_Xbox;
	public int team = 1;
	private bool inPenalty;
	public float startingGrav = 1;
	public int playerID;
	public Mesh meshTypeOne;
	public Mesh meshTypeTwo;
	public int playerType = 0;
	public PolygonCollider2D trianglePC, trapezoidPC, squarePC, rectanglePC, starPC;
	private bool canMove;
	private string playerColor;

	public ParticleSystem ps;

	public GameObject penaltyExplosion; 

	public AudioClip jumpSound1;
	public AudioClip jumpSound2;
	public AudioClip landSound;
	public AudioClip changeGravSound1;
	public AudioClip changeGravSound2;
	public AudioClip collideWithBallSound1;
	public AudioClip collideWithBallSound2;
	public AudioClip collideWithBallSoundBig;
	public AudioClip playerExplode;
	public AudioClip powerupSound;

	public AudioClip speedUpSFX1;
	public AudioClip speedUpSFX2;
	public AudioClip speedUpSFX3;

	public AudioClip sizeUpSFX1;
	public AudioClip sizeUpSFX2;

	public AudioClip pandemoniumSFX1;
	public AudioClip pandemoniumSFX2;

	public Material masterColor;
	public Material player1Material;
	public Material player2Material;
	public Material player3Material;
	public Material player4Material;

	public TextMesh pandemoniumCounter;

	public GameObject trail;

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

	private float trapezoidJumpPower = 2000f;
	private float trapezoidSpeed = 15f;
	private float trapezoidSpinRate = -150f;

	private float rectangleJumpPower = 2000f;
	private float rectangleSpeed = 13f;
	private float rectangleSpinRate = -150f;

	private float starJumpPower = 2000f;
	private float starSpeed = 15f;
	private float starSpinRate = -150f;

	Rigidbody2D rb;
	MeshRenderer mr;

	// Use this for initialization
	void Start () {

		gravButton_Xbox = gravButton + "_Xbox";
		jumpButton_Xbox = jumpButton + "_Xbox";
		horiz_Xbox = horiz + "_Xbox";

		ps = transform.Find("ssps").GetComponent<ParticleSystem> ();
		ps.Stop ();
		rb = GetComponent<Rigidbody2D>();
		mr = GetComponent<MeshRenderer> ();
		PolygonCollider2D pg = GetComponent<PolygonCollider2D> ();
		rb.gravityScale = startingGrav;
		startMass = rb.mass;
		canMove = true;
		pandemoniumCounter.GetComponent<TextMesh> ().color = new Vector4(0f, 0f, 0f, 0f);

		//GetComponent<MeshRenderer> ().material = masterColor;
		inPenalty = false;
		// assign player color
		switch (playerID) {
		case 1:
			playerColor = "1069A8";
			break;
		case 2:
			playerColor = "7CBEE8";
			break;
		case 3:
			playerColor = "D63236";
			break;
		case 4:
			playerColor = "D97A7B";
			break;
		}

		if (playerType == 0) {
		   squarePC.enabled = true;
		//	gameObject.GetComponent<SpriteRenderer> ().sprite = squareSprite;

			jumpPower = squareJumpPower;
			speed = squareSpeed;
			spinPower = squareSpinRate;
			IncreasePlayCount ("squarePlays");
		}

		if (playerType == 1) {
		    gameObject.GetComponent<CircleCollider2D> ().enabled = true;
		//	gameObject.GetComponent<SpriteRenderer> ().sprite = circleSprite;
			// this is a special case for circle
			Transform circle = transform.Find("Circle");
			circle.gameObject.SetActive (true);
			jumpPower = circleJumpPower;
			speed = circleSpeed;
			spinPower = circleSpinRate;
			IncreasePlayCount ("circlePlays");
		}

		if (playerType == 2) {
	        trianglePC.enabled = true;
		//	gameObject.GetComponent<SpriteRenderer> ().sprite = triangleSprite;
			jumpPower = triangleJumpPower;
			speed = triangleSpeed;
			spinPower = triangleSpinRate;
			IncreasePlayCount ("trianglePlays");
		}

		if (playerType == 3) {
		    trapezoidPC.enabled = true;
		//	gameObject.GetComponent<SpriteRenderer> ().sprite = trapezoidSprite;
			jumpPower = trapezoidJumpPower;
			speed = trapezoidSpeed;
			spinPower = trapezoidSpinRate;
			IncreasePlayCount ("trapezoidPlays");
		}

		if (playerType == 4) {
			rectanglePC.enabled = true;
			//	gameObject.GetComponent<SpriteRenderer> ().sprite = trapezoidSprite;
			jumpPower = rectangleJumpPower;
			speed = rectangleSpeed;
			spinPower = rectangleSpinRate;
			IncreasePlayCount ("rectanglePlays");
		}

		if (playerType == 5) {
			starPC.enabled = true;
			//	gameObject.GetComponent<SpriteRenderer> ().sprite = trapezoidSprite;
			jumpPower = starJumpPower;
			speed = starSpeed;
			spinPower = starSpinRate;
			IncreasePlayCount ("starPlays");
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

	void IncreasePlayCount(string whichType){
		int tempTotal = PlayerPrefs.GetInt (whichType);
		tempTotal += 1;
		PlayerPrefs.SetInt (whichType, tempTotal);
	}

	IEnumerator Flash() {
		Debug.Log ("flash firing");
		for (float f = .8f; f >= 0; f -= 0.04f) {
			GetComponent<SpriteRenderer>().material.SetFloat ("_FlashAmount", f);
			yield return null;
		}
		yield break; //Is this even needed?
	}


	void FixedUpdate () {
		
		float moveHorizontal;

		if (DataManagerScript.xboxMode) {
			moveHorizontal = Input.GetAxis (horiz_Xbox);
		} else {
			moveHorizontal = Input.GetAxis (horiz);
		}
		//Debug.Log (moveHorizontal);
//		float moveVertical = Input.GetAxis ("Vertical"); // these return between 0 and 1
//		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
//		rigidbody.velocity.x = moveHorizontal * speed;
		//GetComponent<Rigidbody2D>().AddTorque(moveHorizontal * -8f);

		if (isJumping) {
			GetComponent<Rigidbody2D> ().angularVelocity = (moveHorizontal * spinPower * rb.gravityScale);
		}
		Vector3 v3 = GetComponent<Rigidbody2D>().velocity;
		v3.x = moveHorizontal * speed;
//		

		//v3.z = 0.0f;
		//if (canMove) {
			GetComponent<Rigidbody2D> ().velocity = v3;
		//}
//		Vector2 v2 = new Vector2(moveHorizontal*speed*100f,0f);
//		GetComponent<Rigidbody2D> ().AddForce (v2);

		float f = Mathf.Clamp(GetComponent<Rigidbody2D> ().velocity.x, -speed, speed);
//		Debug.Log (GetComponent<Rigidbody2D> ().velocity.x);
		//		rigidbody.position = new Vector3
//			(
//				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax),
//				0.5f,
//				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
//				);
//		Vector3 v4 = GetComponent<Rigidbody2D>().velocity;
//		v4.x = f;
//
//		GetComponent<Rigidbody2D>().velocity = v4;

	}

	void Update(){
		//Debug.Log (canMove);
		if (!inPenalty) {
			if (Input.GetButtonDown (jumpButton) || Input.GetButtonDown(jumpButton_Xbox)) {
				//Debug.Log ("Jump hit");
				if (isJumping == false) {
					Vector3 jumpForce = new Vector3 (0f, jumpPower * rb.gravityScale, 0f);
					rb.AddForce (jumpForce);
					SoundManagerScript.instance.RandomizeSfx (jumpSound1, jumpSound2);
					isJumping = true;
				}
			}

			if (Input.GetButtonDown (gravButton) || Input.GetButtonDown(gravButton_Xbox)) {
				rb.gravityScale *= -1f;
				SoundManagerScript.instance.RandomizeSfx (changeGravSound1, changeGravSound2);
				StartCoroutine ("Flash");

			}
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
				//gameObject.GetComponent<SpriteRenderer> ().enabled = false;
				DisableShapeAndCollider ();
				trail.GetComponent<Trail>().ClearSystem (true);
				trail.SetActive (false);
			//	gameObject.GetComponent<BoxCollider2D> ().enabled = false;

				FirePenaltyExplosion();
				inPenalty = true;
			}
			break;

		case 2:
			if (transform.position.x < 1.0f){
				penaltyTimerActive = true;
				penaltyTimer = 10f;
				DisableShapeAndCollider ();
				trail.GetComponent<Trail>().ClearSystem (true);
				trail.SetActive (false);
				FirePenaltyExplosion();
				inPenalty = true;
			}

			break;
		}

	
	}

	void DisableShapeAndCollider(){
		switch (playerType) {
		case 0:
			squarePC.enabled = false;
			break;
		case 1:
			//circle.enabled = false;
			gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			// this is a special case for circle
			Transform circle = transform.Find("Circle");
			circle.gameObject.SetActive (false);
			break;
		case 2:
			trianglePC.enabled = false;
			break;
		case 3:
			trapezoidPC.enabled = false;
			break;
		case 4: 
			rectanglePC.enabled = false;
			break;
		}
		mr.enabled = false;
	}

	void EnableShapeAndCollider(){
		
		switch (playerType) {
		case 0:
			squarePC.enabled = true;
			mr.enabled = true;
			break;
		case 1:
			//circle.enabled = false;
			gameObject.GetComponent<CircleCollider2D> ().enabled = true;
			// this is a special case for circle
			Transform circle = transform.Find("Circle");
			circle.gameObject.SetActive (true);
			break;
		case 2:
			trianglePC.enabled = true;
			mr.enabled = true;
			break;
		case 3:
			trapezoidPC.enabled = true;
			mr.enabled = true;
			break;
		case 4: 
			rectanglePC.enabled = true;
			mr.enabled = true;
			break;
		case 5:
			starPC.enabled = true;
			mr.enabled = true;
			break;
		}


	}


	void FirePenaltyExplosion(){
		Vector3 newPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		GameObject pe = (GameObject)Instantiate(penaltyExplosion, newPos, Quaternion.identity);
		SoundManagerScript.instance.PlaySingle (playerExplode);
		pe.SendMessage ("Config", playerColor);
	}
	void OnCollisionStay2D(Collision2D collisionInfo) {

		if (collisionInfo.gameObject.tag == "Playfield") {
		//	Debug.Log ("stay with playfield");
		//	GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			canMove = false;
		}
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "ScoringBoundary" || coll.gameObject.tag == "Player" || coll.gameObject.tag == "Obstacle") {
			//Debug.Log ("a collision!");
			isJumping = false;
		//	Debug.Log (isJumping);
			SoundManagerScript.instance.PlaySingle (landSound);
		}
			
		if (coll.gameObject.tag == "Playfield") {
		//	GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			canMove = false;
			//SoundManagerScript.instance.PlaySingle (landSound);
		}

		if (coll.gameObject.tag == "Ball") {
			// update the ball's touch information
			BallScript ball = coll.gameObject.GetComponent<BallScript>();
			ball.secondToLastTouch = ball.lastTouch;
			ball.lastTouch = playerID;

			// check relative velocity of collision
//			Debug.Log(coll.relativeVelocity.magnitude);
//			if (coll.relativeVelocity.magnitude > 40) {
//				SoundManagerScript.instance.PlaySingle (collideWithBallSoundBig);
//			} else {
//				SoundManagerScript.instance.RandomizeSfx (collideWithBallSound1, collideWithBallSound2);
//			}
		}

	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Powerup") {
			Debug.Log ("Happening");
			//Script other = coll.gameObject.GetComponent<NewPowerUpScript> ();
			int whichPowerup = coll.gameObject.GetComponent<NewPowerUpScript> ().powerupType;
			if (coll.gameObject.GetComponent<NewPowerUpScript> ().isAvailable) {
				coll.gameObject.GetComponent<NewPowerUpScript> ().FadeOut ();
				ApplyPowerup (whichPowerup);
				SoundManagerScript.instance.PlaySingle (powerupSound);
				// fade out all other powerups
				foreach (GameObject otherPowerup in GameObject.FindGameObjectsWithTag("Powerup")) {
				    otherPowerup.gameObject.GetComponent<NewPowerUpScript> ().FadeOut (false);
					//otherPowerup.SetActive(false);
				}
			}
			//Destroy (coll.gameObject);
		
		}
	}
	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == "ScoringBoundary" || coll.gameObject.tag == "Player") {
			//Debug.Log ("a collision ended!");
			if (!isJumping) {
					//isJumping = true;   
			}
			//Debug.Log (isJumping);
		}

		if (coll.gameObject.tag == "Playfield") {
		//	canMove = true;
		}

		if (coll.gameObject.tag == "Ball") {
		//	Debug.Log (coll.gameObject.GetComponent<Rigidbody2D> ().velocity.magnitude);
			var mag = coll.gameObject.GetComponent<Rigidbody2D> ().velocity.magnitude;
			if (mag > 30) {
				SoundManagerScript.instance.PlaySingle (collideWithBallSoundBig);
			} else {
				SoundManagerScript.instance.RandomizeSfx (collideWithBallSound1, collideWithBallSound2);
			}
		}
	}

	void ClampPosition(){

		// Only clamp position if pandemonium is not active;
		if (!pandemoniumPowerupActive){
			var pos = transform.position;
			if (team == 1) {
				// TODO: Make this dynamic based on raycasting
				pos.x = Mathf.Clamp (transform.position.x, -27.2f, -1.0f);
				transform.position = pos;
			} else if (team == 2) {
				pos.x = Mathf.Clamp (transform.position.x, 1f, 27.2f);
				transform.position = pos;
			}
		}
	}
	void ManagePowerups(){
		if (speedPowerupActive) {
			speedPowerupTimer -= Time.deltaTime;

			if (speedPowerupTimer <= 0){
				speedPowerupActive = false;
				ps.Stop ();
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
				// if midpoint marker is faded out, fade it back
				RestoreMidpointMarker();
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
			//gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			
			trail.SetActive (true);
			trail.GetComponent<Trail>().ClearSystem (true);
			//gameObject.GetComponent<BoxCollider2D> ().enabled = true;
			EnableShapeAndCollider();
			inPenalty = false;

	}

	void RestoreMidpointMarker(){
		foreach (GameObject mpm in GameObject.FindGameObjectsWithTag("MidpointMarker")) {
			//mpm.SetActive (false);
			iTween.FadeTo (mpm, 1.0f, .5f);
		}
	}
	IEnumerator PlaySFXWithDelay(int whichSFX){
		yield return new WaitForSeconds(.5f);
		switch (whichSFX) {
		case 1:
			SoundManagerScript.instance.RandomizeSfx (speedUpSFX1, speedUpSFX2, speedUpSFX3);
			break;
		case 2:
			SoundManagerScript.instance.RandomizeSfx (sizeUpSFX1, sizeUpSFX2);
			break;
		case 3:
			SoundManagerScript.instance.RandomizeSfx (pandemoniumSFX1, pandemoniumSFX2);
			break;
		case 4:
			break;
		}
	}
	void ApplyPowerup(int whichPowerup, bool playSFX = true){
		Debug.Log (whichPowerup);
		MusicManagerScript.Instance.StartFourth ();
		switch (whichPowerup) {

		case 1:
			speedPowerupActive = true;
			ps.Play ();
			speed = 20f; //was 22
			speedPowerupTimer = 20f; 
			if (playSFX){
				StartCoroutine ("PlaySFXWithDelay", 1);
			}
			break;

		case 2:
			
			sizePowerupActive = true;
			gameObject.transform.localScale = new Vector3 (2f, 2f, 1f);
			rb.mass = startMass * 2f;
			jumpPower = startJumpPower * 1.75f;
			sizePowerupTimer = 20f;
			if (playSFX){
				StartCoroutine ("PlaySFXWithDelay", 2);
			}
			break;
		
		case 3:
			pandemoniumPowerupActive = true;
			pandemoniumTimer = 20f;
			if (playSFX) {
				StartCoroutine ("PlaySFXWithDelay", 3);
			}
			break;

		case 4:
			int randomNum = Random.Range (1, 7);
			//int randomNum = 6;
			switch (randomNum) {
			case 1:
				ApplyPowerup (1);
				break;
			case 2: 
				ApplyPowerup (2);
				break;
			case 3: 
				ApplyPowerup (3);
				break;
			case 4: 
				Camera.main.GetComponent<ManageWiggleScript> ().ActivateWiggle (); 
				break;
			case 5:
				// broadcast to all players to activate pandemonium
				foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
					player.GetComponent<PlayerController> ().ApplyPowerup (3, false); 
					PlaySFXWithDelay (3);
				}
				foreach (GameObject mpm in GameObject.FindGameObjectsWithTag("MidpointMarker")) {
					//mpm.SetActive (false);
					iTween.FadeTo (mpm, 0f, .5f);
				}
				//Invoke ("RestoreMidpointMarker", 20f);


				//iTween.FadeTo (midpointMarker, 0.8f, .25f);
				break;
			case 6:
				foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
					player.GetComponent<PlayerController> ().ApplyPowerup (2, false); 
					PlaySFXWithDelay (2);
				}
				break;
			}
			break;
		
		}
	
	}
}
