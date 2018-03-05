using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualChallengeManagerScript : MonoBehaviour {

	private GameObject ballPrefab;

	void Awake(){
		
	}
		
	// Use this for initialization
	void Start () {
		ballPrefab = ChallengeManagerScript.Instance.GetComponent<ChallengeManagerScript>().ballPrefab;
		GameObject ball_1 = Instantiate(ballPrefab, new Vector3(3, 0, 0), Quaternion.identity);
		GameObject ball_2 = Instantiate(ballPrefab, new Vector3(1, 2, 0), Quaternion.identity);
		Debug.Log ("trying to launch");

		IEnumerator coroutine_1 = ball_1.GetComponent<BallScript> ().LaunchBallWithDelay (1f, -3f, -2f);
		StartCoroutine(coroutine_1);

		IEnumerator coroutine_2 = ball_2.GetComponent<BallScript> ().LaunchBallWithDelay (1f, -3f, -2f);
		StartCoroutine(coroutine_2);

//		ball_1.GetComponent<BallScript> ().LaunchBallWithDelay (1f, -3f, -2f);
//		ball_2.GetComponent<BallScript> ().LaunchBallWithDelay (1.5f, -6f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ballDied(){
		Debug.Log ("the ball has died");
		//ChallengeManagerScript.Instance.ChallengeFail ();
	}
}
