using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicBullet : MonoBehaviour
{
    public Vector3 P0, V0;
    float t;

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        transform.position = positionfuntion();
        transform.forward = velocityfuntion();
    }
    Vector3 positionfuntion()
    {
        Vector3 g = new Vector3(0, -9.81f, 0);
        return 0.5f * g * t * t + V0 * t + P0;
    }
    Vector3 velocityfuntion()
    {
        Vector3 g = new Vector3(0, -9.81f, 0);
        return  g * t  + V0;
    }
}
