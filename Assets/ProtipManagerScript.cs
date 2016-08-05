using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ProtipManagerScript : MonoBehaviour {

	public GameObject protipContainer;
	private int whichProtip;
	public float proTipTime;
	public Text numberText;

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
		int textNumber = whichProtip + 1;
		numberText.text = textNumber.ToString () + "/" + protipContainer.transform.childCount.ToString ();
		protip.gameObject.SetActive (true);
	}
}
