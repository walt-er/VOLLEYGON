using UnityEngine;
using System.Collections;

public class TitleManagerScript : MonoBehaviour {

	public string jumpButton1 = "Jump_P1";
	public string gravButton1 = "Grav_P1";
	public string jumpButton2 = "Jump_P2";
	public string gravButton2 = "Grav_P2";
	public string jumpButton3 = "Jump_P3";
	public string gravButton3 = "Grav_P3";
	public string jumpButton4 = "Jump_P4";
	public string gravButton4 = "Grav_P4";


	// Use this for initialization
	void Start () {
	
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
