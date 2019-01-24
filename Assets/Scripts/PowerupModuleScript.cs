using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupModuleScript : MonoBehaviour
{
    public bool activated = true;
    private float timeSinceLastPowerup;
    public float powerupAppearTime = 10f;
    public GameObject powerupPrefab;

    private void Awake()
    {
        timeSinceLastPowerup = 0f;

    }
    void Start()
    {

    }

    void Update()
    { 
        timeSinceLastPowerup += Time.deltaTime;

        if (activated)
        {
            ConsiderAPowerup();
        }
    }

    public void Activate()
    {
        activated = true;
    }

    public void Dectivate()
    {
        activated = false;
    }

    void ConsiderAPowerup()
    {
        if (timeSinceLastPowerup >= powerupAppearTime)
        { 
            // spawn a powerup
            float xVal = Random.Range(4f, 15.5f);
            float inverseXVal = -1 * xVal;
            float yVal = Random.Range(-5f, 5f);
            int whichType = Random.Range(1, 5);
            float powerupDuration = 5f + (Random.value * 5f);
            GameObject firstPowerup = (GameObject)Instantiate(powerupPrefab, new Vector3(xVal, yVal, 0), Quaternion.identity);
            firstPowerup.SendMessage("Config", whichType);
            firstPowerup.SendMessage("ResetTime", powerupDuration);
            GameObject secondPowerup = (GameObject)Instantiate(powerupPrefab, new Vector3(inverseXVal, yVal, 0), Quaternion.identity);
            secondPowerup.SendMessage("Config", whichType);
            secondPowerup.SendMessage("ResetTime", powerupDuration);
            timeSinceLastPowerup = 0f;
            powerupAppearTime = 20f + Random.value * 20f;
        }
    }
}
