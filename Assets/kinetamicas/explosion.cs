using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
     Vector3 InitalPosition, InitalVelocity;
    public GameObject particlePrefab;
    public int howMany;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i <= howMany; i++)
            {
                GameObject Particle = Instantiate(particlePrefab, InitalPosition, Quaternion.identity);
                Particle.GetComponent<particle>().P0 = Random.insideUnitSphere * 1;
                Particle.GetComponent<particle>().V0 = Random.insideUnitSphere * 5 * speed;
                Destroy(Particle, 8f);
            }
        }
    }
}
