using UnityEngine;
using System.Collections;

public class powerupScript : MonoBehaviour {

	public int powerupType;
	public float timer; 
	// Use this for initialization
	void Start () {
		timer = 5f + (Random.value * 15f);
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		if (timer <= 0) {
			Destroy (gameObject);
		}
	}
}
