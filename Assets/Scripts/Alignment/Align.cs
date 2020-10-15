using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;



public class Align : MonoBehaviour
{
    public GameObject rigidSphere;
    public static int numSpheres = 8;
    public GameObject[] spheres = new GameObject[numSpheres];
    public float velocity = 6.0f;
    public float minDistance = 0.2f;

    void Start()
    {
        for (int i = 0; i < numSpheres; i++)
        {
            spheres[i] = Instantiate(rigidSphere, new Vector3(Random.Range(50, 90), .5f, Random.Range(50, 90)), Quaternion.Euler(0,Random.Range(10,30),0));
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveSpheres();

    }

    void moveSpheres()
    {
        for (int i = 0; i < numSpheres; i++)
        {
            Vector3 alignSpheres = Alignment(spheres[i]);
            
            Vector3 moveVector = alignSpheres.normalized * velocity* Time.deltaTime;
            spheres[i].transform.position += moveVector;
        }
    }

    Vector3 Alignment(GameObject sphere)
    {
        Vector3 alignVector = new Vector3();
        for (int i = 0; i < numSpheres; i++)
        {
            if (spheres[i] != sphere)
                alignVector = alignVector + spheres[i].transform.forward;
        }
        alignVector = alignVector / (numSpheres - 1);
        return (alignVector - sphere.transform.forward) / 8;
    }


}
