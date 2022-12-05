using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Range(0, 50)]
    [SerializeField]
    float health;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip audioClip;


    private void Awake()
    {
        audioSource.Stop();

    }

    //Damages the enemy when called by subtracting the from the health. Takes 1 parameter a float for the amount of damage.
    public void DamageTaken(float damage)
    {
        if (health > 0)
        {
            audioSource.PlayOneShot(audioClip);
            health -= damage;

        }

        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
   
}
