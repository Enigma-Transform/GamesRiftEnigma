using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerL2 : MonoBehaviour
{
	public Transform[] spawnPointsPollution;
	public GameObject[] wastePrefab;

	public Transform[] spawnPointsObstacle;
	public GameObject[] ObstaclePrefab;
	public GameObject[] CollectablesPrefab;

	public GameObject toxicWastePrefab;
	[SerializeField]
	float secondsCounter1 =3.5f, secondsCounter2 = 2.5f, secondsCounter3 = 3.5f;
	public bool canSpawn1 = true;
	public bool canSpawn2 = true;
	public bool canSpawn3 = true;

	// Start is called before the first frame update
	void Start()
    {
		StartCoroutine(WasteSpawnerRoutine());
		StartCoroutine(ObstacleSpawnerRoutine());
		StartCoroutine(CollectableSpawnerRoutine());


	}

	// Update is called once per frame
	void Update()
    {

	}
	IEnumerator WasteSpawnerRoutine()
	{
		while (canSpawn1== true)
		{
			GameObject wastePreafbs = Instantiate(wastePrefab[Random.Range(0, wastePrefab.Length)], spawnPointsPollution[Random.Range(0,spawnPointsPollution.Length)]);
			Destroy(wastePreafbs, 11.5f);
			yield return new WaitForSeconds(secondsCounter1);
		}

	}
	IEnumerator ObstacleSpawnerRoutine()
	{
		while (canSpawn2==true)
		{
			GameObject obstaclePrefab = Instantiate(ObstaclePrefab[Random.Range(0, ObstaclePrefab.Length)], spawnPointsObstacle[Random.Range(0, spawnPointsPollution.Length)]);
			Destroy(obstaclePrefab, 10.8f);
			yield return new WaitForSeconds(secondsCounter2);
		}
	}

	IEnumerator CollectableSpawnerRoutine()
	{
		while (canSpawn3==true)
		{
			GameObject collectablesPrefab = Instantiate(CollectablesPrefab[Random.Range(0, CollectablesPrefab.Length)], spawnPointsObstacle[Random.Range(0, spawnPointsPollution.Length)]);
			Destroy(collectablesPrefab, 10.8f);
			yield return new WaitForSeconds(secondsCounter3);
		}
	}
}
