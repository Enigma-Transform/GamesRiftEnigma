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


    [SerializeField]
    int Health;

    [SerializeField]
    int currentHealth;

    [SerializeField]
    float charge;
    RaycastHit hit;
    [SerializeField]
    Transform originPoint;

    LineRenderer lrGO;
    [SerializeField]
    float maxDist;

    [SerializeField]
    AudioSource audioSo;
    Vector3 dir;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = Health;
        lrGO = lr.GetComponent<LineRenderer>();
    }


    private void Update()
    {
        
        if (transform.rotation.x > 0|| transform.rotation.x < 0)
        {
            transform.Rotate(new Vector3(0,transform.rotation.y,0));
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        dir = (transform.forward * maxDist).normalized;
        
        if (Input.GetMouseButton(0))
        {

            lr.SetActive(true);
            RaycastHit hit;
            lrGO.SetPosition(0, originPoint.position);
            charge += Time.deltaTime;

            if (charge >= 3)
            {
                rb.velocity = (dir)* speed*5;
                //charge = 0;
            }
            if (Physics.Raycast(originPoint.position, transform.forward, out hit))
            {
               
                lrGO.SetPosition(1, hit.point);
                Debug.DrawLine(originPoint.position, hit.point);

                if (hit.collider.tag == "Enemy")
                {
                 //   transform.LookAt(hit.collider.transform);
                   
                        
                    
                }
                if (charge >= 3)
                {
                    rb.AddForce((hit.collider.transform.position- transform.position).normalized*speed,ForceMode.Impulse);
                   //charge = 0;
                }
                // Do something with the object that was hit by the raycast.
            }
            else
            {
                lrGO.SetPosition(1, dir);
                Debug.DrawLine(originPoint.position, dir);
            }
        }
        else
        {
            lr.SetActive(false);
            charge = 0;
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
            rb.velocity = Vector3.zero;
            charge = 0;
        }
    }
}
