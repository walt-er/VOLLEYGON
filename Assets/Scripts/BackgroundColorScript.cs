using UnityEngine;
using System.Collections;

public class BackgroundColorScript : MonoBehaviour {

	public Color lerpedColor;
	public Renderer rend;
	public Color originalColor;
	public bool matchPoint;
	public bool matchOver;
	public bool deuce;
	public Color teamOneColor;
	public Color teamTwoColor;
	public Color deuceColor;
	public int whoWon;
	public int whoIsAboutToWin;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.material.shader = Shader.Find("Unlit/Color");

		originalColor = HexToColor ("282828FF");
		teamOneColor = HexToColor ("054f88");
		teamTwoColor = HexToColor ("861b1c");
		deuceColor = HexToColor ("363682");
		//matchPoint = true;
		matchOver = false;
		deuce = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (matchPoint) {
			switch (whoIsAboutToWin) {
			case 1:
				lerpedColor = Color.Lerp (originalColor, teamOneColor, Mathf.PingPong (Time.time / 1.1f, 1));
				break;
			case 2:
				lerpedColor = Color.Lerp (originalColor, teamTwoColor, Mathf.PingPong (Time.time / 1.1f, 1));
				break;
			}
			rend.material.SetColor ("_Color", lerpedColor);
		} else if (deuce){
			lerpedColor = Color.Lerp (originalColor, deuceColor, Mathf.PingPong (Time.time / 1.1f, 1));
			rend.material.SetColor ("_Color", lerpedColor);
		} else if (!matchPoint && !matchOver && !deuce) {
			rend.material.color = Color.Lerp (rend.material.color, originalColor, 0.05f);
		}

		if (matchOver) {
			if (whoWon == 1) {
				rend.material.color = Color.Lerp (rend.material.color, teamOneColor, 0.05f);
			} else if (whoWon == 2) {
				rend.material.color = Color.Lerp (rend.material.color, teamTwoColor, 0.05f);
			}
		}
	}

	public void TurnOnMatchPoint(int whichTeam){
		whoIsAboutToWin = whichTeam;
		matchPoint = true;
	}

	public void TurnOffMatchPoint(){
		matchPoint = false;
	//	matchOver = false;

	}

	public void TurnOnDeuce(){
		deuce = true;
	}

	public void TurnOffDeuce(){
		deuce = false;
	}

	Color HexToColor(string hex)
	{
		byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		return new Color32(r,g,b, 255);
	}
}
