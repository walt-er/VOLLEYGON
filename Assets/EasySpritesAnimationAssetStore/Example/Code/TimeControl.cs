using UnityEngine;
using System.Collections;

public class TimeControl : MonoBehaviour {

	public void TimeChanged(float v)
	{
		Time.timeScale = v;
	}
}
