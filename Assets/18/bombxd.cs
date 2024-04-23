using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombxd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ref1"))
        {
            GameControllerSarten.player1 = false;
            Debug.Log(GameControllerSarten.player1);
        }
        if (other.CompareTag("Ref2"))
        {
            GameControllerSarten.player2 = false;
        }
        if (other.CompareTag("Ref3"))
        {
            GameControllerSarten.player3 = false;
        }
        Debug.Log(GameControllerSarten.player1);
        Debug.Log(GameControllerSarten.player2);
        Debug.Log(GameControllerSarten.player3);
    }
}
