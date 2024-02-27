using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public Transform A, B;
    public float tiempo;

    float speed,t;

    void Start()
    {
        transform.position = A.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceab = (B.position - A.position).magnitude;
        speed = distanceab / tiempo;
        Vector3 direction = (B.position - A.position).normalized;
        Vector3 P0 = A.position;
        Vector3 V0 = speed * direction;
        t += Time.deltaTime;
        transform.position = Kinematics.MovimientoRectilineoUniforme(t, P0, V0);
        //float P0 = Mathf.Sqrt(Mathf.Pow(B.position.x - A.position.x,2)+ Mathf.Pow(B.position.y - A.position.y,2) + Mathf.Pow(B.position.z - A.position.z,2f));
    }
}
