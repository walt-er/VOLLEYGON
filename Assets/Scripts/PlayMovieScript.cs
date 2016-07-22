using UnityEngine;
using System.Collections;

public class PlayMovieScript : MonoBehaviour {
	public MovieTexture movTexture;
	private bool fadedOut;
	// Use this for initialization
	void Start () {
		fadedOut = false;
		// this line of code will make the Movie Texture begin playing
		//((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
		GetComponent<Renderer>().material.mainTexture = movTexture;
		movTexture.Play();
	}
	
	// Update is called once per frame
	void Update () {

		if (!movTexture.isPlaying && !fadedOut) {
			
			fadedOut = true;
			iTween.FadeTo (gameObject, 0f, .5f);
		}
			
	
	}
}
