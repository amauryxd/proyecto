using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRigibody : MonoBehaviour
{
    public Vector3 velocityxd;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = velocityxd;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
