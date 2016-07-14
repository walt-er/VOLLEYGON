using UnityEngine;
using System.Collections;

public class AssignLayerScript : MonoBehaviour {

	// Use this for initialization
	public int whichLayer;
	void Start () {
		gameObject.layer = whichLayer;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
