using UnityEngine;
using System.Collections;

public class TrailScript : MonoBehaviour {


	void Start () {
		gameObject.GetComponent<TrailRenderer>().sortingLayerName = "Background";
		gameObject.GetComponent<TrailRenderer>().sortingOrder = 2;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
