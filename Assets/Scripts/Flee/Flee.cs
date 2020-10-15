using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{

    public Transform target;
    public float moveSpeed = 6.0f;
    private float maxDistance = 15.0f;

    // Update is called once per frame
    void Update()
    {
        // Call FleeTarget() every frame
	    FleeTarget();

    }


    void FleeTarget()
    {
	// difference will give the desired direction
	Vector3 dir = target.position - transform.position;

	if(dir.magnitude < maxDistance)
	{
		Vector3 moveVector = dir.normalized * moveSpeed * Time.deltaTime;

		//If condition is met continue to flee
		transform.position -= moveVector;
	}

    }
}
