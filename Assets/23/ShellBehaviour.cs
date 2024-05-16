using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellBehaviour : MonoBehaviour
{
    public float minSpeedX, minSPeedZ, maxAbsoluteSpeed;
    public float speedIncrement;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 randomVector = Random.onUnitSphere;
        randomVector.y = 0f;
        rb.velocity = randomVector.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        LimitVelocity();
    }
    void LimitVelocity()
    {
        //Vector3 velocity = rb.velocity;
        float signVx = Mathf.Sign(rb.velocity.x);
        float signVz = Mathf.Sign(rb.velocity.z);

        if (Mathf.Abs(rb.velocity.x) < minSpeedX)
            rb.velocity = new Vector3(signVx * minSpeedX, 0, rb.velocity.z);

        if (Mathf.Abs(rb.velocity.z) < minSPeedZ)
            rb.velocity = new Vector3(rb.velocity.x, 0, signVz * minSPeedZ);

        if (rb.velocity.magnitude > maxAbsoluteSpeed)
            rb.velocity = maxAbsoluteSpeed * (rb.velocity.normalized);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("FoosBallPlayer"))
        {
            minSpeedX += speedIncrement;
            minSPeedZ += speedIncrement;
        }
    }
}
