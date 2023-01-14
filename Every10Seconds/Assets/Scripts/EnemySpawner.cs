using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    Transform spawnPoints;
    public bool isSpawn;
  
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawningRoutine());
    }

   IEnumerator EnemySpawningRoutine()
    {
        while (true)
        {
                GameObject enemyGO = Instantiate(enemy, spawnPoints.position, Quaternion.identity);

            yield return new WaitForSeconds(2.5f);


        }
    }
}
