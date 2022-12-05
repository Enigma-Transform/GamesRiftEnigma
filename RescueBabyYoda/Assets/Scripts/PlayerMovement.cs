using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField]
    float speed;

    Rigidbody rb;


   
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          
    }


    private void FixedUpdate()
    {
        //Movement();
    }


    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = Vector3.forward * speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = Vector3.back * speed;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = Vector3.left * speed;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector3.right * speed;
        }
    }
}
