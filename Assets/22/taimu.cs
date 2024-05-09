using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class taimu : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public float tiempo;
    
    // Start is called before the first frame update
    void Start()
    {
        texto.text = "30";
        tiempo = 30;
    }

    // Update is called once per frame
    void Update()
    {
        tiempo -= Time.deltaTime;
        texto.text = tiempo.ToString();
        if(tiempo <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
