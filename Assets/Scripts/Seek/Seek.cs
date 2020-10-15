using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 6.0f;
    private float minDistance = 0.2f;

    // Update is called once per frame
    void Update()
    {
    	// calls SeekTarget() once per frame
	    SeekTarget();
    }

    void SeekTarget()
    {
	// Will give desired direction
	Vector3 dir = target.position - transform.position;

	// Determine whether to continue seeking target.
	if(dir.magnitude > minDistance)
	{
		Vector3 moveVector = dir.normalized*moveSpeed*Time.deltaTime;

		// if condition is met, continue to move to target
		transform.position += moveVector;
	}
    }
}
