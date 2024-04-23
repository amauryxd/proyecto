using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missDetector : MonoBehaviour
{
    public GameObject ply;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            ply.GetComponent<Rigidbody>().useGravity = true;
            ply.GetComponent<Rigidbody>().AddExplosionForce(15, Vector3.zero, 10, 10, ForceMode.Impulse);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
