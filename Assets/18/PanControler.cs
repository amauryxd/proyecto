using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanControler : MonoBehaviour
{
    public Transform leftPlayer, rightPlayer;
    public float hitTime;
    private Animator animator;
    private Transform target;
    public KeyCode keycodeLeft;
    public KeyCode keycodeRight;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = rightPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keycodeLeft)) {
            animator.SetTrigger("LeftMove");
            target = leftPlayer;
        }
        if (Input.GetKeyDown(keycodeRight))
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
            hitTime -= 0.1f;
            other.GetComponent<Rigidbody>().velocity = hitVelocity;
            other.GetComponent<Rigidbody>().AddTorque(randomTorque, ForceMode.Impulse);
        }   
    }
}
