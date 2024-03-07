using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmonicOscillatorSet : MonoBehaviour
{
    public GameObject oscillatorPrefab;
    public int oscillatorNum;

    void Start()
    {

        for (int i = 0; i < oscillatorNum; i++)
        {
            GameObject oscillator = Instantiate(oscillatorPrefab, transform.Find("Chain"));
            // Todos los osciladores creados son idénticos en propiedades
            oscillator.GetComponent<ArmoniCoscillator>().radius = 0.1f;
            oscillator.GetComponent<ArmoniCoscillator>().turns = 10;
            oscillator.GetComponent<ArmoniCoscillator>().restLength = 1;

            oscillator.GetComponent<ArmoniCoscillator>().amplitude = 0.75f;
            oscillator.GetComponent<ArmoniCoscillator>().frecuency = 5f;
            float phase = i * 2 * Mathf.PI / oscillatorNum; // A cada uno le damos una fase distinta!
            oscillator.GetComponent<ArmoniCoscillator>().phase = phase;
            oscillator.transform.localPosition = new Vector3(i, 0, 0);
        }

        for (int i = 0; i < oscillatorNum; i++)
            for (int j = 0; j < oscillatorNum; j++)
            {
                GameObject oscillator = Instantiate(oscillatorPrefab, transform.Find("Membrane"));
                // Todos los osciladores creados son idénticos en propiedades
                oscillator.GetComponent<ArmoniCoscillator>().radius = 0.1f;
                oscillator.GetComponent<ArmoniCoscillator>().turns = 10;
                oscillator.GetComponent<ArmoniCoscillator>().restLength = 1;

                oscillator.GetComponent<ArmoniCoscillator>().amplitude = 0.75f;
                oscillator.GetComponent<ArmoniCoscillator>().frecuency = 5f;
                float phase = (i+j) * 2 * Mathf.PI / oscillatorNum; // A cada uno le damos una fase distinta!
                oscillator.GetComponent<ArmoniCoscillator>().phase = phase;
                oscillator.transform.localPosition = new Vector3(i, 0, j);
            }

        transform.Find("Chain").gameObject.SetActive(false);
        transform.Find("Membrane").gameObject.SetActive(false);
    }

}
