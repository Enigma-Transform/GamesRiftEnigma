using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMorphingTurret : MonoBehaviour
{
    [SerializeField]
    Transform RayoriginPoint;
    [SerializeField]
    EnemyBullet enemyBullet;
    [SerializeField]
    HealthBullet healthBullet;

    [SerializeField]
    float damage;

    [Range(0, 100)]
    [SerializeField]
    float maxChargeTime;
    public enum MorphState
    {
        TurretEnemy = 1,
        ChasingEnemy = 2,
        PickUp = 3,
    }
    [SerializeField]
    int state;
    bool isShot;
    [SerializeField]
    float waitTimeBullet,waitTimeHealth;

    bool shootHealth, shootBullet;
    Player3d player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player3d>();
    }
    // Start is called before the first frame update
    void Start()
    {

        // StartCoroutine(shootingBullets(shootBullet));
        //   StartCoroutine(shootingHealth(shootHealth));
        StartCoroutine(shooting());
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
   
    }
   
    IEnumerator shooting()
    {

        float i = 0;
        while (true)
        {
            while (i < 10)
            {
                Instantiate(enemyBullet, RayoriginPoint.position, transform.rotation);
                i++;
                yield return new WaitForSeconds(waitTimeBullet);

            }


            while (i > 0)
            {
                Instantiate(healthBullet, RayoriginPoint.position, transform.rotation);
                i--;
                yield return new WaitForSeconds(waitTimeHealth);
            }
            yield return null;
        }
           
    }
        

    
}

