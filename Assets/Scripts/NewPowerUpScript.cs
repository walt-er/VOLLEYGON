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
	public GameObject explosionPrefab;
	public GameObject randomPyramid; 


	// Use this for initialization


	void Start () {
		timer = 5f + (Random.value * 5f);
		isAvailable = true;
		powerupType = Random.Range (1, 4);
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
			Destroy (gameObject);
		}



		if (isDone) {
			Disappear ();
		}
	}

	public void Disappear(){
		Destroy (gameObject);
	}

	public void FadeOut(){
		if (!isFading) {
			Instantiate(explosionPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			isFading = true;
			//iTween.MoveTo(gameObject,iTween.Hash("x",3,"time",4,"delay",1,"onupdate","myUpdateFunction","looptype",iTween.LoopType.pingPong));			
			iTween.FadeTo (gameObject, iTween.Hash("alpha",0,"time",0.5, "onComplete","Disappear"));
		}
	}
}
