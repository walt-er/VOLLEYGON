using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Protip5ManagerScript : MonoBehaviour {

	public Text warningText;
	public GameObject redBg;
	// Use this for initialization
	void Start () {
		Invoke ("Activate", 5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Activate(){
		warningText.gameObject.SetActive (true);
		redBg.SetActive (true);
	}
}
