using UnityEngine;
using System.Collections;

public class ProtipManagerScript : MonoBehaviour {

	public GameObject protipContainer;
	private int whichProtip;
	public float proTipTime;
	// Use this for initialization
	void Start () {
		Invoke ("StartGame", proTipTime);
		whichProtip = Random.Range (0, protipContainer.transform.childCount);
		ChooseRandomProtip ();
	}

	void StartGame(){
		Application.LoadLevel ("GameScene");
	}
	// Update is called once per frame
	void Update () {
	
	}

	void ChooseRandomProtip(){
		
		Transform protip = protipContainer.transform.GetChild (whichProtip);
		protip.gameObject.SetActive (true);
	}
}
