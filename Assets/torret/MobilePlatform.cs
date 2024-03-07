using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    public Transform platformA, platformB;

    [Range(0f,1f)]
    public float lerpParametrer;

    private float time;
    public float frecuency;
    public float phase;

    void Update()
    {
        time += Time.deltaTime;
        lerpParametrer = 0.5f * (1 + Mathf.Sin(frecuency * time - phase));
        transform.position = LerpUwu(platformA.position, platformB.position, lerpParametrer);
        //transform.position = Vector3.Lerp(platformA.position, platformB.position, lerpParametrer);
    }

    Vector3 LerpUwu(Vector3 A, Vector3 B, float s)
    {
        return (B - A) * s + A;
    }
}
