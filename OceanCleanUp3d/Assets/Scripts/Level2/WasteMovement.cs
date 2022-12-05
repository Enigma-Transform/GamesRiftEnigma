using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteMovement : MonoBehaviour
{
	[SerializeField]
	float speed = 3.5f;
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
    void FixedUpdate()
    {
		rb.AddForce( new Vector3(0,0,-1) * speed, ForceMode.Force);
		//transform.Translate(new Vector3(0, 0, -1)*speed*Time.deltaTime);
    }
}
