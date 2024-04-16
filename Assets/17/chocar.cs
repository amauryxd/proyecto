using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chocar : MonoBehaviour
{
    public static bool pl1 = false;
    public static bool pl2 = false;
    public static bool pl3 = false;
    public static bool pl4 = false;

    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Player"))
        {
            //other.GetComponent<Rigidbody>().freezeRotation = false;
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            other.GetComponent<Rigidbody>().AddExplosionForce(20, Vector3.zero, 5, 50, ForceMode.Impulse);
            if(other.name == "Player1")
            {
                other.GetComponent<JumperPlayer>().enabled = false;
                pl1 = true;
            }
            if (other.name == "Player2")
            {
                other.GetComponent<jguador>().enabled = false;
                pl2 = true;
            }
            if (other.name == "Player3")
            {
                other.GetComponent<jugadro3>().enabled = false;
                pl3 = true;
            }
            if (other.name == "Player4")
            {
                other.GetComponent<jugdor4>().enabled = false;
                pl4 = true;
            }
        }
    }
}
