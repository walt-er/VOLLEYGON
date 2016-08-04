using UnityEngine;
using System.Collections;

public class ArenaManagerScript : MonoBehaviour {


	private int markerPos = 0;
	private float[] markerPositions  = {7.4f, 3.7f, 0f, -3.7f, -7.4f};
	private string jumpButton1 = "Jump_P1";
	private string gravButton1 = "Grav_P1";
	private string horizAxis1 = "Vertical_P1";
	private string jumpButton2 = "Jump_P2";
	private string gravButton2 = "Grav_P2";
	private string horizAxis2 = "Vertical_P2";
	private string jumpButton3 = "Jump_P3";
	private string gravButton3 = "Grav_P3";
	private string horizAxis3 = "Vertical_P3";
	private string jumpButton4 = "Jump_P4";
	private string gravButton4 = "Grav_P4";
	private string horizAxis4 = "Vertical_P4";
	public GameObject marker;
	private bool axis1InUse = false;
	private bool axis2InUse = false;
	private bool axis3InUse = false;
	private bool axis4InUse = false;

	public AudioClip tickUp;
	public AudioClip tickDown;

	private AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetAxisRaw (horizAxis1) == -1) {


			if (axis1InUse == false) {
				// Call your event function here.
				axis1InUse = true;
				markerPos++;
				updateMarkerPos ();
				audio.PlayOneShot (tickUp);
			}
		}

		if (Input.GetAxisRaw (horizAxis1) == 1) {


			if (axis1InUse == false) {
				// Call your event function here.
				axis1InUse = true;
				markerPos--;
				audio.PlayOneShot (tickDown);
				updateMarkerPos ();
			}
		}

		if (Input.GetAxisRaw (horizAxis1) == 0) {


			axis1InUse = false;
		}

		if (Input.GetButtonDown (jumpButton1)) {
			// log which arena
			if (markerPos == 4) {
				Debug.Log ("choosing random level");
				DataManagerScript.arenaType = Random.Range (0, 4);
			} else {
				DataManagerScript.arenaType = markerPos;
			}
			Application.LoadLevel ("proTipScene");
		}
		if (Input.GetButtonDown (gravButton1)) {
			// log which arena
			if (markerPos == 4) {
				DataManagerScript.arenaType = Random.Range (0, 4);
			} else {
				DataManagerScript.arenaType = markerPos;
			}
			Application.LoadLevel ("proTipScene");
		}

		if (Input.GetAxisRaw (horizAxis2) == -1) {


			if (axis2InUse == false) {
				// Call your event function here.
				axis2InUse = true;
				markerPos++;
				updateMarkerPos ();

			}
		}

		if (Input.GetAxisRaw (horizAxis2) == 1) {


			if (axis2InUse == false) {
				// Call your event function here.
				axis2InUse = true;
				markerPos--;
				updateMarkerPos ();
			}
		}

		if (Input.GetAxisRaw (horizAxis2) == 0) {


			axis2InUse = false;
		}

		if (Input.GetButtonDown (jumpButton2)) {
			// log which arena
			if (markerPos == 4) {
				DataManagerScript.arenaType = Random.Range (0, 4);
			} else {
				DataManagerScript.arenaType = markerPos;
			}
			Application.LoadLevel ("proTipScene");
		}
		if (Input.GetButtonDown (gravButton2)) {
			// log which arena
			if (markerPos == 4) {
				DataManagerScript.arenaType = Random.Range (0, 4);
			} else {
				DataManagerScript.arenaType = markerPos;
			}
			Application.LoadLevel ("proTipScene");
		}


		if (Input.GetAxisRaw (horizAxis3) == -1) {


			if (axis3InUse == false) {
				// Call your event function here.
				axis3InUse = true;
				markerPos++;
				updateMarkerPos ();

			}
		}

		if (Input.GetAxisRaw (horizAxis3) == 1) {


			if (axis3InUse == false) {
				// Call your event function here.
				axis3InUse = true;
				markerPos--;
				updateMarkerPos ();
			}
		}

		if (Input.GetAxisRaw (horizAxis3) == 0) {


			axis3InUse = false;
		}

		if (Input.GetButtonDown (jumpButton3)) {
			// log which arena
			if (markerPos == 4) {
				DataManagerScript.arenaType = Random.Range (0, 4);
			} else {
				DataManagerScript.arenaType = markerPos;
			}
			Application.LoadLevel ("proTipScene");
		}
		if (Input.GetButtonDown (gravButton3)) {
			// log which arena
			if (markerPos == 4) {
				DataManagerScript.arenaType = Random.Range (0, 4);
			} else {
				DataManagerScript.arenaType = markerPos;
			}
			Application.LoadLevel ("proTipScene");
		}


		if (Input.GetAxisRaw (horizAxis4) == -1) {


			if (axis4InUse == false) {
				// Call your event function here.
				axis4InUse = true;
				markerPos++;
				updateMarkerPos ();

			}
		}

		if (Input.GetAxisRaw (horizAxis4) == 1) {


			if (axis4InUse == false) {
				// Call your event function here.
				axis4InUse = true;
				markerPos--;
				updateMarkerPos ();
			}
		}

		if (Input.GetAxisRaw (horizAxis4) == 0) {


			axis4InUse = false;
		}

		if (Input.GetButtonDown (jumpButton4)) {
			// log which arena
			if (markerPos == 4) {
				DataManagerScript.arenaType = Random.Range (0, 4);
			} else {
				DataManagerScript.arenaType = markerPos;
			}
			Application.LoadLevel ("proTipScene");
		}
		if (Input.GetButtonDown (gravButton4)) {
			// log which arena
			if (markerPos == 4) {
				DataManagerScript.arenaType = Random.Range (0, 4);
			} else {
				DataManagerScript.arenaType = markerPos;
			}
			Application.LoadLevel ("proTipScene");
		}
	}

	void updateMarkerPos(){
		
		if (markerPos < 0) {
			markerPos = 4;
		}
		markerPos = markerPos % 5;
		Vector3 tempPos = new Vector3(marker.transform.position.x, markerPositions[markerPos], 1f);
//		
		marker.transform.position = tempPos;
		Debug.Log (markerPos);
	}
}
