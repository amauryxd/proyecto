using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipManager : MonoBehaviour
{
    public int numEnemies;
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        /*
        for(int i = 0; i < numEnemies; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform);

            enemy.GetComponent<EnemyShip>().r = Random.Range(30f,1000f);
            enemy.GetComponent<EnemyShip>().w0 = Random.Range(-0.75f,0.75f);
            enemy.GetComponent<EnemyShip>().w1 = Random.Range(-0.75f,0.75f);
            enemy.GetComponent<EnemyShip>().f0 = Random.Range(0f,2*Mathf.PI);
            enemy.GetComponent<EnemyShip>().f1 = Random.Range(0f,2*Mathf.PI);
            enemy.GetComponent<EnemyShip>().h = Random.Range(250,500f);

        }
        */
        for (int i = 0; i < numEnemies; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform);

            enemy.GetComponent<EnemyShip>().r = Random.Range(30f, 1000f);
            enemy.GetComponent<EnemyShip>().w0 = Random.Range(-4.75f, 4.75f);
            enemy.GetComponent<EnemyShip>().w1 = Random.Range(-4.75f, 4.75f);
            enemy.GetComponent<EnemyShip>().f0 = Random.Range(0f, 3 * Mathf.PI);
            enemy.GetComponent<EnemyShip>().f1 = Random.Range(0f, 5 * Mathf.PI);
            enemy.GetComponent<EnemyShip>().h = Random.Range(150, 680f);

        }
    }

}
