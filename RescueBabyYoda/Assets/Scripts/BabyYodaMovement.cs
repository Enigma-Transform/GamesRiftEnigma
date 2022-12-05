using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyYodaMovement : MonoBehaviour
{
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
    
    Vector3 dir;
    Transform player;
    [SerializeField]
    GameManager gameManager;
    private void Awake()
    {
        //Gets the rigidbody and assigns it to the rb variable which is of type Rigidbody.
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {

    }

  
    void FixedUpdate()
    {
        //Debug.DrawRay(RayoriginPoint.position, transform.forward * maxDist, Color.yellow);

        //Casts a ray from the Rayorigin point forward by a certain distance.
        RaycastHit hitinfo;
        if (Physics.Raycast(RayoriginPoint.position, transform.forward, out hitinfo, maxDist, layerMask))
        {
            if (hitinfo.collider.gameObject.tag == "Player")
            {
                //Makes the character rotate and look at the player.
                transform.LookAt(hitinfo.collider.transform.position);

                //calls the FollowMovement function which takes 1 paramenter the player transform
                FollowMovement(hitinfo.transform);

                //Debug.DrawRay(RayoriginPoint.position, transform.forward * maxDist, Color.yellow);

            }

        }


    }
    void FollowMovement(Transform player)
    {
        if (player != null)
        {
            /*calculates the distance baby yoda should move by subtracting the players
            position from baby yodas current position on the x and z axis only*/
            Vector3 moveDist = new Vector3(player.position.x - transform.position.x, 0, player.position.z - transform.position.z);

            rb.velocity = new Vector3(moveDist.x, moveDist.y, moveDist.z) * speed;


        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="LightDisc"|| collision.gameObject.tag == "GravityDisc")
        {
            gameManager.BabyYodaDead();
        }
    }
}
