using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ParametricCurvesResume : MonoBehaviour
{
    public float tMin;
    public float tMax;

    public enum FunctionKind
    {
        kind0,
        kind1,
        kind2,
        kind3
    }

    public FunctionKind functionKind;

    List<Vector3> points = new List<Vector3>();  


    void Start()
    {
        GetComponent<LineRenderer>().widthMultiplier = 0.1f;
    }

    
    void Update()
    {
        SamplePoints();
    }

    void SamplePoints()
    {
        points.Clear();
        for (float t = tMin; t < tMax; t += 0.025f)
        {
            Vector3 newPoint = F(t);
            points.Add(newPoint);
        }
        GetComponent<LineRenderer>().positionCount = points.Count;
        GetComponent<LineRenderer>().SetPositions(points.ToArray());
    }

    // Función que engloba y selecciona los diferentes tipos de funciones F1, F2, F3
    // Se selecciona la que se encuentre habilitada con el enumerador

    Vector3 F(float t)
    {
        Vector3 vectorFunction = Vector3.zero;
        switch (functionKind)
        {
            case FunctionKind.kind1:
                vectorFunction =  F1(t);
                break;

            case FunctionKind.kind2:
                vectorFunction = F2(t);
                break;

            case FunctionKind.kind3:
                vectorFunction = F3(t);
                break;

            default:
                vectorFunction = F0(t);
                break;

        }
        return vectorFunction;  
    }

    Vector3 F0(float t)
    {
        return Vector3.zero;
    }

    // Funciones Vectoriales para graficar
    // A partir de aquí realizan las modificaciones!!

    Vector3 F1(float t)
    {
        float x = 5*Mathf.Cos(t);
        float y = 5*Mathf.Sin(t);
        float z = 5*Mathf.Cos(3*t);
        return new Vector3(x, y, z);
    }

    Vector3 F2(float t)
    {
        float x = t*Mathf.Cos(t);
        float y = t * Mathf.Sin(t);
        float z = t;
        return new Vector3(x, y, z);
    }

    Vector3 F3(float t)
    {
        float x = 2 * Mathf.Cos(2 * t * 2 * Mathf.PI);
        float y = 2 * Mathf.Cos(t * 2 * Mathf.PI) * Mathf.Sin(t * 2 * Mathf.PI);
        float z = Mathf.Sin(t * 2 * Mathf.PI);
        return new Vector3(x, y, z);
    }
}
