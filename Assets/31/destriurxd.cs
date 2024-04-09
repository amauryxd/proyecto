using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destriurxd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(xd());
    }

    IEnumerator xd()
    {
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
    }
}
