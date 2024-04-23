using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCube : MonoBehaviour
{
    public float t;
    public Vector3 P0, V0;

    void FixedUpdate()
    {
        t += Time.fixedDeltaTime;
        transform.position = CubePosition();
        //transform.forward = CubeVelocity();

    }

    Vector3 CubePosition()
    {
        Vector3 g = new Vector3(0, -9.81f, 0);
        return 0.5f * g * t * t + V0 * t + P0;
    }

    Vector3 CubeVelocity()
    {
        Vector3 g = new Vector3(0, -9.81f, 0);
        return g * t + V0;
    }
}
