using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        rb.AddForce(transform.forward*speed, ForceMode.Force);
        Destroy(this.gameObject, 5f);
    }
}
