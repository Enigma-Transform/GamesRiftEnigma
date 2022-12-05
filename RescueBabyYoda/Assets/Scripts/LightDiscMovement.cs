using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDiscMovement : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField]
    float speed;
    [SerializeField]
    Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
       

    }
    // Start is called before the first frame update
    void Start()
    {
        //
        rb.velocity = transform.forward * speed;
    }
    private void Update()
    {
        Destroy(this.gameObject, 5f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" )
        {
            //Gets the EnemyHealth script and calls the DamageTaken function in the enemy health script.

            collision.gameObject.GetComponent<EnemyHealth>().DamageTaken(5f);
            Destroy(this.gameObject);

        }
        else if(collision.gameObject.tag == "Environment" || collision.gameObject.tag == "Barrell" || collision.gameObject.tag == "Wall")
        {            //destroys the disc if collided with any of the objects

            Destroy(this.gameObject);
        }
    }
  
}
