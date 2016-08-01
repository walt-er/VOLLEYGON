using UnityEngine;
using System.Collections;

public class NewPowerUpScript : MonoBehaviour {

	public int powerupType;
	public float timer; 
	public bool isAvailable;
	private bool isDone = false;
	public bool isFading = false;
	public GameObject speedPyramid;
	public GameObject sizePyramid;
	public GameObject pandemoniumPyramid;
	public GameObject randomPyramid;
	public GameObject explosionPrefab;
	public int randomSubType;


	// Use this for initialization


	void Start () {
		timer = 5f + (Random.value * 5f);
		isAvailable = true;

		//powerupType = Random.Range (1, 5);
		switch (powerupType){
		case 1:
			speedPyramid.SetActive (true);
			break;
		case 2:
			sizePyramid.SetActive (true);
			break;
		case 3:
			pandemoniumPyramid.SetActive (true);
			break;
		case 4:
			randomPyramid.SetActive (true);
			break;
		}

	}

	void Config(int whichType){
		powerupType = whichType;
		switch (powerupType){
		case 1:
			speedPyramid.SetActive (true);
			break;
		case 2:
			sizePyramid.SetActive (true);
			break;
		case 3:
			pandemoniumPyramid.SetActive (true);
			break;
		case 4:
			randomPyramid.SetActive (true);
			break;
		}
	}
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		if (timer <= 0) {
			//Destroy (gameObject);
			FadeOut(false);
		}



		if (isDone) {
			Disappear ();
		}
	}

	public void Disappear(){
		Destroy (gameObject);
	}

	public void FadeOut(bool includeExplosion = true){
		isAvailable = false;
		if (!isFading) {

			if (includeExplosion) {

				GameObject explosion = (GameObject)Instantiate (explosionPrefab, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			
				switch (powerupType) {
				case 1:
					explosion.SendMessage ("Config", "FDC54D");
					break;
				case 2:
					explosion.SendMessage ("Config", "1069A8");
					break;
				case 3:
					explosion.SendMessage ("Config", "363682");
					break;
				case 4:
					explosion.SendMessage ("Config", "01884D");
					break;
				}
			}


			isFading = true;
			//iTween.MoveTo(gameObject,iTween.Hash("x",3,"time",4,"delay",1,"onupdate","myUpdateFunction","looptype",iTween.LoopType.pingPong));			
			iTween.FadeTo (gameObject, iTween.Hash("alpha",0,"time",0.5, "onComplete","Disappear"));
		}
	}
}
