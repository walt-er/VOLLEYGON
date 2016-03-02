using UnityEngine;
using System.Collections;

public class ArenaManagerScript : MonoBehaviour {


	private int markerPos = 0;
	private float[] markerPositions  = {-15f, -5f, 5f, 15f};
	private string jumpButton1 = "Jump_P1";
	private string gravButton1 = "Grav_P1";
	private string horizAxis1 = "Horizontal_P1";
	public GameObject marker;
	private bool axis1InUse = false;
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
