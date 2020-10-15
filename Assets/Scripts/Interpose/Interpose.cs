using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpose : MonoBehaviour
{

    public Transform target1;
    public Transform target2;
    public float moveSpeed = 6.0f;
    private float minDistance = 0.2f;


    // Update is called once per frame
    void Update()
    {
	// Calls Interpose() every frame
	InterposeObject();
    }

    void InterposeObject()
    {

	// difference between vectors divided by two will give midpoint
	Vector3 midPosition1 = target1.position - transform.position;
	Vector3 midPosition2 = target2.position - transform.position;

	// Actual midpoint between two targets
	Vector3 midPoint = new Vector3((midPosition1.x+midPosition2.x)/2.0f, 0, (midPosition1.z+midPosition2.z)/2.0f);


	// Check to see if interpose process is completed
	if(midPoint.magnitude > minDistance)
	{
		Vector3 moveVector = midPoint.normalized*moveSpeed*Time.deltaTime;

		// If condition is met, continue moving to the midpoint between targets
		transform.position += moveVector;

	}
    }
}
