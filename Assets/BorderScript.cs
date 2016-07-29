using UnityEngine;
using System.Collections;

public class BorderScript : MonoBehaviour {

	private Color originalColor;
	private Color teamOneColor;
	private Color teamTwoColor;
	private Color thisColor;
	public GameObject graphic;
	private bool isChangingToColor;
	private bool isReturningToWhite;
	public Renderer rend;
	public int side;
	// Use this for initialization
	void Start () {
		teamOneColor = HexToColor ("8fc8f4");
		teamTwoColor = HexToColor ("ee9697");
		if (transform.position.x < 0) {
			side = 1;
			thisColor = teamTwoColor;
		} else {
			side = 2;
			thisColor = teamOneColor;
		}

		GameObject graphic = transform.Find ("Graphic").gameObject;
		rend = graphic.GetComponent<Renderer>();

		originalColor = HexToColor ("282828FF");

	}
	
	// Update is called once per frame
	void Update () {

		if (isChangingToColor) {
			rend.material.color = Color.Lerp (rend.material.color, thisColor, .15f);
		}
		if (isReturningToWhite) {
			rend.material.color = Color.Lerp (rend.material.color, Color.white, .05f);
		}
	
	}

	public void ChangeColor(){
		isChangingToColor = true;
		isReturningToWhite = false;
		//StartCoroutine ("FadeToColor");
	}

	public void ReturnColor(){
		isReturningToWhite = true;
		isChangingToColor = false;
		//StartCoroutine ("ReturnToColor");
	}

	IEnumerator FadeToColor() {
		while (rend.material.color != thisColor) {
			rend.material.color = Color.Lerp (rend.material.color, thisColor, .15f);
			Debug.Log ("color");
			yield return null;
//			if (rend.material.color != Color.black) {
//			yield return null;
//			} else {
//		
//				yield break; //Is this even needed?
//			}
		}

	}

	IEnumerator ReturnToColor() {
		while (rend.material.color != Color.white) {
			rend.material.color = Color.Lerp (rend.material.color, Color.white, .05f);
			Debug.Log ("color to white");
			yield return null;
			//			if (rend.material.color != Color.black) {
			//			yield return null;
			//			} else {
			//		
			//				yield break; //Is this even needed?
			//			}
		}
		yield return null;

	}

	Color HexToColor(string hex)
	{
		byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		return new Color32(r,g,b, 255);
	}
}
