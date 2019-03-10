using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Challenge_Script_AIs : MonoBehaviour
{

    private GameObject ballPrefab;
    private int deadBalls;
    public GameObject scoreboard;

    public String challengeTitle;

    private bool challengeStarted = false;

    void Awake()
    {

    }

    void Start()
    {
        // find and activate the scoreboard module. Is there a better way to do this? Right now we just have a reference assigned
        scoreboard.SetActive(true);

        deadBalls = 0;
        // TODO: Once we're done modularizing, we won't need a unique ball prefab
        ballPrefab = ChallengeManagerScript.Instance.GetComponent<ChallengeManagerScript>().ballPrefab;
        ChallengeManagerScript.Instance.UpdateChallengeText(challengeTitle);
    }

    // Update is called once per frame
    void Update()
    {

        if (!challengeStarted)
        {
            // check for challenge start
            if (ChallengeManagerScript.Instance.challengeRunning)
            {
                challengeStarted = true;
                LaunchBall(0f, 0f, 0f);
            }
        }

        if (challengeStarted)
        {
            //Check for victory
            // In this challenge, scoreboard will broadcast directly to the challenge manager
        }


    }

    void BallDied(int whichSide)
    {
        Debug.Log("challengemanager running? ");
        Debug.Log(ChallengeManagerScript.Instance.challengeRunning);
        if (ChallengeManagerScript.Instance.challengeRunning)
        {
            // Launch a replacement ball
            LaunchBall(0f, 0f, 0f);
        }
     
    }

    public void LaunchBall(float x, float y, float z)
    {
        GameObject ball_1 = Instantiate(ballPrefab, new Vector3(x, y, z), Quaternion.identity);
        ball_1.transform.parent = gameObject.transform.parent;
        IEnumerator coroutine_1 = ball_1.GetComponent<BallScript>().LaunchBallWithDelay(2f);
        StartCoroutine(coroutine_1);
        // set ball's gravChangeMode to true;
        ball_1.GetComponent<BallScript>().gravChangeMode = true;
        //TODO: Make these a public property
        ball_1.GetComponent<BallScript>().baseTimeBetweenGravChanges = 5f;
        ball_1.GetComponent<BallScript>().gravTimeRange = 4f;
        ball_1.GetComponent<BallScript>().startWithRandomGrav = true;
    }



    public IEnumerator LaunchBalls(float interval, int invokeCount)
    {
        for (int i = 0; i < invokeCount; i++)
        {
            LaunchBall(0f, 0f, 0f);

            yield return new WaitForSeconds(interval);
        }
    }
}

