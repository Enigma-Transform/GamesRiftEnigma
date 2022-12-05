using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
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
    [SerializeField]
    float damage;
    [Range(0, 100)]
    [SerializeField]
    int floatSpeed;
    [SerializeField]
    bool chasePlayer;
    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip audioClip;
    // Start is called before the first frame update

    private void Awake()
    {
        //Searches the scene for an object of type GameManager and assigns it to the variable gameManager
        gameManager = FindObjectOfType<GameManager>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        chasePlayer = true;
    }
    private void Update()
    {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.DrawRay(RayoriginPoint.position, transform.forward * maxDist, Color.yellow);

        RaycastHit hitinfo;
        if (Physics.Raycast(RayoriginPoint.position, transform.forward, out hitinfo, maxDist, layerMask))
        {
            if (hitinfo.collider.gameObject.tag == "Player" && chasePlayer == true)
            {
                //Makes the object rotate and look at the player
                    transform.LookAt(hitinfo.collider.transform);
                    EnemyMovement(hitinfo.transform);
                    Debug.DrawRay(RayoriginPoint.position, transform.forward * maxDist, Color.yellow);

            }
        }
        else
        {
            //  Debug.Log("none");
        } 
    }

    //Changes the gravity of the enemy causing the enemy to float upwards.
     public void GravityChange()
     {
        
         
        chasePlayer = false;
            rb.useGravity = false;
            rb.AddForce(Vector3.up * floatSpeed, ForceMode.Impulse);

     }


        void EnemyMovement(Transform player)
        {
            if (player != null)
            {
                rb.velocity = new Vector3(player.position.x - transform.position.x,0, player.position.z - transform.position.z) *speed;

            }
        }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.PlayerDead();
        }

        else if(collision.gameObject.tag == "GravityDisc")
        {
            if (collision.gameObject.tag == "GravityDisc")
            {
                audioSource.PlayOneShot(audioClip);

                rb.velocity = transform.forward * 0;
                GravityChange();
            }
        }
    }

    
}

