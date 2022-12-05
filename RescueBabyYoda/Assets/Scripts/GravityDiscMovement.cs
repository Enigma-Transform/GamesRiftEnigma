using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityDiscMovement : MonoBehaviour
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

        rb.velocity = transform.forward * speed;
    }
    private void Update()
    {
        //Destroys the object after 5 seconds to reduce the number of prefabs in scene.
        Destroy(this.gameObject, 5f);

    }
    private void OnCollisionEnter(Collision collision)
    {
        //Checks if collision tag is enemy 
        if (collision.gameObject.tag == "Enemy" )
        {
            //Gets the EnemyScript and calls the GravityChange() function in the enemy script.
            collision.gameObject.GetComponent<EnemyScript>().GravityChange();
            Destroy(this.gameObject);

        }
        else if(collision.gameObject.tag == "Environment")
        {
            //Gets the Environment script and calls the GravityChange() function in the enemy script.
            collision.gameObject.GetComponent<Environment>().GravityChange();
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "Barrell" || collision.gameObject.tag == "Wall"|| collision.gameObject.tag == "BabyYoda")
        {
            //destroys the disc if collided with any of the objects
            Destroy(this.gameObject);
        }
    }
}

