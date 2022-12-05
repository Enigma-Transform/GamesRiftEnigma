using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesCollected : MonoBehaviour
{
	public Slider slider;

	public void IncreaseValue(int value)
	{
		slider.value = value;
	}

}
