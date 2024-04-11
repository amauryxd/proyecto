using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destriurxd : MonoBehaviour
{
    // Destruir las flechas despues de un rato
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
