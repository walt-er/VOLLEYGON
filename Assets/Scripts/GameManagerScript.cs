using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

	public float gravTimer;
	public float gameTimer;
	private bool timerRunning = false;
	public int teamOneScore;
	public int teamTwoScore;

	// Static singleton property
	public static GameManagerScript Instance { get; private set; }


	// Use this for initialization
	void Start () {
		launchTimer ();

	}
	void Awake()
	{
		// Save a reference to the AudioHandler component as our singleton instance
		Instance = this;
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
