using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoatHealthSlider : MonoBehaviour
{
	public Player player;
	public Slider slider;
	private void Awake()
	{
		//slider.value = player.playerHealth; 
	}
	public void DecreaseValue(int value)
	{
		slider.value = value;
	}
}
