using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoniCoscillator : MonoBehaviour
{
    public Transform mass, spring;
    public float amplitude, frecuency, phase;
    public float radius, turns, restLength;

    private List<Vector3> pointList = new List<Vector3>();
    private float time, length;

    void Start()
    {
        SetLineRenderer();
    }

    void Update()
    {
        time += Time.deltaTime;
        mass.localPosition = PositionFunction();
        length = mass.localPosition.y;
        ChangeMassColor();
        UpdateSpringPoints();
    }

    void ChangeMassColor()
    {
        float lerpFactor = (mass.localPosition.y - restLength) / amplitude;
        mass.GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.blue, Color.red, lerpFactor);
    }

    Vector3 PositionFunction()
    {
        float y = restLength + amplitude + Mathf.Sin(frecuency * time - phase);
        return new Vector3(0, y, 0);
    }

    void SetLineRenderer()
    {
        spring.GetComponent<LineRenderer>().useWorldSpace = false;
        spring.GetComponent<LineRenderer>().widthMultiplier = 0.05f;
    } 

    void UpdateSpringPoints()
    {
        pointList.Clear();
        float pi = Mathf.PI;
        for (float s = 0f; s <= 2f * pi; s += 0.025f)
        {
            Vector3 point = SpringShape(s);
            pointList.Add(point);
        }
        spring.GetComponent<LineRenderer>().positionCount = pointList.Count;
        spring.GetComponent<LineRenderer>().SetPositions(pointList.ToArray());
    }

    Vector3 SpringShape(float s)
    {
        float pi = Mathf.PI;
        float x = radius * Mathf.Cos(turns * s);
        float y = s * length / (2 * pi);
        float z = radius * Mathf.Sin(turns * s);
        return new Vector3(x, y, z);
    }
}
