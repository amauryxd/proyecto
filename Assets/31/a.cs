using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class a : MonoBehaviour
{
    public GameObject particle;
    public MeshRenderer meshxd;
    public float speed;
    public TextMeshProUGUI textoxd;
    public static int score=0;
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        particle.SetActive(true);
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        score++;
        textoxd.text = score.ToString();
        StartCoroutine(si());
    }
    
    IEnumerator si()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    private void Start()
    {
        textoxd = GameObject.FindGameObjectWithTag("Limit").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, step);
    }
}
