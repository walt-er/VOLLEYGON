using UnityEngine;
using System.Collections;

public class ColorCycleScript : MonoBehaviour {

	public Color lerpedColor;
	public Renderer rend;
	public Color originalColor;
	public bool matchPoint;
	public bool matchOver;
	public Color teamOneColor;
	public Color teamTwoColor;
	public int whoWon;
	public int whoIsAboutToWin;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.material.shader = Shader.Find("Unlit/Color");

		originalColor = HexToColor ("282828FF");
		teamOneColor = HexToColor ("054f88");
		teamTwoColor = HexToColor ("861b1c");

	}

	// Update is called once per frame
	void Update () {

		lerpedColor = Color.Lerp (teamTwoColor, teamOneColor, Mathf.PingPong (Time.time / 2f, 1));
				
		rend.material.SetColor ("_Color", lerpedColor);

	}


	Color HexToColor(string hex)
	{
		byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		return new Color32(r,g,b, 255);
	}
}