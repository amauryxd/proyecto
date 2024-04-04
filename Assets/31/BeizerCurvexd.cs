using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class BeizerCurvexd : MonoBehaviour
{
    private int curvePoints = 100;
    private List<Transform> P = new List<Transform>();
    public Transform a, b, c, d, e;
    private int n;
    public GameObject SI;
    // Start is called before the first frame update
    void Awake()
    {
        InitCurve();
    }

    // Update is called once per frame
    void Update()
    {
        SampleCurve();
        float time = Time.deltaTime;
        SI.transform.position += Bezier(time*0.00001f);
    }
    // Bezier Functions
    public void InitCurve()
    {
        int i = 0;
        float deltaZ = 5f;
        /*
        foreach (Transform child in transform)
        {
            P.Add(child);
            child.localPosition = i * deltaZ * Vector3.forward;
            i++;
        }
        */
        P.Add(a);
        P.Add(b);
        P.Add(c);
        P.Add(d);
        P.Add(e);



        n = P.Count - 1;
        GetComponent<LineRenderer>().positionCount = curvePoints;
        GetComponent<LineRenderer>().widthMultiplier = 0.25f;


    }
    public void SampleCurve()
    {
        for (int i = 0; i < curvePoints; i++)
        {
            float s = (float)i / (float)(curvePoints - 1);
            GetComponent<LineRenderer>().SetPosition(i, Bezier(s));
        }
    }
    private int Factorial(int n)
    {
        int result = 1;
        for (int k = 1; k <= n; k++)
        {
            result *= k;
        }
        return result;
    }

    private int Binomial(int n, int i)
    {
        int result = Factorial(n) / (Factorial(i) * Factorial(n - i));
        return result;
    }

    private float PolBern(int n, int i, float s)
    {
        float result = Binomial(n, i) * Mathf.Pow(1f - s, n - i) * Mathf.Pow(s, i);
        return result;
    }

    public Vector3 Bezier(float s)
    {
        Vector3 result = Vector3.zero;
        for (int i = 0; i <= n; i++)
        {
            result += PolBern(n, i, s) * P[i].position;
        }
        return result;
    }

    public Vector3 BezierDerivative(float s)
    {
        Vector3 result = Vector3.zero;
        for (int i = 0; i <= n - 1; i++)
        {
            result += PolBern(n - 1, i, s) * (P[i + 1].position - P[i].position);
        }
        return n * result;
    }
}
