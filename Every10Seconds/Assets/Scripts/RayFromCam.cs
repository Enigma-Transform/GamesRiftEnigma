using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayFromCam : MonoBehaviour
{
    [SerializeField]
    LineRenderer lr;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            lr.SetPosition(0, transform.position);

            if (Physics.Raycast(transform.position,transform.forward, out hit))
            {
                lr.SetPosition(1, hit.point);
                Debug.DrawLine(transform.position,hit.point);

                Debug.Log(hit.collider.tag);

                // Do something with the object that was hit by the raycast.
            }
        }
    
    }
}
