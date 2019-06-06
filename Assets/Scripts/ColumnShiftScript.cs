using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnShiftScript : MonoBehaviour
{

    public GameObject precedingColumn;
    public bool shiftingColumn = true;
    private float startingX;
    public float columnDist;
    public int columnPosition;
    private float moveDuration = 1f;

    private IEnumerator shiftingEnumerator;


    void Start()
    {
        startingX = transform.position.x;
    }

    void Update()
    {
        if (ChildCountActive(transform) <= 0)
        {
            gameObject.transform.parent.BroadcastMessage("OnColumnClear", columnPosition);
            gameObject.SetActive(false);
        }
    }

    //TODO: Need to find a way to get the columns to shift into a 'slot'
    void OnColumnClear(int clearedPosition)
    {
        if (clearedPosition < columnPosition && shiftingColumn)
        {
            StartCoroutine("Shift", transform.position.x - columnDist);
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

    IEnumerator Shift(float newX)
    {
        float t = 0.0f;
        Vector3 start = transform.position;
     

        while (t < moveDuration)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(start, new Vector3(newX,0f,0f), t / moveDuration);
            yield return null;
        }
    }
}
