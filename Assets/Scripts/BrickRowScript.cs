using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickRowScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(ChildCountActive(transform));
    }

    // Update is called once per frame
    void Update()
    {
        if (ChildCountActive(transform) <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public int ChildCountActive(Transform t)
    {
        int k = 0;
        foreach (Transform c in t)
        {
            if (c.gameObject.activeSelf)
                k++;
        }
        return k;
    }
}
