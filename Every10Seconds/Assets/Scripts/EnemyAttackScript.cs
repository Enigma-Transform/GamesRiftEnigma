using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    //EnemyAttackStateVariables
    [SerializeField]
    Transform RayoriginPoint;
    [SerializeField]
    float maxDist = 2f;
    [SerializeField]
    LayerMask layerMask;

    [Range(0, 100)]
    [SerializeField]
    float speed;

    Rigidbody rb;
    [SerializeField]
    float damage;
    [Range(0, 100)]
    [SerializeField]
    int floatSpeed;
    [SerializeField]
    bool chasePlayer;

    [SerializeField]
    EnemyBullet enemyBullet;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //AttackState();

        TurretAiming();

    }

    void AttackState()
    {
        Vector3 pos = transform.position;
        RaycastHit hitinfo;
        if (Physics.Raycast(RayoriginPoint.position, transform.forward, out hitinfo, maxDist, layerMask))
        {
            if (hitinfo.collider.gameObject.tag == "Player")
            {
               // Debug.Log("player");
                //Makes the object rotate and look at the player
               // transform.LookAt(hitinfo.collider.transform);
                if (hitinfo.collider != null)
                {
                    rb.velocity = new Vector3(hitinfo.collider.transform.position.x - transform.position.x, 0, hitinfo.collider.transform.position.z - transform.position.z) * speed;
                    //Debug.Log(true);
                }


                Debug.DrawRay(RayoriginPoint.position, transform.forward * maxDist, Color.yellow);

            }
        }
        else
        {
            transform.position = pos;
            //  Debug.Log("none");
        }
    }


    void TurretAiming()
    {
        RaycastHit hitinfo;
        if (Physics.Raycast(RayoriginPoint.position, transform.forward, out hitinfo, maxDist, layerMask))
        {
            if (hitinfo.collider.gameObject.tag == "Player")
            {

                StartCoroutine(shooting());
            }
        }
    }

    IEnumerator shooting()
    {
        Instantiate(enemyBullet,RayoriginPoint.position,Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
    }
}
