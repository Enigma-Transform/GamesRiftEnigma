using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public BoatHealthSlider boatHealthSlider;
	[SerializeField]
	public int playerHealth = 36;

	[SerializeField]
	int rockDamage = 6;

	[SerializeField]
	bool isShieldActive =false;

	[SerializeField]
	int shieldHealth = 5;

	public GameObject shieldPrefab;
	private void Awake()
	{
		boatHealthSlider.slider.value = playerHealth;
	}


	public void Damage()
	{
		if (playerHealth > 0 && isShieldActive == false)
		{
			playerHealth -= rockDamage;
			boatHealthSlider.DecreaseValue(playerHealth); Debug.Log("playerHealth" + playerHealth + "isShieldActive" + isShieldActive);

		}
		else if (isShieldActive == true && shieldHealth>0)
		{
			shieldHealth -= 1; Debug.Log("playerHealth" + playerHealth + "isShieldActive" + isShieldActive);
			if (shieldHealth == 0)
			{

				isShieldActive = false;
				shieldPrefab.SetActive(false);

			}
		}
	}

	private void OnTriggerEnter(Collider collision)
	{

		if (collision.tag == "Rocks")
		{
		
				Damage();
		}
	}
}
