using UnityEngine;
using System.Collections;
using Colorful;

public class CRTModeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (DataManagerScript.CRTMode) {
			
			gameObject.GetComponent<AnalogTV> ().enabled = true;
		} else {
			gameObject.GetComponent<AnalogTV> ().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
