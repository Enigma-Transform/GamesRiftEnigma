using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAppearDissappear : MonoBehaviour
{
    [SerializeField]
    int random;
    [SerializeField]
    float time;
    [SerializeField]
    GameObject block;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
            time += Time.deltaTime;
        
              

        if (time >= 10)
        {
            random = Random.Range(0, 2);
            time = 0;

        }

        if (random == 0)
        {
            block.SetActive(false);
        }

        else if (random == 1)
        {
            block.SetActive(true);
        }
    }
}
