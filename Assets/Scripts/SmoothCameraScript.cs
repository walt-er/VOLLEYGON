using UnityEngine;
using System.Collections;

public class SmoothCameraScript : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
    private GameObject emptyGO;

    private void Start()
    {
        emptyGO = new GameObject();
        Transform newTransform = emptyGO.transform;
        emptyGO.transform.position = new Vector3(0f, 0f, 0f);
    }
    // Update is called once per frame
    void Update () 
	{
		if (target)
		{
            //Debug.Log("Following target");
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
			//Vector3 delta = target.position.normalized * 1.3f - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 reducedPosition = new Vector3(target.position.x/10f, target.position.y/10f, target.position.z); 
			Vector3 delta = reducedPosition - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
        if (!target || target == emptyGO.transform)
        {
            //Find a new target!
            GameObject newTarget = GameObject.FindWithTag("Ball");
            if (newTarget)
            {
                //Debug.Log("found a target");
                target = newTarget.transform;
            }
            else
            {
                //Debug.Log("no target");
                target = emptyGO.transform;
            }
        }

    }
}