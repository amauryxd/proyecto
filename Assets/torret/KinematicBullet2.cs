using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicBullet2 : MonoBehaviour
{
    public Vector3 P0, V0;
    float t;

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        transform.position = parabolicshot.Position(t, P0, V0);
        transform.forward = parabolicshot.Velocity(t, P0, V0);
    }
}
