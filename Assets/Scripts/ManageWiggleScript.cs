using UnityEngine;
using System.Collections;
using Colorful;
public class ManageWiggleScript : MonoBehaviour {

	public bool wiggleOn;
	public Wiggle theWiggle;
	// Use this for initialization
	void Start () {
		wiggleOn = false;
		theWiggle = gameObject.GetComponent<Wiggle> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (wiggleOn && theWiggle.Amplitude <= .05) {
			theWiggle.Amplitude += .0001f;
		}

		if (!wiggleOn && theWiggle.Amplitude > 0) {
			theWiggle.Amplitude -= .001f;
		}
	
	}

	public void ActivateWiggle(){
		theWiggle.enabled = true;
		int whichMode = Random.Range (0, 1);
		switch (whichMode) {
		case 1:
			theWiggle.Mode = Wiggle.Algorithm.Simple;
			break;
		case 2: 
			theWiggle.Mode = Wiggle.Algorithm.Complex;
			break;
		}
		wiggleOn = true;
		Invoke("DeactivateWiggle", 30f);
	}

	public void DeactivateWiggle(){
		
		wiggleOn = false;
		Invoke("TurnOffWiggle", 5f);
	}

	public void TurnOffWiggle(){
		theWiggle.Amplitude = 0;
		gameObject.GetComponent<Wiggle> ().enabled = false;
	}
		
}
