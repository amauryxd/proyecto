using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMovement : MonoBehaviour
{
    public float swing;
    public float decreaserTimer;
    public Transform fireBalls;
    public Transform HitBoxes;
    private BezierCurve2 _bezierCurve;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        _bezierCurve = GetComponent<BezierCurve2>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ControlPointsMovement();
        FireBallsMovement();
        HitBoxMovement();
        swing += Time.deltaTime * decreaserTimer;
    }

    void FireBallsMovement()
    {
        for(int i = 0; i < fireBalls.childCount; i++)
        {
            float si = (float)i / (fireBalls.childCount - 1f);
            fireBalls.GetChild(i).position = _bezierCurve.Bezier(si);
        }
    }

    void HitBoxMovement()
    {
        for (int i = 0; i < HitBoxes.childCount; i++)
        {
            float si = (float)i / (HitBoxes.childCount - 1f);
            HitBoxes.GetChild(i).position = _bezierCurve.Bezier(si);
        }
    }

    private void ControlPointsMovement()
    {
        float z1 = _bezierCurve.P[1].position.z;
        float z2 = _bezierCurve.P[2].position.z;
        _bezierCurve.P[1].position = CirclePath(5f, z1);
        _bezierCurve.P[2].position = CirclePath(5f, z2);
        time += Time.fixedDeltaTime;
    }

    Vector3 CirclePath(float radius, float zCoordinate)
    {
        float xCoordinate = radius * Mathf.Sin(swing * time);
        float yCoordinate = radius * Mathf.Cos(swing * time);
        return new Vector3(xCoordinate, yCoordinate, zCoordinate);
    }


}
