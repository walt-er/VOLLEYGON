using UnityEngine;
using System.Collections;

public class PlayMovieScript : MonoBehaviour {
	public MovieTexture movTexture;
	public GameObject pressStartAnimation;
	private bool fadedOut;

	void Start () {
		fadedOut = false;
	
		GetComponent<Renderer>().material.mainTexture = movTexture;
		movTexture.Play();
	}
	
	// Update is called once per frame
	void Update () {

		if (!movTexture.isPlaying && !fadedOut) {
			
			fadedOut = true;
			iTween.FadeTo (gameObject, 0f, .5f);
			Invoke ("FireAnimation", 1f);
			//gameObject.SetActive(false);
		}
			
	
	}

	void FireAnimation(){
		pressStartAnimation.GetComponent<PlayAnimationScript> ().PlayAnimation ();
	}
}
