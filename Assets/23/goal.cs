using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    public GameObject gamesi;
    public bool isPlayer1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shell") && isPlayer1)
        {
            if (gamesi.GetComponent<GameSi>().counterP1 < 3)
            {
                //StopAllCoroutines();
                gamesi.GetComponent<GameSi>().counterP1++;
                Destroy(other.gameObject);
                StartCoroutine(gamesi.GetComponent<GameSi>().Empezar());
                Debug.Log("si");
            }
            else
            {
                //StopAllCoroutines();
                Debug.Log("gano1");           
                StartCoroutine(gamesi.GetComponent<GameSi>().Final(1));

            }
        }
        else if(other.CompareTag("Shell") && !isPlayer1)
        {
            if(gamesi.GetComponent<GameSi>().counterP2 < 3)
            {
                //StopAllCoroutines();
                gamesi.GetComponent<GameSi>().counterP2++;
                Destroy(other.gameObject);
                StartCoroutine(gamesi.GetComponent<GameSi>().Empezar());
                Debug.Log("si2");
            }
            else
            {
                //StopAllCoroutines();
                Debug.Log("gano2");               
                StartCoroutine(gamesi.GetComponent<GameSi>().Final(2));
            }
        }
    }
    
}
