﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ProtipManagerScript : MonoBehaviour {

	public GameObject protipContainer;
	private int whichProtip;
	public float proTipTime;
	public Text numberText;
	public string startButton1 = "Start_P1";
	public string startButton2 = "Start_P2";
	public string startButton3 = "Start_P3";
	public string startButton4 = "Start_P4";

	// Use this for initialization
	void Start () {
		MusicManagerScript.Instance.StartIntro ();
		Invoke ("StartGame", proTipTime);
		whichProtip = Random.Range (0, protipContainer.transform.childCount);
		ChooseRandomProtip ();
	}

	void StartGame(){
		StartCoroutine ("NextScene");
	}
		
	void Update(){
		if (Input.GetButton (startButton1) && Input.GetButton (startButton2) && Input.GetButton (startButton3) && Input.GetButton (startButton4)) {
			Debug.Log ("Skipping protip");
			StartCoroutine ("NextScene");
		}	
	}

	IEnumerator NextScene(){
		float fadeTime = GameObject.Find ("FadeCurtain").GetComponent<FadingScript> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel ("GameScene");
	}
	void ChooseRandomProtip(){
		
		Transform protip = protipContainer.transform.GetChild (whichProtip);
		int textNumber = whichProtip + 1;
		numberText.text = textNumber.ToString () + "/" + protipContainer.transform.childCount.ToString ();
		protip.gameObject.SetActive (true);
	}
}