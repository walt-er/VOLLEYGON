﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SoloModeManager : MonoBehaviour {

    private GameObject ballPrefab;
    private int deadBalls;
    private int returnedBalls;
    public Text returnCountText;
    public int goalScore = 10;
    private bool challengeOver = false;
    public String challengeTitle;

    private bool challengeStarted = false;

    void Awake(){
        
    }
        
    void Start () {
        deadBalls = 0;
        // TODO: Once we're done modularizing, we won't need a unique ball prefab
        ballPrefab = ChallengeManagerScript.Instance.GetComponent<ChallengeManagerScript>().ballPrefab;
        ChallengeManagerScript.Instance.UpdateChallengeText(challengeTitle);
    }
    
    // Update is called once per frame
    void Update () {
        
        if (!challengeStarted){
            // check for challenge start
            if (ChallengeManagerScript.Instance.challengeRunning){
                challengeStarted = true;
                LaunchBall(0f,0f,0f);
            }
        }

        if (challengeStarted){

            if (deadBalls >= 3 && !challengeOver)
            {
                ChallengeManagerScript.Instance.ChallengeFail();
            }

            if (returnedBalls == goalScore && !challengeOver)
            {
                ChallengeManagerScript.Instance.ChallengeSucceed();
                challengeOver = true;
            }
        }
    }

    public void OnBallReturned()
    {
        Debug.Log("Ball returned");
        returnedBalls += 1;
        // Update UI here.
        returnCountText.text = returnedBalls.ToString();
    }

    void BallDied(int whichSide){
        Debug.Log ("the ball has died");
        deadBalls += 1;
        returnedBalls = 0;
        returnCountText.text = returnedBalls.ToString();

        // Launch a replacement ball
        if (ChallengeManagerScript.Instance.challengeRunning)
        {
            LaunchBall(0f, 0f, 0f);
        }
    }

    public void LaunchBall(float x, float y, float z){
        GameObject ball_1 = Instantiate(ballPrefab, new Vector3(x, y, z), Quaternion.identity);
        ball_1.transform.parent = gameObject.transform.parent;
        IEnumerator coroutine_1 = ball_1.GetComponent<BallScript> ().CustomLaunchBallWithDelay (2f, -6f, 10f);
        StartCoroutine(coroutine_1);
        // set ball's gravChangeMode to true;
        Debug.Log("setting gravchange mode to true");
        ball_1.GetComponent<BallScript>().gravChangeMode = true;
        ball_1.GetComponent<BallScript>().baseTimeBetweenGravChanges = 5f;
        ball_1.GetComponent<BallScript>().gravTimeRange = 4f;
        ball_1.GetComponent<BallScript>().startWithRandomGrav = true;
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

