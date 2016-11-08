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
		MusicManagerScript.Instance.StartIntro ();
		Invoke ("StartGame", proTipTime);
		whichProtip = Random.Range (0, protipContainer.transform.childCount);
		ChooseRandomProtip ();
	}

	void StartGame(){
		StartCoroutine ("NextScene");
	}


	// Update is called once per frame

	IEnumerator NextScene(){
		float fadeTime = GameObject.Find ("FadeCurtain").GetComponent<FadingScript> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel ("GameScene");
	}
	void ChooseRandomProtip(){
		
		Transform protip = protipContainer.transform.GetChild (whichProtip);
		int textNumber = whichProtip + 1;
		numberText.text = textNumber.ToString () + "/" + protipContainer.transform.childCount.ToString ();
		protip.gameObject.SetActive (true);
	}
}
