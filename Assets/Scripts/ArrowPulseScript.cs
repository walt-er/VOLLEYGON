using UnityEngine;
using System.Collections;

public class ArrowPulseScript : MonoBehaviour {
	public Vector3 targetScale;
	public Vector3 originalScale;
	// Use this for initialization
	void Start () {
//		originalScale = new Vector3 (3f, 3f, 1f);
//		targetScale = new Vector3(3.2f,3.2f,1f);
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.localScale = Vector3.Lerp (originalScale, targetScale, Mathf.PingPong(Time.time*2f, 1));
	}
}
