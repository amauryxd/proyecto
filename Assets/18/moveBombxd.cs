using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBombxd : MonoBehaviour
{
    public float hitTime;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            Vector3 P0 = other.transform.position;
            Vector3 hitVelocity = HitVelocity(target, P0);
            Vector3 randomTorque = 100f * Random.onUnitSphere;

            other.GetComponent<Rigidbody>().velocity = hitVelocity;
            other.GetComponent<Rigidbody>().AddTorque(randomTorque, ForceMode.Impulse);
        }
    }
    private Vector3 HitVelocity(Transform target, Vector3 P0)
    {
        Vector3 Pf = target.position;
        Vector3 g = Physics.gravity;
        return (Pf - P0) / hitTime - 0.5f * g * hitTime;
    }
}
