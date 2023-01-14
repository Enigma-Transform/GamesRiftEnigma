using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargePoints : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField]
    float rechargeValue;

    [Range(0, 100)]
    [SerializeField]
    float health;

    private void Start()
    {
    }

    private void Update()
    {
        if (health <= 0)
        {
           // Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(health > 0)
            {
                health -= rechargeValue; 
                other.GetComponent<Player3d>().RechargeHealth(rechargeValue);


            }
        }
    }


 
}
