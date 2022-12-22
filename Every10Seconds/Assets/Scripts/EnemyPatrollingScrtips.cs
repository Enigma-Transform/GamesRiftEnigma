using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPatrollingScrtips : MonoBehaviour
{
    public enum EnemyState
    {
        Patrolling = 1,
        Chase =2,
    }

    [SerializeField]
    Transform[] patrollingPoints;
    [SerializeField]
    EnemyState enemyState = EnemyState.Patrolling;

    Rigidbody rb;
    [SerializeField]
    float speed;
    [SerializeField]
    bool reachedDestinationA,reachedDestinationB;
    Vector3 initalPos, currPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initalPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        switch (enemyState)
        {

            case EnemyState.Patrolling:
                PatrollingForward(transform.position);

                break;

            case EnemyState.Chase:

                break;

            default:
                break;
        }
    }


    void PatrollingForward(Vector3 currPos)
    {
        
            transform.LookAt(patrollingPoints[1]);
            Vector3 dir = patrollingPoints[1].position - currPos;
            rb.AddForce(dir*speed, ForceMode.Acceleration);
        

    }
    

}
