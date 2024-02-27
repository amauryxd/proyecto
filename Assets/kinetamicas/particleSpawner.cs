using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSpawner : MonoBehaviour
{
    public Vector3 InitalPosition, InitalVelocity;
    public GameObject particlePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject Particle = Instantiate(particlePrefab, InitalPosition, Quaternion.identity);
            Particle.GetComponent<particle>().P0 = InitalPosition;
            Particle.GetComponent<particle>().V0 = InitalVelocity;
            Destroy(Particle, 5f);
        }
    }
}
