using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitboxesxd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            other.GetComponent<Rigidbody>().AddExplosionForce(20, Vector3.zero, 50, 50, ForceMode.Impulse);
        }
    }
}
