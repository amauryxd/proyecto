using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerSarten : MonoBehaviour
{
    public static bool player1=true;
    public static bool player2=true;
    public static bool player3=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player1 && !player2 && player3)
        {
            Debug.Log("w1");
            StartCoroutine(carga());
        }
        if (!player1 && player2 && !player3)
        {
            Debug.Log("w2");
            StartCoroutine(carga());
        }
        if (player1 && !player2 && !player3)
        {
            Debug.Log("w3");
            StartCoroutine(carga());
        }
    }
    IEnumerator carga()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }
}
