using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3d : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    bool isKeyPressedD, isKeyPressedA, isKeyPressed;

    [SerializeField]
    GameObject lr;
    public Camera camera;

    [Range(0, 100)]
    [SerializeField]
    float rotSpeed;

    [Range(0, 100)]
    [SerializeField]
    float speed;

    [Range(0, 100)]
    [SerializeField]
    float dashSpeed;

    [SerializeField]
    int Health;

    [SerializeField]
    int currentHealth;

    [SerializeField]
    float charge;

    [Range(0,100)]
    [SerializeField]
    float maxCharge;

    [SerializeField]
    Transform originPoint;

    LineRenderer lrGO;
    [SerializeField]
    float maxDist;

    [SerializeField]
    AudioSource audioSo;
    Vector3 dir;

    [SerializeField]
    bool mbUp;

    [SerializeField]
    bool isCharged;

    [SerializeField]
    RoomUnlock roomUnlock;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = Health;
        lrGO = lr.GetComponent<LineRenderer>();
    }


    private void Update()
    {
        dir = (transform.forward * maxDist);

        if (transform.rotation.x > 0|| transform.rotation.x < 0)
        {
            transform.Rotate(new Vector3(0,transform.rotation.y,0));
        }

        if (Input.GetMouseButton(0))
        {
            if (charge < maxCharge)
            {
                charge += Time.deltaTime;

            }
            lr.SetActive(true);
            lrGO.SetPosition(0, originPoint.position);
            lrGO.SetPosition(1,dir*maxDist+transform.position);
            mbUp = false; 
           
        }
        if (Input.GetMouseButtonUp(0))
        {
            lr.SetActive(false);
            if (charge >= maxCharge)
            {
                isCharged = true;
            }
             mbUp = true;
        }

        if(charge== 0)
        {
            isCharged = false;
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
     
        if(mbUp == true)
        {

            if (isCharged)
            {
                rb.velocity = (dir) * maxDist*dashSpeed;
                charge = 0;
            }
           
        }
        
       
    
     float direction = Input.GetAxisRaw("Vertical");
        float turn = Input.GetAxisRaw("Horizontal");
        Vector3 rot = new Vector3(0, 10, 0);


        // transform.Rotate(0, transform.position.y * rotSpeed, 0,Space.Self);
        //rb.MoveRotation(Quaternion.Euler(rot*speed));
        if (turn > 0)
        {
            rb.AddTorque(transform.up * turn * rotSpeed);

        }
        else if (turn < 0)
        {
            rb.AddTorque(-transform.up * -turn * rotSpeed);

        }


        if (direction > 0)
        {
            rb.velocity = transform.forward * speed;
        }
        else if (direction < 0)
        {
            rb.velocity = -transform.forward * speed;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Wall")
        {
            if(collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyNew>().isEnemyHit = true;
                roomUnlock.GetComponent<RoomUnlock>().Room1TreeCount();
            }
            
            rb.velocity = Vector3.zero;
            charge = 0;
        }

        if(collision.gameObject.tag == "PatrollingEnemy")
        {
            collision.gameObject.GetComponent<EnemyNew>().isEnemyHit = true;
            roomUnlock.GetComponent<RoomUnlock>().Room1TreeCount();

            collision.gameObject.GetComponent<ChasePlayerScript>().enemyMove = false;

        }
    }
}
