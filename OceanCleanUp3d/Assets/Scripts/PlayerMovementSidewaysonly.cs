using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovementSidewaysonly : MonoBehaviour
{
	InputHandler ihandler;

	private PlayerInput playerInput;
	Rigidbody rb;
	[SerializeField]
	float speed = 75f;
	PlayerController pc;
	private void Awake()
	{
		playerInput = GetComponent<PlayerInput>();
		ihandler = GetComponent<InputHandler>();
		rb = GetComponent<Rigidbody>();
		pc = new PlayerController();
		pc.Player.SidewaysMovement.Enable();

	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 dirtVector = pc.Player.SidewaysMovement.ReadValue<Vector2>();
		rb.AddForce(dirtVector * speed, ForceMode.Force);

	}
}
