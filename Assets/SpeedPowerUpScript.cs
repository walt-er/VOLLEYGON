using UnityEngine;
using System.Collections;

public class SpeedPowerUpScript : MonoBehaviour {

	public int powerupType;
	public float timer; 
	public bool isAvailable;
	public int fadeSpeed = 3;
	private bool isDone = false;
	public bool isFading = false;
	private Color matCol;
	private Color newColor;
	private float alfa = 0;
	public GameObject pyramid;

	// Use this for initialization


	void Start () {
		powerupType = 1;
		timer = 5f + (Random.value * 5f);
		isAvailable = true;

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
			isFading = true;
			//iTween.MoveTo(gameObject,iTween.Hash("x",3,"time",4,"delay",1,"onupdate","myUpdateFunction","looptype",iTween.LoopType.pingPong));			
			iTween.FadeTo (gameObject, iTween.Hash("alpha",0,"time",2, "onComplete","Disappear"));
		}
	}
}
