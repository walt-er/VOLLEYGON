using UnityEngine;
using System.Collections;

public class MusicManagerScript : MonoBehaviour {

	public AudioSource introSource;
	public AudioSource rootSource;
	public AudioSource secondSource;
	public AudioSource fourthSource;
	public AudioSource fifthSource;

	public AudioSource introSourceSetOne;
	public AudioSource rootSourceSetOne;
	public AudioSource secondSourceSetOne;
	public AudioSource fourthSourceSetOne;
	public AudioSource fifthSourceSetOne;

	public AudioSource introSourceSetTwo;
	public AudioSource rootSourceSetTwo;
	public AudioSource secondSourceSetTwo;
	public AudioSource fourthSourceSetTwo;
	public AudioSource fifthSourceSetTwo;

	public int whichSource;
	public float masterVolume;

	// Static singleton property
	public static MusicManagerScript Instance { get; private set; }


	void Awake(){
		Instance = this;
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
		TurnOffEverything ();
		whichSource = 0;

		introSource = rootSourceSetTwo;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TurnOffEverything(){
		introSource.volume = 0;
		rootSource.volume = 0;
		secondSource.volume = 0;
		fourthSource.volume = 0;
		fifthSource.volume = 0;

		introSourceSetOne.volume = 0;
		rootSourceSetOne.volume = 0;
		secondSourceSetOne.volume = 0;
		fourthSourceSetOne.volume = 0;
		fifthSourceSetOne.volume = 0;

		introSourceSetTwo.volume = 0;
		rootSourceSetTwo.volume = 0;
		secondSourceSetTwo.volume = 0;
		fourthSourceSetTwo.volume = 0;
		fifthSourceSetTwo.volume = 0;
	}
	public void StartIntro(){
		TurnOffEverything ();
		introSource.volume = masterVolume;
	}

	public void StartRoot(){
		TurnOffEverything ();
		rootSource.volume = masterVolume;
	}
	public void StartMusic (){
		introSource.volume = 0;
		rootSource.volume = masterVolume;
	}

	public void StartFifth (){
		TurnOffEverything ();
		fifthSource.volume = masterVolume;
	}
	public void StartFourth (){
		TurnOffEverything ();
		fourthSource.volume = masterVolume;
	}

	public void FadeOutEverything(){
		introSource.volume -= .005f;
		rootSource.volume -= .005f;
		secondSource.volume -= .005f;
		fourthSource.volume -= .005f;
		fifthSource.volume -= .005f;
	}
	public void SwitchMusic(){
		TurnOffEverything ();
		whichSource += 1;
		whichSource = whichSource % 2;
		switch (whichSource) {
		case 0:
			rootSource.volume = masterVolume;
			secondSource.volume = 0;
			break;
		case 1:
			rootSource.volume = 0;
			secondSource.volume = masterVolume;
			break;
		}
	}
		
}
