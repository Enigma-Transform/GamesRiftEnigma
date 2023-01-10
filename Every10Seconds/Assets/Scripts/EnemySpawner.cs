using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawningRoutine());
    }

   IEnumerator EnemySpawningRoutine()
    {
        while (true)
        {
            Instantiate(enemy, new Vector3(transform.position.x, 0.75f, transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(2.5f);

        }
    }
}
