using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separate : MonoBehaviour
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
            spheres[i] = Instantiate(rigidSphere, new Vector3(Random.Range(25, 50), .5f, Random.Range(25, 50)), Quaternion.identity);
            spheres[i].GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(2, 8), Random.Range(2, 8), Random.Range(2, 8));
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveSpheres();
    }


    // Movement of spheres after getting direction from Separation()
    void moveSpheres()
    {
        for (int i = 0; i < numSpheres; i++)
        {
            Vector3 avoidSpheres = Separation(spheres[i]);
            spheres[i].GetComponent<Rigidbody>().velocity = avoidSpheres;
            Vector3 moveVector = avoidSpheres.normalized * Time.deltaTime;
            spheres[i].transform.position += moveVector;
        }
    }

    // Calculate Projection direction
    Vector3 Separation(GameObject s)
    {
        Vector3 avoidVector = new Vector3();

        for(int i = 0; i < numSpheres; i++)
        {
            if(spheres[i] != s)
            {
                if((spheres[i].transform.position - s.transform.position).magnitude < 15)
                {
                    avoidVector = avoidVector - (spheres[i].transform.position - s.transform.position);
                }
            }
        }
        return avoidVector;
    }
}
