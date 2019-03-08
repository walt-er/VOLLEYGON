using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleSelectorScript : MonoBehaviour
{
    private GameObject moduleController;

    public bool powerupsModuleOn;
    public bool gravChangeModuleOn;
    public bool scoreboardModuleOn;
    public bool statsModuleOn;
    // More to come here...

    private void Awake()
    {
        // Find the module container
        moduleController = GameObject.FindWithTag("ModuleContainer");
    }
    void Start()
    {
        // If module controller exists, tell it to activate the corresponding module.
        if (moduleController)
        {
            // TODO: Probably a more elegant way to do this...
            if (powerupsModuleOn)
            {
                moduleController.BroadcastMessage("moduleOn", "powerups");
            }
            if (gravChangeModuleOn)
            {
                moduleController.BroadcastMessage("moduleOn", "gravChange");
            }
            if (scoreboardModuleOn)
            {
                moduleController.BroadcastMessage("moduleOn", "scoreboard");
            }
            if (statsModuleOn)
            {
                moduleController.BroadcastMessage("moduleOn", "stats");
            }
        }
    }

   
}
