using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
	[SerializeField]
	float speed = 4f;
	Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
		startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
		if(transform.position.z< -24f)
		{
			transform.position = startPos;
		}
    }
}
