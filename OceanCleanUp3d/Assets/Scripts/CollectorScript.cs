using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorScript : MonoBehaviour
{
	public GameObject Ocean;
	Material material;
	private Color color;
	public SpawnManagerL2 spawnManagerL2;
	[SerializeField]
	int wasteCollected = 0;
	[SerializeField]
	int maxWasteCollected;
	int currentCollectedWaste;

	int maxCollectablesCollected;
	int currentCollectedCollectables;

	public PollutionCollectedScript pollutionCollectedScript;
	public CollectablesCollected collectablesCollected;
	[SerializeField]
	int collectables = 0;
	[SerializeField]
	float colorChange = 0;
	int colorChangeInterval = 0;

	private void Awake()
	{
		collectables = currentCollectedCollectables;
		wasteCollected = currentCollectedWaste;
		maxWasteCollected = 15;
		maxCollectablesCollected=10;
		material = Ocean.GetComponent<MeshRenderer>().material;
	}

	void WasteCollection()
	{
		if (currentCollectedWaste < maxWasteCollected)
		{
			currentCollectedWaste += 1;
			pollutionCollectedScript.IncreaseValue(currentCollectedWaste);
			Debug.Log("collected" + currentCollectedWaste);
			colorChangeInterval++;
			if (colorChangeInterval == 3)
			{
				colorChange = colorChange + 1.2f;
				material.SetFloat("ColorChangingValue", colorChange);
				colorChangeInterval = 0;
			}

		}
		else
		{
			spawnManagerL2.canSpawn1 = false;
		}
	}

	void Collectables()
	{
		if (currentCollectedCollectables < maxCollectablesCollected)
		{
			currentCollectedCollectables += 1;
			collectablesCollected.IncreaseValue(currentCollectedCollectables);
			Debug.Log("collectables" + currentCollectedCollectables);
		}
		else
		{
			spawnManagerL2.canSpawn3 = false;
		}
	}

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.tag == "Waste")
		{
			WasteCollection();
			Destroy(collision.gameObject);
		}
		if(collision.tag == "Collectable")
		{
			Collectables();
		}
		
	}
}
