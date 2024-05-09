using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisionPLayteasdha : MonoBehaviour
{
    public int playerCount;
    private void Start()
    {
        playerCount = 3;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("asdiyuagsuj");
        if (other.CompareTag("Player"))
        {
            playerCount--;
        }
        if(playerCount == 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
