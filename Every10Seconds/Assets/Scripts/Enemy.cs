using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float time= 0;
    public enum MorphState
    {
        Enemy =1,
        Calm =2,
        PowerUp=3,
    }
    [SerializeField]
    int state;

    [SerializeField]
    GameObject[] morphStatesGO;
    public MorphState morphStateEnum;
    GameObject enemyGo, powerUPGO,calmGO;
    [SerializeField]
    bool isEnemySate,isPowerUpState,isCalmState;
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
            state = Random.Range(1, 4);
            time = 0;
          
            switch (state)
            {

                case 1:
                    morphStatesGO[0].SetActive(true);
                    morphStatesGO[1].SetActive(false);
                    morphStatesGO[2].SetActive(false);

                    break;

                case 2:
                    morphStatesGO[1].SetActive(true);
                    morphStatesGO[0].SetActive(false);
                    morphStatesGO[2].SetActive(false);

                    break;   

                case 3:
                    morphStatesGO[2].SetActive(true);
                    morphStatesGO[0].SetActive(false);
                    morphStatesGO[1].SetActive(false);
                    break;

                default:
                    break;
            }
        }
        
    }


    void AttackState()
    {

    }


    void CalmState()
    {

    }


    void PowerUpState()
    {

    }
}
