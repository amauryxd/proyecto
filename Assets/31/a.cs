using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a : MonoBehaviour
{
    public GameObject particle;
    public MeshRenderer meshxd;
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        particle.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
