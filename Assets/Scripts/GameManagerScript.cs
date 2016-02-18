using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

	public float gravTimer;
	public float gameTimer;
	private bool timerRunning = false;

	// Static singleton property
	public static GameManagerScript Instance { get; private set; }


	// Use this for initialization
	void Start () {
		launchTimer ();

	}

	void launchTimer(){
		timerRunning = true;

	}
	// Update is called once per frame
	void Update () {
		if (timerRunning) {
			gameTimer -= Time.deltaTime;
		}	
	}
}
