using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class a : MonoBehaviour
{
    //variable para el enemigo tipo a
    public GameObject particle;
    public MeshRenderer meshxd;
    public float speed;
    public TextMeshProUGUI textoxd;
    public static int score=0;
    //la funcion al momento de tocar la flecha
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        particle.SetActive(true);
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        score++;
        textoxd.text = score.ToString();
        StartCoroutine(si());
    }
    //funcion para destruir el enemigo
    IEnumerator si()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    //buscamos el texto en pantalla
    private void Start()
    {
        textoxd = GameObject.FindGameObjectWithTag("Limit").GetComponent<TextMeshProUGUI>();
    }
    //movemos el enemigo
    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, step);
    }
}
