using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanHealthTracker : MonoBehaviour
{
	[SerializeField]
	int oceanHealth = 25;
	int currentHealth;

	[SerializeField]
	int pollutionDamage = 6;

	public MetersScript metersScript;
    // Start is called before the first frame update
    void Start()
    {
		currentHealth = oceanHealth;
		metersScript.setMaxHealth(oceanHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	void Damage()
	{
		currentHealth -= pollutionDamage;
		metersScript.setHealth(currentHealth);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Waste")
		{
			Damage();
		}
	}
}
