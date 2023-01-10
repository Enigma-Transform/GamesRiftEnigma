using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathEffectScript : MonoBehaviour
{
    [SerializeField]
    ParticleSystem deathEffectssystem;
    //[SerializeField]
    //GameObject deathEffectssystemGO;
    [SerializeField]
    Transform enemyTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyTransform != null)
        {
            transform.position = enemyTransform.position;

        }
    }
    public void DeathEffect()
    {
         ParticleSystem particleGO = Instantiate(deathEffectssystem,transform.position,Quaternion.identity);
        Destroy(particleGO,1f);
        //deathEffectssystem.Play();


    }
}
