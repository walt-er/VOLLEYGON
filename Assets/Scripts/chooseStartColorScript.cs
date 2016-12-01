using UnityEngine;
using System.Collections;

public class chooseStartColorScript : MonoBehaviour {

	public ParticleSystem ps;
	// Use this for initialization
	void Start () {
		//ps = GetComponent<ParticleSystem> ();


	}

	void Config (string hex){
		Debug.Log ("CONFIG EXPLOSION!");
		ParticleSystem ps = GetComponent<ParticleSystem> ();
		ps.startColor = HexToColor (hex);
	}
	// Update is called once per frame
	void Update () {
	
	}


	Color HexToColor(string hex)
	{
		byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		return new Color32(r,g,b, 255);
	}

}
