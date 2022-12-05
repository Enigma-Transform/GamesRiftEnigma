using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float time= 0;
    public enum MorphState
    {
        Calm =1,
        Enemy =2,
        PowerUp=3,
        PickUp=4,
    }
    [SerializeField]
    int state;

    [SerializeField]
    GameObject[] morphStatesGO;

    public MorphState morphStateEnum;
    [SerializeField]
    bool isEnemySate,isPowerUpState,isCalmState;

    GameObject enemyGO, calmGO, pickupGO, powerUpGo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        if(time >= 10)
        {
            state = Random.Range(1, 5);
            time = 0;
          
            switch (state)
            {

                case 1:
                     morphStatesGO[0].SetActive(true);
                   // Instantiate(morphStatesGO[0], transform.position, Quaternion.identity);
                    morphStatesGO[1].SetActive(false);
                    morphStatesGO[2].SetActive(false);

                    break;

                case 2:
                    morphStatesGO[1].SetActive(true);
                    //Instantiate(morphStatesGO[1], transform.position, Quaternion.identity);
                    morphStatesGO[0].SetActive(false);
                    morphStatesGO[2].SetActive(false);

                    break;   

                case 3:
                    morphStatesGO[2].SetActive(true);
                    //Instantiate(morphStatesGO[2], transform.position, Quaternion.identity);
                    morphStatesGO[0].SetActive(false);
                    morphStatesGO[1].SetActive(false);
                    break;

                default:
                    break;
            }
        }
        
    }

  

    


    void CalmState()
    {

    }


    void PowerUpState()
    {

    }
}
