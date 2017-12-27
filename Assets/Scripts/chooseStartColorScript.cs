using UnityEngine;
using System.Collections;

public class chooseStartColorScript : MonoBehaviour {

	public ParticleSystem ps;

	void Config (string hex) {
		ParticleSystem ps = GetComponent<ParticleSystem> ();
		if (ps != null) {
			ps.startColor = HexToColor (hex);
		}
	}

	Color HexToColor(string hex) {
		byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		return new Color32(r,g,b, 255);
	}
}
