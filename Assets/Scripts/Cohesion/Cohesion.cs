using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Cohesion : MonoBehaviour
{
    public GameObject rigidSphere;
    public static int numPrefabs = 8;
    public GameObject[] spheres = new GameObject[numPrefabs];
    public float velocity = 6.0f;
    public float minDistance = 0.2f;
  


    // Start is called before the first frame update
    void Start()
    {
        // Instantiate spheres
        for (int i = 0; i < numPrefabs; i++)
        {
            spheres[i] = Instantiate(rigidSphere, new Vector3(Random.Range(25,50), .5f, Random.Range(25, 50)), Quaternion.identity);
            spheres[i].GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(2, 8), Random.Range(2, 8), Random.Range(2, 8));
        }
    }


    // Update is called once per frame
    void Update()
    {
        cohesion();
    }

    // Movement 
    void cohesion()
    {
        for(int i = 0; i < numPrefabs; i++)
        {
            Vector3 center = cohesionMethod(spheres[i]);
            Vector3 movement = center.normalized * Time.deltaTime;
            spheres[i].GetComponent<Rigidbody>().velocity = center;
            spheres[i].transform.position += movement;
        }
    }

    Vector3 cohesionMethod(GameObject j)
    {
        Vector3 center = new Vector3();
        
        // set cohesionVector equal to the sum of all sphere positions in scene.
        for (int i = 0; i < numPrefabs; i++)
        {
            if (spheres[i] != j)
                center = center + spheres[i].transform.position;
        }

        // Calculate average to get the center of mass
        center = center / (numPrefabs - 1);
        center = (center - j.transform.position) / 100;
    
        return center;
    } 
}
