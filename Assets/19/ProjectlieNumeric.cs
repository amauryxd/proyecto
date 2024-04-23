using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectlieNumeric : MonoBehaviour
{
    public Vector3 Pcurrent, Vcurrent;
    public float m;
    private Vector3 F, Pnext, Vnext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        F = m * new Vector3(0, -9.81f, 0);
        float dt = Time.fixedDeltaTime;
        Pnext = Pcurrent + dt * Vcurrent;
        Vnext = Vcurrent + dt * F / m;

        transform.position = Pnext;
        Pcurrent = Pnext;
        Vcurrent = Vnext;
    }
}
