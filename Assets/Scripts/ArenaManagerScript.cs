using UnityEngine;
using System.Collections;

public class ArenaManagerScript : MonoBehaviour {


	private int markerPos = 0;
	private float[] markerPositions  = {-15f, -5f, 5f, 15f};
	private string jumpButton1 = "Jump_P1";
	private string gravButton1 = "Grav_P1";
	private string horizAxis1 = "Horizontal_P1";
	private string jumpButton2 = "Jump_P2";
	private string gravButton2 = "Grav_P2";
	private string horizAxis2 = "Horizontal_P2";
	private string jumpButton3 = "Jump_P3";
	private string gravButton3 = "Grav_P3";
	private string horizAxis3 = "Horizontal_P3";
	private string jumpButton4 = "Jump_P4";
	private string gravButton4 = "Grav_P4";
	private string horizAxis4 = "Horizontal_P4";
	public GameObject marker;
	private bool axis1InUse = false;
	private bool axis2InUse = false;
	private bool axis3InUse = false;
	private bool axis4InUse = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetAxisRaw (horizAxis1) == 1) {


			if (axis1InUse == false) {
				// Call your event function here.
				axis1InUse = true;
				markerPos++;
				updateMarkerPos ();

			}
		}

		if (Input.GetAxisRaw (horizAxis1) == -1) {


			if (axis1InUse == false) {
				// Call your event function here.
				axis1InUse = true;
				markerPos--;
				updateMarkerPos ();
			}
		}

		if (Input.GetAxisRaw (horizAxis1) == 0) {


			axis1InUse = false;
		}

		if (Input.GetButtonDown (jumpButton1)) {
			// log which arena
			DataManagerScript.arenaType = markerPos;
			Application.LoadLevel ("gameScene");
		}
		if (Input.GetButtonDown (gravButton1)) {
			// log which arena
			DataManagerScript.arenaType = markerPos;
			Application.LoadLevel ("gameScene");
		}

		if (Input.GetAxisRaw (horizAxis2) == 1) {


			if (axis2InUse == false) {
				// Call your event function here.
				axis2InUse = true;
				markerPos++;
				updateMarkerPos ();

			}
		}

		if (Input.GetAxisRaw (horizAxis2) == -1) {


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
			DataManagerScript.arenaType = markerPos;
			Application.LoadLevel ("gameScene");
		}
		if (Input.GetButtonDown (gravButton2)) {
			// log which arena
			DataManagerScript.arenaType = markerPos;
			Application.LoadLevel ("gameScene");
		}


		if (Input.GetAxisRaw (horizAxis3) == 1) {


			if (axis3InUse == false) {
				// Call your event function here.
				axis3InUse = true;
				markerPos++;
				updateMarkerPos ();

			}
		}

		if (Input.GetAxisRaw (horizAxis3) == -1) {


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
			DataManagerScript.arenaType = markerPos;
			Application.LoadLevel ("gameScene");
		}
		if (Input.GetButtonDown (gravButton3)) {
			// log which arena
			DataManagerScript.arenaType = markerPos;
			Application.LoadLevel ("gameScene");
		}


		if (Input.GetAxisRaw (horizAxis4) == 1) {


			if (axis4InUse == false) {
				// Call your event function here.
				axis4InUse = true;
				markerPos++;
				updateMarkerPos ();

			}
		}

		if (Input.GetAxisRaw (horizAxis4) == -1) {


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
			DataManagerScript.arenaType = markerPos;
			Application.LoadLevel ("gameScene");
		}
		if (Input.GetButtonDown (gravButton4)) {
			// log which arena
			DataManagerScript.arenaType = markerPos;
			Application.LoadLevel ("gameScene");
		}
	}

	void updateMarkerPos(){
		if (markerPos < 0) {
			markerPos = 3;
		}
		markerPos = markerPos % 4;
		Vector3 tempPos = new Vector3(markerPositions[markerPos], marker.transform.position.y, 1f);
//		
		marker.transform.position = tempPos;
	}
}
