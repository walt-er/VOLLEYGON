using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChallengeScript_1 : MonoBehaviour {

	private GameObject ballPrefab;
	private int deadBalls;

	void Awake(){
		
	}
		
	// Use this for initialization
	void Start () {
		deadBalls = 0;
		ballPrefab = ChallengeManagerScript.Instance.GetComponent<ChallengeManagerScript>().ballPrefab;
//		GameObject ball_1 = Instantiate(ballPrefab, new Vector3(3, 0, 0), Quaternion.identity);
//		GameObject ball_2 = Instantiate(ballPrefab, new Vector3(1, 2, 0), Quaternion.identity);
//		Debug.Log ("trying to launch");
//
//		IEnumerator coroutine_1 = ball_1.GetComponent<BallScript> ().LaunchBallWithDelay (1f, -3f, -2f);
//		StartCoroutine(coroutine_1);
//
//		IEnumerator coroutine_2 = ball_2.GetComponent<BallScript> ().LaunchBallWithDelay (1f, -3f, -2f);
//		StartCoroutine(coroutine_2);

//		ball_1.GetComponent<BallScript> ().LaunchBallWithDelay (1f, -3f, -2f);
//		ball_2.GetComponent<BallScript> ().LaunchBallWithDelay (1.5f, -6f, 0f);
		StartCoroutine(LaunchBalls(2f, 5));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ballDied(){
		Debug.Log ("the ball has died");
		deadBalls += 1;
		//ChallengeManagerScript.Instance.ChallengeFail ();
	}

	public void LaunchBall(float x, float y, float z){
		GameObject ball_1 = Instantiate(ballPrefab, new Vector3(x, y, z), Quaternion.identity);
		IEnumerator coroutine_1 = ball_1.GetComponent<BallScript> ().LaunchBallWithDelay (0f, -6f, -10f);
		StartCoroutine(coroutine_1);

		//ChallengeManagerScript.Instance.ChallengeFail();
	}



	public IEnumerator LaunchBalls(float interval, int invokeCount)
	{
		for (int i = 0; i < invokeCount; i++)
		{
			LaunchBall(UnityEngine.Random.Range(0, 3f),UnityEngine.Random.Range(-1, 2f),0f);

			yield return new WaitForSeconds(interval);
		}
	}
}

