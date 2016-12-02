using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	GUIText stat1;
	float timeLastFrame;
	GameObject circ;

	// Use this for initialization
	void Start () {
		stat1 = GetComponent<GUIText> ();
		timeLastFrame = Time.realtimeSinceStartup;
		circ = GameObject.Find ("Circle");
	}
	

	void Update()
	{
		circ.GetComponent<CircleEfficient>().Rebuild ();

		float realDeltaTime = Time.realtimeSinceStartup - timeLastFrame;
		timeLastFrame = Time.realtimeSinceStartup;
		
		stat1.text = "miliseconds: " + realDeltaTime*1000; 
	}
}
