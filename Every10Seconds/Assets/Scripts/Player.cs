using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Player : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    bool isKeyPressedD,isKeyPressedA,isKeyPressed;

  
    [Range(0,100)]
    [SerializeField]
    float rotSpeed;

    [Range(0, 100)]
    [SerializeField]
    float speed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    { 
    }
        // Update is called once per frame
    void FixedUpdate()
    {
       float direction = Input.GetAxisRaw("Vertical");
        float turn = Input.GetAxisRaw("Horizontal");
        Vector3 rot = new Vector3(0, 10, 0);


        // transform.Rotate(0, transform.position.y * rotSpeed, 0,Space.Self);
        //rb.MoveRotation(Quaternion.Euler(rot*speed));
        if (turn > 0)
        {
            rb.AddTorque(transform.up* turn * rotSpeed);

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
            rb.velocity = -transform.forward* speed;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PickUp")
        {
            Debug.Log(true);
            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
        }
    }
}
