using UnityEngine;
using System.Collections;

public class DataManagerScript : MonoBehaviour {

	public static DataManagerScript dataManager;

	public int teamOneWins;
	public int teamTwoWins;
	public static int playerOneType;
	public static int playerTwoType;
	public static int playerThreeType;
	public static int playerFourType;


	void Awake(){
		if (dataManager == null) {
			DontDestroyOnLoad (gameObject);
			dataManager = this;
		} else if (dataManager != this){
			Destroy (gameObject);
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
