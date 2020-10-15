using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : MonoBehaviour
{
    public GameObject rigidSphere;
    public static int numSpheres = 8;
    public GameObject[] spheres = new GameObject[numSpheres];
    public float velocity = 6.0f;
    public float minDistance = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numSpheres; i++)
        {
            spheres[i] = Instantiate(rigidSphere, new Vector3(Random.Range(30, 120), .5f, Random.Range(30, 120)), /*Quaternion.Euler(0, Random.Range(10, 30), 0)*/Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        separationMovement();
        alignmentMovement();
        cohesionMovement();
    }



    Vector3 Separation(GameObject s)
    {
        Vector3 avoidVector = new Vector3();

        for (int i = 0; i < numSpheres; i++)
        {
            if (spheres[i] != s)
            {
                if ((spheres[i].transform.position - s.transform.position).magnitude < 15)
                {
                    avoidVector = avoidVector - (spheres[i].transform.position - s.transform.position);
                }
            }
        }
        return avoidVector;
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


    Vector3 cohesionMethod(GameObject j)
    {
        Vector3 pv = new Vector3();
        for (int i = 0; i < numSpheres; i++)
        {
            if (spheres[i] != j)
                pv = pv + spheres[i].transform.position;
        }
        pv = pv / (numSpheres - 1);
        return (pv - j.transform.position) / 100;
    }


    void separationMovement()
    {
        for (int i = 0; i < numSpheres; i++)
        {
            Vector3 avoidSpheres = Separation(spheres[i]);
            spheres[i].GetComponent<Rigidbody>().velocity = avoidSpheres;
            Vector3 moveVector = avoidSpheres.normalized * Time.deltaTime;
            spheres[i].transform.position += moveVector;
        }
    }

    void alignmentMovement()
    {
        for (int i = 0; i < numSpheres; i++)
        {
            Vector3 alignSpheres = Alignment(spheres[i]);

            Vector3 moveVector = alignSpheres.normalized * velocity * Time.deltaTime;
            spheres[i].transform.position += moveVector;
        }
    }

    void cohesionMovement()
    {
        for (int i = 0; i < numSpheres; i++)
        {
            Vector3 cohesionVector = cohesionMethod(spheres[i]);
            spheres[i].GetComponent<Rigidbody>().velocity = cohesionVector;
            Vector3 moveVector = cohesionVector.normalized * Time.deltaTime;
            spheres[i].transform.position += moveVector;
        }
    }

}

