using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
	private PlayerInput playerInput;
	Rigidbody rb;
	[SerializeField]
	float speed =6f;
	PlayerController pc;
	Vector3 rotationAngle;
	[SerializeField]
	float turnSpeed = 7f;
	InputHandler ihandler;
	// Start is called before the first frame update
	private void Awake()
	{
		playerInput = GetComponent<PlayerInput>();
		ihandler = GetComponent<InputHandler>();
		rb = GetComponent<Rigidbody>();
		pc = new PlayerController();
		pc.Player.Enable();
		
	}
	void Start()
    {
        
    }


	// Update is called once per frame
	void Update()
    {

		Vector3 dirtVector = pc.Player.TurningMovement.ReadValue<Vector2>();
		ApplyAcceleration();
		transform.Rotate(dirtVector*turnSpeed);
	}
	void ApplySteering(float dir)
	{
		//transform.Rotate(dir * turnSpeed * Time.deltaTime);
	}
	void ApplyAcceleration()
	{
		if (ihandler.acceleration == 1)
		{
			rb.drag = 0;
			rb.AddForce(transform.forward * speed, ForceMode.Force);
		}
		else
		{
			rb.drag = Mathf.Lerp(rb.drag, 3.0f, Time.fixedDeltaTime * 3f);
		}
	}

}
