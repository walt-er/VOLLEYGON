using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveChallengeTimeScript : MonoBehaviour
{
    public string saveKey;
    public float challengeTime = 99999f;

    // Start is called before the first frame update
    void Awake()
    {
        LoadTime();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CompareTimes(float newTime)
    {
        if (newTime < challengeTime)
        {
            // New best time, do something here. Return a value? Broadcast something? Dunno.
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
        challengeTime = PlayerPrefs.GetFloat(saveKey, 9999f);
    }
}
