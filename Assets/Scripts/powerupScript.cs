using UnityEngine;
using System.Collections;

public class powerupScript : MonoBehaviour {

	public int powerupType;
	public float timer; 
	public Sprite sizeUpSprite;
	public Sprite speedUpSprite;
	public Sprite pandemoniumSprite;
	// Use this for initialization


	void Start () {
		powerupType = (int)Mathf.Floor (Random.value * 3) + 1;
		timer = 5f + (Random.value * 5f);

		switch (powerupType) {

		case 1:
			GetComponent<SpriteRenderer>().sprite = speedUpSprite;
			break;
		case 2:
			GetComponent<SpriteRenderer>().sprite = sizeUpSprite;
			break;
		case 3:
			GetComponent<SpriteRenderer> ().sprite = pandemoniumSprite;
			break;
		default:
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		if (timer <= 0) {
			Destroy (gameObject);
		}
	}
}
