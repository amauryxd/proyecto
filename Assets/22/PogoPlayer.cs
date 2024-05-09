using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogoPlayer : MonoBehaviour
{
    public float forceImpulse, jumpPulse;
    public string hInputName, vInputName;
    public float gravity;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = gravity * Vector3.up;
        float hInput = Input.GetAxis(hInputName);
        float vInput = Input.GetAxis(vInputName);
        Vector3 direction = new Vector3(hInput, 0, vInput).normalized;
        rb.AddForce(forceImpulse * direction * Time.deltaTime, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Base"))
        {
            rb.AddForce(jumpPulse * transform.up, ForceMode.Impulse);
        }
    }
}
