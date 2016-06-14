using UnityEngine;
using System.Collections;

public class SpeedPowerUpScript : MonoBehaviour {

	public int powerupType;
	public float timer; 

	// Use this for initialization


	void Start () {
		powerupType = 1;
		timer = 5f + (Random.value * 5f);
	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		if (timer <= 0) {
			Destroy (gameObject);
		}
	}
}
