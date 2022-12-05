using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float floatSpeed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update

    public void GravityChange()
    {
        rb.useGravity = false;
        rb.AddForce(Vector3.up * floatSpeed, ForceMode.Impulse);

    }
  
  
}
