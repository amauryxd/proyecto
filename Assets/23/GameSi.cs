using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSi : MonoBehaviour
{
    public GameObject shellprfab;
    public GameObject spawn;
    public int counterP1;
    public int counterP2;
    public TextMeshProUGUI textP1;
    public TextMeshProUGUI textP2;
    public GameObject WW; 
    // Start is called before the first frame update
    void Start()
    {
        counterP1 = 0;
        counterP2 = 0;
        StartCoroutine(Empezar());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Jugador 1: " + counterP1 + " \nJugador 2: " + counterP2);
        textP1.text = counterP1.ToString();
        textP2.text = counterP2.ToString();
    }

    public IEnumerator Empezar()
    {
        yield return new WaitForSeconds(3);
        Instantiate(shellprfab, spawn.transform.position, spawn.transform.rotation);
    }
    public IEnumerator Final(int l)
    {
        //Debug.Log("Gano el jugador " + l + "!");
        WW.SetActive(true);
        WW.GetComponent<TextMeshProUGUI>().text = "Gano el jugador " + l + "!";
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(3);
    }
}
