using UnityEngine;
using System.Collections;

public class DieScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("Remove", 10f);
	}

	void Remove(){
		Destroy (gameObject);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
