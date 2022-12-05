using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public Transform[] spawnPoints;
	public GameObject[] wastePrefab;
	public GameObject toxicWastePrefab;
	public Vector3 center,size;
    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(WasteSpawnerRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	IEnumerator WasteSpawnerRoutine()
	{
		while (true)
		{
			Vector3 pos = new Vector3( Random.Range(-49.12f, 46.6f), 0,(Random.Range(50.4f, -44f)));
			GameObject wastePreafbs = Instantiate(wastePrefab[Random.Range(0, wastePrefab.Length)], pos,Quaternion.identity);
			Destroy(wastePreafbs, 8.5f);
			yield return new WaitForSeconds(2.5f);
		}
	
	}
}
