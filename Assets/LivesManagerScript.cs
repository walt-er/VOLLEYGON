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

    public void onBallDied()
    {
        lives -= 1;
        if (lives < 0)
        {
            //broadcast gameover
        }
    }
}
