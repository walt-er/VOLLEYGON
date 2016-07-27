using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LoadingTextScript : MonoBehaviour {

	public Text loadingText;
	public int counter;
	// Use this for initialization
	void Start () {
		UpdateText ();
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void UpdateText(){
		counter++;
		if (counter % 4 == 0) {
			loadingText.text = "LOADING";
		}
		if (counter % 4 == 1) {
			loadingText.text = "LOADING.";
		}
		if (counter % 4 == 2) {
			loadingText.text = "LOADING..";
		}
		if (counter % 4 == 3) {
			loadingText.text = "LOADING...";
		}
		Invoke ("UpdateText", 0.7f);

	}
}
