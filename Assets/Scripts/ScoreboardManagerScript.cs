using UnityEngine;
using System.Collections;

public class ScoreboardManagerScript : MonoBehaviour {

	public GameObject Team1Scores;
	public GameObject Team2Scores;
	public GameObject Team1Wins;
	public GameObject Team2Wins;
    public GameObject background;
    private bool isGameOver = false;
	public GameObject deuce;
	public GameObject dash;
	public bool scoreBoardShowing;

    public int scorePlayedTo = 11;
    public int team1Score = 0;
    public int team2Score = 0;
	// Use this for initialization
	void Start () {

        background = GameObject.FindWithTag("Background");

		scoreBoardShowing = false;
		for (int i = 0; i < Team1Scores.transform.childCount; i++) {
			Transform child = Team1Scores.transform.GetChild (i);
			//child.gameObject.SetActive (false);
			iTween.FadeTo (child.gameObject, 0f, .1f);
		}

		for (int j = 0; j < Team2Scores.transform.childCount; j++) {
			//	Debug.Log ("trying to hide");
			Transform childTwo = Team2Scores.transform.GetChild (j);

			iTween.FadeTo (childTwo.gameObject, 0f, .1f);

		}
		Invoke ("moveIntoPlace", 1f);
		Invoke ("cleanUp", 1f);
		//cleanUp ();
	}

	// Update is called once per frame
	void Update () {
        // Team wins. //TODO: COuld this be moved to be checked just on score?
        if (team1Score >= scorePlayedTo && team1Score > team2Score + 1 && !isGameOver)
        {
            teamWins(1);
        }
        else if (team2Score >= scorePlayedTo && team2Score > team1Score + 1 && !isGameOver)
        {
            teamWins(2);
        }
    }

	public void moveIntoPlace(){
		gameObject.transform.position = new Vector3 (0f, 0f, 0f);
	}

	public void TeamOneWin(){
		Team1Wins.gameObject.SetActive (true);
		MusicManagerScript.Instance.StartRoot ();
		scoreBoardShowing = true;
        Debug.Log("team 1 wins!");

        // If there's a challenge manager, broadcast to that. If not, broadcast to gamemanager. We may end up removing gamemanager from this equation.
        GameObject cm = GameObject.FindWithTag("ChallengeManager");
        if (cm)
        {
            cm.BroadcastMessage("ChallengeSucceed");
        }
      
    }

	public void TeamTwoWin(){
		Team2Wins.gameObject.SetActive (true);
		MusicManagerScript.Instance.StartRoot ();
		scoreBoardShowing = true;
        Debug.Log("team 2 wins!");
        // If there's a challenge manager, broadcast to that. If not, broadcast to gamemanager. We may end up removing gamemanager from this equation.
        GameObject cm = GameObject.FindWithTag("ChallengeManager");
        if (cm)
        {
            cm.BroadcastMessage("ChallengeFail");
        }
    }

    public void ManageScore(int whichSide)
    {

        if (whichSide == 1)
        {
            team2Score += 1;
        }
        else
        {
            team1Score += 1;
        }

        //CurrentArena.BroadcastMessage("ReturnColor");

        if (team2Score < scorePlayedTo && team2Score < scorePlayedTo)
        {
            if (team2Score == scorePlayedTo - 1 && team1Score == scorePlayedTo - 1)
            {
                enableNumbers(team1Score, team2Score, true);
                background.GetComponent<BackgroundColorScript>().TurnOnDeuce();
            }
            else
            {
                enableNumbers(team1Score, team2Score, false);
            }

            CheckForMatchPoint();
        }
        else if (Mathf.Abs(team1Score - team2Score) < 2)
        {
            if (team2Score >= scorePlayedTo || team1Score >= scorePlayedTo)
            {
                //winByTwoText.CrossFadeAlpha (0.6f, .25f, false);
                MusicManagerScript.Instance.StartFifth();
                CheckForMatchPoint();
                enableNumbers(team1Score, team2Score, true);
            }
          
           

        }
        else
        {
            // GAME IS OVER
            //Debug.Log("What is this victory condition?");
            //// If there's a challenge manager, broadcast to that. If not, broadcast to gamemanager. We may end up removing gamemanager from this equation.
            //GameObject cm = GameObject.FindWithTag("ChallengeManager");
            //if (cm)
            //{
            //    cm.BroadcastMessage("ChallengeSucceed");   

            //}
            //else
            //{
            //    // tell gamemanager game is over
            //}
            transform.position = new Vector3(0f, 0f, 0f);
           
        }
    }

    // End game for team maches
    void teamWins(int whichTeam)
    {
        isGameOver = true;
        switch (whichTeam)
        {
            case 1:
                TeamOneWin();
                background.GetComponent<BackgroundColorScript>().whoWon = 1;
                background.GetComponent<BackgroundColorScript>().matchOver = true;
                background.GetComponent<BackgroundColorScript>().TurnOffMatchPoint();

                break;
            case 2:
                TeamTwoWin();
                background.GetComponent<BackgroundColorScript>().whoWon = 2;
                background.GetComponent<BackgroundColorScript>().matchOver = true;
                break;
        }

        if (GameObject.FindWithTag("GameManager"))
        {
            GameObject.FindWithTag("GameManager").BroadcastMessage("GameOver");
        }
    }
        void CheckForMatchPoint()
    {
        // check for match point
        if (team2Score == team1Score)
        {
            background.GetComponent<BackgroundColorScript>().TurnOffMatchPoint();
          
        }
        else if (team1Score == scorePlayedTo - 1 && team2Score < scorePlayedTo)
        {
            background.GetComponent<BackgroundColorScript>().TurnOnMatchPoint(1);
            background.GetComponent<BackgroundColorScript>().TurnOffDeuce();
            MusicManagerScript.Instance.StartFifth();
        }
        else if (team2Score == scorePlayedTo - 1 && team1Score < scorePlayedTo)
        {
            background.GetComponent<BackgroundColorScript>().TurnOnMatchPoint(2);
            background.GetComponent<BackgroundColorScript>().TurnOffDeuce();
            MusicManagerScript.Instance.StartFifth();
        }
    }

    public void OnBallDied(int whichSide)
    { 
        ManageScore(whichSide);
    }

    public void enableNumbers (int team1Score, int team2Score, bool overtime){
        Debug.Log("Scoreboard showing score");
		if (!overtime) {
			Transform theNumOne = Team1Scores.transform.Find (team1Score.ToString ());
			theNumOne.gameObject.SetActive (true);
			iTween.FadeTo (theNumOne.gameObject, 0.8f, .25f);

			Transform theNumTwo = Team2Scores.transform.Find (team2Score.ToString ());
			theNumTwo.gameObject.SetActive (true);
			iTween.FadeTo (theNumTwo.gameObject, 0.8f, .25f);
			enableDash ();
		} else {
			if (team1Score > team2Score) {
				Transform theNumOne = Team1Scores.transform.Find ("A");
				theNumOne.gameObject.SetActive (true);
				iTween.FadeTo (theNumOne.gameObject, 0.8f, .25f);

				Transform theNumTwo = Team2Scores.transform.Find ("D");
				theNumTwo.gameObject.SetActive (true);
				iTween.FadeTo (theNumTwo.gameObject, 0.8f, .25f);
			} else if (team1Score < team2Score) {
				Transform theNumOne = Team1Scores.transform.Find ("D");
				theNumOne.gameObject.SetActive (true);
				iTween.FadeTo (theNumOne.gameObject, 0.8f, .25f);

				Transform theNumTwo = Team2Scores.transform.Find ("A");
				theNumTwo.gameObject.SetActive (true);
				iTween.FadeTo (theNumTwo.gameObject, 0.8f, .25f);
			} else if (team1Score == team2Score) {

				deuce.SetActive (true);
				iTween.FadeTo (deuce, 0.8f, .25f);
				MusicManagerScript.Instance.StartFourth ();
			}
		}


		scoreBoardShowing = true;


		Invoke ("FadeOutScore", 2f);
	}

	public void FadeOutScore(){
		//for now just turn everything off
		disableEverything ();
	}
	public void enableDash(){
		dash.SetActive (true);
		iTween.FadeTo (dash, .8f, .25f);
	}


	public void cleanUp(){
		for (int i = 0; i < Team1Scores.transform.childCount; i++) {
			Transform child = Team1Scores.transform.GetChild (i);
			child.gameObject.SetActive (false);
		//	iTween.FadeTo (child.gameObject, 0f, .1f);
		}

		for (int j = 0; j < Team2Scores.transform.childCount; j++) {
		//	Debug.Log ("trying to hide");
			Transform childTwo = Team2Scores.transform.GetChild (j);
			childTwo.gameObject.SetActive (false);
		//	iTween.FadeTo (childTwo.gameObject, 0f, .1f);
		}
		dash.SetActive (false);
	}
	public void disableEverything(){
		iTween.FadeTo (dash, 0f, .25f);
		iTween.FadeTo (deuce, 0f, .25f);
		for (int i = 0; i < Team1Scores.transform.childCount; i++) {
			Transform child = Team1Scores.transform.GetChild (i);
			//if (child.gameObject.activeSelf) {
				iTween.FadeTo (child.gameObject, 0f, .25f);
			//}
			//child.gameObject.SetActive (false);
		}
		for (int j = 0; j < Team2Scores.transform.childCount; j++) {
		//	Debug.Log ("trying to hide");
			Transform childTwo = Team2Scores.transform.GetChild (j);

				iTween.FadeTo (childTwo.gameObject, 0f, .25f);

			//childTwo.gameObject.SetActive (false);
		}
		Invoke ("cleanUp", .5f);

		scoreBoardShowing = false;
	}

}
