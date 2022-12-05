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
                //Patrolling();

                break;

            case EnemyState.Chase:

                break;

            default:
                break;
        }
    }


    void PatrollingForward(Vector3 currPos,bool isDestinationB)
    {
        if (!isDestinationB)
        {
            transform.LookAt(patrollingPoints[1]);
            Vector3 dir = patrollingPoints[1].position - currPos;
            rb.AddForce(dir*speed, ForceMode.Acceleration);
        }

    }
     void PatrollingBack(Vector3 currPos, bool isDestinationA)
    {
        if (!isDestinationA)
        {
            transform.LookAt(patrollingPoints[0]);
            Vector3 dir = patrollingPoints[0].position - currPos;
            rb.AddForce(dir * speed, ForceMode.Acceleration);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
       if(other.tag == "PointA")
        {
            Debug.Log("A");
            reachedDestinationB =false;
            reachedDestinationA = true;
            PatrollingForward(transform.position, reachedDestinationB);
        }
        if (other.tag == "PointB")
        {
            Debug.Log("B");
            reachedDestinationB = true;
            reachedDestinationA = false;
            PatrollingBack(transform.position, reachedDestinationA);
        }
    }

}
