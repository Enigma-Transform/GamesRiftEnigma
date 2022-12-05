 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyancyScript : MonoBehaviour
{
	public float underWaterDrag = 3;
	public float underWaterAngularDrag = 1;
	public float airDrag = 0f;
	public float AirAngularDrag = 0.05f;
	Rigidbody rb;
	public float floatingPower = 138f;
	bool underwater;
	public float waterHeight = 0f;
	public Transform[] FloatingPoints;
	int floatingPointsUnderWater;
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		floatingPointsUnderWater = 0;
		for(int i = 0; i < FloatingPoints.Length; i++)
		{
			float diff = FloatingPoints[i].transform.position.y - waterHeight;

			if (diff < 0)
			{
				rb.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(diff),FloatingPoints[i].transform.position, ForceMode.Force);
				floatingPointsUnderWater =+1;
				if (!underwater)
				{
					underwater = true;
					switchStates(true);
				}
			}
		}
		
		 if(underwater&& floatingPointsUnderWater==0)
		{
			underwater = false;
			switchStates(false);
		}
    }


	void switchStates(bool isUnderwater)
	{
		if (isUnderwater)
		{
			rb.drag = underWaterDrag;
			rb.angularDrag = underWaterAngularDrag;
		}
		else
		{
			rb.drag = airDrag;
			rb.angularDrag = AirAngularDrag;
		}
	}
}
