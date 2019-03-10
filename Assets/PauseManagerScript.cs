using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PauseManagerScript : MonoBehaviour
{
    public bool paused = false;
    public bool recentlyPaused = false;
    public GameObject pausePanel;
    public EventSystem es;

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void Pause(JoystickButtons buttons)
    {
        if (!paused)
        {
            // Show pause
            pausePanel.SetActive(true);

            // Assign butons
            es.GetComponent<StandaloneInputModule>().horizontalAxis = buttons.horizontal;
            es.GetComponent<StandaloneInputModule>().verticalAxis = buttons.vertical;
            es.GetComponent<StandaloneInputModule>().submitButton = buttons.jump;
            es.GetComponent<StandaloneInputModule>().cancelButton = buttons.grav;

            // Reset menu
            es.SetSelectedGameObject(null);
            es.SetSelectedGameObject(es.firstSelectedGameObject);
            MusicManagerScript.Instance.TurnOffEverything();
            SoundManagerScript.instance.muteSFX();
            //TODO: Move the ball's SFX to sound manager script. Also, will this work with multiple balls? Maybe broadcast pause to everything?
            GameObject.FindWithTag("Ball").GetComponent<BallScript>().Pause();
            Time.timeScale = 0;
            paused = true;
        }
    }
    public void Unpause()
    {
        if (paused)
        {
            Time.timeScale = 1;
            paused = false;
            pausePanel.SetActive(false);
            recentlyPaused = true;
            MusicManagerScript.Instance.RestoreFromPause();
            //TODO: Move the ball's SFX to sound manager script
            SoundManagerScript.instance.unMuteSFX();
            GameObject.FindWithTag("Ball").GetComponent<BallScript>().UnPause();
            Invoke("CancelRecentlyPaused", 0.1f);
        }
    }

    public void CancelRecentlyPaused()
    {
        recentlyPaused = false;
    }
}
