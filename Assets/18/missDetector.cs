using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missDetector : MonoBehaviour
{
    public GameObject ply;
    public GameObject sarten;
    public GameObject Sphe;
    public GameObject bomba;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            ply.GetComponent<Rigidbody>().useGravity = true;
            ply.GetComponent<Rigidbody>().AddExplosionForce(15, Vector3.zero, 100, 100, ForceMode.Impulse);
            sarten.GetComponent<PanControler>().enabled = false;
            Sphe.SetActive(true);
            StartCoroutine(otraboma());
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator otraboma()
    {
        yield return new WaitForSeconds(5);
        bomba.GetComponent<BombGenerator>().CreateBomb();
    }
}
