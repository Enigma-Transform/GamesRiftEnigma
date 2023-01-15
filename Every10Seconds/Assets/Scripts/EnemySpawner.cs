using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    Transform[] spawnPoints;
    public bool isSpawn ;
    int spawnPointCounter;
    // Start is called before the first frame update
    void Start()
    {
    }

   IEnumerator EnemySpawningRoutine()
    {
        while (true)
        {
            if (spawnPointCounter <= spawnPoints.Length-1)
            {
                GameObject enemyGO = Instantiate(enemy, spawnPoints[spawnPointCounter].position, Quaternion.identity);
            }
            else
            {
                spawnPointCounter = 0;
            }
            yield return new WaitForSeconds(2.5f);
            spawnPointCounter++;


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(EnemySpawningRoutine());

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            StopCoroutine(EnemySpawningRoutine());
        }
    }
}
