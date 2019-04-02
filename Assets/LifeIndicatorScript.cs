using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeIndicatorScript : MonoBehaviour
{

    public GameObject targetPlayer;
    public int playerType = -1; 

    void Start()
    {
        // Identify target player by tag.
        Debug.Log("Life indicator looking for player");
        targetPlayer = GameObject.FindWithTag("Player");
        if (targetPlayer != null)
        {
            Debug.Log("Target player found");
            Debug.Log(targetPlayer);
            playerType = targetPlayer.GetComponent<PlayerController>().playerType;
            Debug.Log("player type is " + playerType);
        }
        else
        {
            Debug.Log("Player not found");
        }

        if (playerType != -1)
        {
            Debug.Log("Setting child to active");
            Debug.Log(transform.GetChild(playerType).gameObject);
            transform.GetChild(playerType).gameObject.SetActive(true);
            transform.GetChild(playerType).gameObject.active = true;
        }
    }


    void Update()
    {
        // Update the rotation to match the player's rotation
    }
}
