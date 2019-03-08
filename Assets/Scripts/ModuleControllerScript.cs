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
                powerupsModule.SetActive(true);
                break;
            case "gravChange":
                gravChangeModule.SetActive(true);
                break;
            case "scoreboard":
                scoreboardModule.SetActive(true);
                break;
            case "stats":
                statsModule.SetActive(true);
                break;
        }
    }
}
