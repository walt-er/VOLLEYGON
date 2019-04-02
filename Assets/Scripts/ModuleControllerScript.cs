using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleControllerScript : MonoBehaviour
{
    public GameObject powerupsModule;
    public GameObject gravChangeModule;
    public GameObject statsModule;
    public GameObject scoreboardModule;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void moduleOn(string whichModule)
    {
        Debug.Log("Attempting to activate module " + whichModule);
        switch (whichModule){
            case "powerups":
                if (powerupsModule)
                {
                    powerupsModule.SetActive(true);
                }
                break;
            case "gravChange":
                if (gravChangeModule)
                {
                    gravChangeModule.SetActive(true);
                }
                break;
            case "scoreboard":
                if (scoreboardModule)
                {
                    scoreboardModule.SetActive(true);
                }
                break;
            case "stats":
                if (statsModule)
                {
                    statsModule.SetActive(true);
                }
                break;
        }
    }
}
