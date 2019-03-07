using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveChallengeTimeScript : MonoBehaviour
{
    public string saveKey;
    public float challengeTime;

    // Start is called before the first frame update
    void Start()
    {
        LoadTime();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CompareTimes(float newTime)
    {
        if (newTime < challengeTime)
        {
            // New best time, do something here
            SaveTime(newTime);
        }
    }

    void SaveTime(float newTime)
    {
        PlayerPrefs.SetFloat(saveKey, newTime);
    }

    void LoadTime()
    {
        // make the default time really really high. I would prefer null but not sure how to do that right now.
        challengeTime = PlayerPrefs.GetFloat(saveKey, 999999999f);
    }
}
