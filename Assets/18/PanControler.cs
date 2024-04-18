using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanControler : MonoBehaviour
{
    public Transform leftPlayer, rightPlayer;
    public float hitTime;
    private Animator animator;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = rightPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            animator.SetTrigger("LeftMove");
            target = leftPlayer;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetTrigger("RightMove");
            target = rightPlayer;
        }
    }

    public void EnableCollider()
    {
        bool isEnabled = GetComponent<BoxCollider>().enabled;
        GetComponent<BoxCollider>().enabled = !isEnabled;
    }

    private Vector3 HitVelocity(Transform target, Vector3 P0)
    {
        Vector3 Pf = target.position;
        Vector3 g = Physics.gravity;
        return (Pf - P0) / hitTime - 0.5f * g * hitTime;
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
            Debug.Log("xd");
        }
    }
}
