using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleManagerScript : MonoBehaviour {

	public string jumpButton1 = "Jump_P1";
	public string gravButton1 = "Grav_P1";
	public string jumpButton2 = "Jump_P2";
	public string gravButton2 = "Grav_P2";
	public string jumpButton3 = "Jump_P3";
	public string gravButton3 = "Grav_P3";
	public string jumpButton4 = "Jump_P4";
	public string gravButton4 = "Grav_P4";
	private int markerPos = 0;
	private float[] markerPositions  = {-15f, -5f, 5f, 15f};

	private string horizAxis1 = "Horizontal_P1";
	private string horizAxis2 = "Horizontal_P2";
	private string horizAxis3 = "Horizontal_P3";
	private string horizAxis4 = "Horizontal_P4";
	public GameObject marker;
	private bool axis1InUse = false;
	private bool axis2InUse = false;
	private bool axis3InUse = false;
	private bool axis4InUse = false;

	public Text versionText;



	// Use this for initialization
	void Start () {
		versionText.text = DataManagerScript.version;
		DataManagerScript.Instance.ResetStats ();
		DataManagerScript.Instance.ResetPlayerTypes ();
		//Cursor.visible = false;
		//Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown (jumpButton1)) {
			Application.LoadLevel("choosePlayerScene");
		}
		if (Input.GetButtonDown (gravButton1)) {
			Application.LoadLevel("choosePlayerScene");
		}
		if (Input.GetButtonDown (jumpButton2)) {
			Application.LoadLevel("choosePlayerScene");
		}
		if (Input.GetButtonDown (gravButton2)) {
			Application.LoadLevel("choosePlayerScene");
		}
		if (Input.GetButtonDown (jumpButton3)) {
			Application.LoadLevel("choosePlayerScene");
		}
		if (Input.GetButtonDown (gravButton3)) {
			Application.LoadLevel("choosePlayerScene");
		}
		if (Input.GetButtonDown (jumpButton4)) {
			Application.LoadLevel("choosePlayerScene");
		}
		if (Input.GetButtonDown (gravButton4)) {
			Application.LoadLevel("choosePlayerScene");
		}
	}
}
