using UnityEngine;
using System.Collections;
using Colorful;
public class ManageWiggleScript : MonoBehaviour {

	public bool wiggleOn;
	// Use this for initialization
	void Start () {
		wiggleOn = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ActivateWiggle(){
		gameObject.GetComponent<Wiggle> ().enabled = true;
		wiggleOn = true;
		Invoke("DeactivateWiggle", 15f);
	}

	public void DeactivateWiggle(){
		gameObject.GetComponent<Wiggle> ().enabled = false;
	}
		
}
