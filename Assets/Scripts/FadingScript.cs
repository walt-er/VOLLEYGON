using UnityEngine;
using System.Collections;

public class FadingScript : MonoBehaviour {

	public Texture2D FadeOutTexture;
	public float fadeSpeed = 0.8f;

	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDir = -1;

	void OnGUI(){
		//fade out and in the alpha value using a direction, a speed, and a time.deltatime
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		// clamp alpha
		alpha = Mathf.Clamp01(alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), FadeOutTexture);
	}

	public float BeginFade (int direction){
		fadeDir = direction;
		return (1/fadeSpeed);
	}


	void OnLevelWasLoaded(){
		alpha = 1;
		BeginFade (-1);
	}

}
