using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikedWheels : MonoBehaviour
{
    public GameObject wheelPrefab;
    public float speed;
    public float timerange;
    public float raterange;

    float res;

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject wheel = Instantiate(wheelPrefab, transform.position, Quaternion.identity);
            Vector3 velocity = speed * transform.right;
            wheel.GetComponent<Rigidbody>().velocity = velocity;
            wheel.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, -speed / 1f);
        }
        */
        if (chocar.pl1)
        {
            res++;
        }
        if (chocar.pl2)
        {
            res++;
        }
        if (chocar.pl3)
        {
            res++;
        }
        if (chocar.pl4)
        {
            res++;
        }
        if(res == 3)
        {
            StartCoroutine(spwanerTime());
        }
    }

    private void Start()
    {
        InvokeRepeating("a", timerange, raterange);
        res = 0;
        chocar.pl1 = false;
        chocar.pl2 = false;
        chocar.pl3 = false;
        chocar.pl4 = false;
    }

    void a()
    {
        //StartCoroutine(spwanerTime());
        speed = Random.Range(4, 10);
        //yield return new WaitForSeconds(Random.Range(1, 6));
        GameObject wheel = Instantiate(wheelPrefab, transform.position, Quaternion.identity);
        Vector3 velocity = speed * transform.right;
        wheel.GetComponent<Rigidbody>().velocity = velocity;
        wheel.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, -speed / 1f);
    }
    IEnumerator spwanerTime()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
