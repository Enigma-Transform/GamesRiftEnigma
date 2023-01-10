using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody rb;

    [Range(0, 100)]
    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * speed,ForceMode.Force);
        Destroy(this.gameObject, 5f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           // collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.gameObject.transform.position, ForceMode.Force);
        }
        if(collision.gameObject.tag =="Player"|| collision.gameObject.tag == "Block"|| collision.gameObject.tag=="Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
