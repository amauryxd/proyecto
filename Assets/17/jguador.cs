using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jguador : MonoBehaviour
{
    [Range(0, 20)] public float JumpingImpulse;
    [Range(-20, -1)] public float Gravity;
    private bool grounded;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        Physics.gravity = new Vector3(0, Gravity, 0);
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(JumpingImpulse * transform.up, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
