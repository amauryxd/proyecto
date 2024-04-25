using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RK2 : MonoBehaviour
{
    public Vector3 Pcurrent, Vcurrent;
    public float m;
    private Vector3 Pmiddle, Vmiddle, Pnext, Vnext;

    void Start()
    {
        transform.position = Pcurrent;
    }


    void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;
        Pmiddle = Pcurrent + 0.5f * dt * Vcurrent;
        Vmiddle = Vcurrent + 0.5f * dt * F(Pcurrent,Vcurrent) / m;

        Pnext = Pmiddle + dt * Vmiddle;
        Vnext = Vmiddle + dt * F(Pmiddle, Vmiddle) / m;

        transform.position = Pnext;
        Pcurrent = Pnext;
        Vcurrent = Vnext;
    }

    Vector3 F(Vector3 P, Vector3 V)
    {
        //Vector3 result = m * new Vector3(9, -9.81f, 0);
        //Vector3 result = -P;
        float pMagnitude = P.magnitude;
        Vector3 result = -(P / Mathf.Pow(pMagnitude,3));
        return result;
    }
}
