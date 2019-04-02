using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManagerScript : MonoBehaviour
{
    public int lives = 3;

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

  
    public void UpdateLives()
    {
        transform.GetChild(0).GetChild(lives).gameObject.SetActive(false);
       
    }

    public void OnBallDied()
    {
        Debug.Log("Ball has died according to lives manager");
        lives -= 1;

        UpdateLives();
        if (lives < 0)
        {
            // broadcast gameover to.... where? TODO: For challenges, broadcast to ICM. Otherwise, broadcast to GameManager
            GameObject.FindWithTag("GameManager").BroadcastMessage("GameOver");
        }
    }
}
