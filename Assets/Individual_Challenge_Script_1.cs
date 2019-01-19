using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Individual_Challenge_Script_1 : MonoBehaviour {

	private GameObject ballPrefab;
	private int deadBalls;
	public GameObject pad_1;
	public GameObject pad_2;
	public GameObject pad_3;

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
		//StartCoroutine(LaunchBalls(2f, 5));

		LaunchBall(0f,0f,0f);
	}
	
	// Update is called once per frame
	void Update () {
		
		//Check for victory
		if (!pad_1.active && !pad_2.active && !pad_3.active){
			ChallengeManagerScript.Instance.ChallengeSucceed();
		}
	}

	void BallDied(){
		Debug.Log ("the ball has died");
		deadBalls += 1;
		
		// Launch a replacement ball
		LaunchBall(0f,0f,0f);
	}

	public void LaunchBall(float x, float y, float z){
		GameObject ball_1 = Instantiate(ballPrefab, new Vector3(x, y, z), Quaternion.identity);
		ball_1.transform.parent = gameObject.transform.parent;
		IEnumerator coroutine_1 = ball_1.GetComponent<BallScript> ().LaunchBallWithDelay (2f, -6f, -10f);
		StartCoroutine(coroutine_1);

		//ChallengeManagerScript.Instance.ChallengeFail();
	}



	public IEnumerator LaunchBalls(float interval, int invokeCount)
	{
		for (int i = 0; i < invokeCount; i++)
		{
			LaunchBall(0f,0f,0f);

			yield return new WaitForSeconds(interval);
		}
	}
}

