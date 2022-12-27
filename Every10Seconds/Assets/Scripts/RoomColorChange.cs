using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;

public class RoomColorChange : MonoBehaviour
{
    [SerializeField]
    PostProcessVolume processVolume;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void ColorChangeRoom1()
    {
        processVolume.GetComponent<ColorAdjustments>().active = true;
    }
}
