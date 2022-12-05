using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
	public float acceleration = 0;

	public void Accelerate()
	{
		acceleration = 1;
	}
	public void Deaccelerate()
	{
		acceleration = 0;
	}
}
