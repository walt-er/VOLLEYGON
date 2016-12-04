using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArenaManagerScript : MonoBehaviour {


	private int markerPos = 0;
	private float[] markerYPositions  = {7.4f, 3.7f, 0f, -3.7f, -7.4f};
	private float[] markerXPositions = { -10f, -8f };
	private string jumpButton1 = "Jump_P1";
	private string gravButton1 = "Grav_P1";
	private string vertAxis1 = "Vertical_P1";
	private string jumpButton2 = "Jump_P2";
	private string gravButton2 = "Grav_P2";
	private string vertAxis2 = "Vertical_P2";
	private string jumpButton3 = "Jump_P3";
	private string gravButton3 = "Grav_P3";
	private string vertAxis3 = "Vertical_P3";
	private string jumpButton4 = "Jump_P4";
	private string gravButton4 = "Grav_P4";
	private string vertAxis4 = "Vertical_P4";
	public GameObject marker;
	private bool axis1InUse = false;
	private bool axis2InUse = false;
	private bool axis3InUse = false;
	private bool axis4InUse = false;
	private int numberOfArenas = 9;
	private bool locked = false;
	public AudioClip tickUp;
	public AudioClip tickDown;

	private AudioSource audio;

	Axis va1;
	Axis va2;
	Axis va3;
	Axis va4;

	Axis ha1;
	Axis ha2;
	Axis ha3;
	Axis ha4;

	//VertAxis[] verticalAxes;
	List<Axis> verticalAxes = new List<Axis>();
	List<Axis> horizontalAxes = new List<Axis>();

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		locked = false;

		va1 = new Axis("Vertical_P1");
		va2 = new Axis("Vertical_P2");
		va3 = new Axis("Vertical_P3");
		va4 = new Axis("Vertical_P4");

		verticalAxes.Add (va1);
		verticalAxes.Add (va2);
		verticalAxes.Add (va3);
		verticalAxes.Add (va4);

		ha1 = new Axis("Horizontal_P1");
		ha2 = new Axis("Horizontal_P2");
		ha3 = new Axis("Horizontal_P3");
		ha4 = new Axis("Horizontal_P4");

		horizontalAxes.Add (ha1);
		horizontalAxes.Add (ha2);
		horizontalAxes.Add (ha3);
		horizontalAxes.Add (ha4);


	}
	
	// Update is called once per frame
	void Update () {
		if (!locked) {
			foreach (Axis va in verticalAxes) {
				if (Input.GetAxisRaw (va.axisName) == -1) {
					if (va.axisInUse == false) {
						// Call your event function here.
						va.axisInUse = true;
						markerPos++;
						updateMarkerPos ();
						audio.PlayOneShot (tickUp);
					}
				}

				if (Input.GetAxisRaw (va.axisName) == 1) {
					if (va.axisInUse == false) {
						// Call your event function here.
						va.axisInUse = true;
						markerPos--;
						audio.PlayOneShot (tickDown);
						updateMarkerPos ();
					}
				}

				if (Input.GetAxisRaw (va.axisName) == 0) {
					va.axisInUse = false;
				}
			}

			foreach (Axis va in horizontalAxes) {
				if (Input.GetAxisRaw (va.axisName) == -1) {
					if (va.axisInUse == false) {
						// Call your event function here.
						va.axisInUse = true;
						markerPos += 5;
						updateMarkerPos ();
						audio.PlayOneShot (tickUp);

					}
				}

				if (Input.GetAxisRaw (va.axisName) == 1) {
					if (va.axisInUse == false) {
						// Call your event function here.
						va.axisInUse = true;
						markerPos += 5;
						audio.PlayOneShot (tickDown);
						updateMarkerPos ();
					}
				}

				if (Input.GetAxisRaw (va.axisName) == 0) {
					va.axisInUse = false;
				}
			}

		

			if (Input.GetButtonDown (jumpButton1)) {
				// log which arena
				if (markerPos == 0) {
					Debug.Log ("choosing random level");
					DataManagerScript.arenaType = Random.Range (0, numberOfArenas);
				} else {
					DataManagerScript.arenaType = markerPos;
				}
				StartCoroutine ("NextScene");
			}
			if (Input.GetButtonDown (gravButton1)) {
				// log which arena
				if (markerPos == 0) {
					DataManagerScript.arenaType = Random.Range (0, numberOfArenas);
				} else {
					DataManagerScript.arenaType = markerPos;
				}
				StartCoroutine ("NextScene");
			}



			if (Input.GetButtonDown (jumpButton2)) {
				// log which arena
				if (markerPos == 0) {
					DataManagerScript.arenaType = Random.Range (0, numberOfArenas);
				} else {
					DataManagerScript.arenaType = markerPos;
				}
				StartCoroutine ("NextScene");
			}
			if (Input.GetButtonDown (gravButton2)) {
				// log which arena
				if (markerPos == 0) {
					DataManagerScript.arenaType = Random.Range (0, numberOfArenas);
				} else {
					DataManagerScript.arenaType = markerPos;
				}
				StartCoroutine ("NextScene");
			}


		
			if (Input.GetButtonDown (jumpButton3)) {
				// log which arena
				if (markerPos == 0) {
					DataManagerScript.arenaType = Random.Range (0, numberOfArenas);
				} else {
					DataManagerScript.arenaType = markerPos;
				}
				StartCoroutine ("NextScene");
			}
			if (Input.GetButtonDown (gravButton3)) {
				// log which arena
				if (markerPos == 0) {
					DataManagerScript.arenaType = Random.Range (0, numberOfArenas);
				} else {
					DataManagerScript.arenaType = markerPos;
				}
				StartCoroutine ("NextScene");
			}
				
			if (Input.GetButtonDown (jumpButton4)) {
				// log which arena
				if (markerPos == 0) {
					DataManagerScript.arenaType = Random.Range (0, numberOfArenas);
				} else {
					DataManagerScript.arenaType = markerPos;
				}
				StartCoroutine ("NextScene");
			}
			if (Input.GetButtonDown (gravButton4)) {
				// log which arena
				if (markerPos == 0) {
					DataManagerScript.arenaType = Random.Range (0, numberOfArenas);
				} else {
					DataManagerScript.arenaType = markerPos;
				}
				StartCoroutine ("NextScene");
			}
		}
	}

	IEnumerator NextScene(){
		locked = true;
		float fadeTime = GameObject.Find ("FadeCurtain").GetComponent<FadingScript> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel ("proTipScene");
	}

	void updateMarkerPos(){
		
		if (markerPos < 0) {
			markerPos = numberOfArenas;
		}
		markerPos = markerPos % (numberOfArenas + 1);
		Debug.Log (markerPos);
		float posX;
		float posY;

		if (markerPos > 4) {
			posX = markerXPositions [1];
			posY = markerYPositions [markerPos - 5];

		} else {
			posX = markerXPositions [0];
			posY = markerYPositions [markerPos];
		}
		Vector3 tempPos = new Vector3(posX, posY, 1f);
//		
		marker.transform.position = tempPos;
		Debug.Log (markerPos);
	}
}
