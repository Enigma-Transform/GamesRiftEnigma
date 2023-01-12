using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject[] treeGO;


    [SerializeField]
    ChasePlayerScript chasePlayerScript;

    [SerializeField]
    float time = 0;
    public enum MorphState
    {
        
        Enemy = 1,
        PowerUp = 2,
        PickUp = 3,
    }
    [SerializeField]
    int state;

    [SerializeField]
    GameObject[] morphStatesGO;

    public MorphState morphStateEnum;
    [SerializeField]
    bool isEnemySate, isPowerUpState, isCalmState;

    GameObject enemyGO, calmGO, pickupGO, powerUpGo;


    Vector3 pos;
    // Update is called once per frame
    void Update()
    {
        pos = morphStatesGO[0].transform.position;

        morphStatesGO[1].transform.position = pos;
        morphStatesGO[2].transform.position = pos;

        
            time += Time.deltaTime;
            if (time >= 10)
            {
                state = Random.Range(1, 5);
                time = 0;

                switch (state)
                {

                    case 1:
                        chasePlayerScript.GetComponent<ChasePlayerScript>().enemyMove = true;
                        morphStatesGO[0].SetActive(true);
                        // Instantiate(morphStatesGO[0], transform.position, Quaternion.identity);
                        morphStatesGO[1].SetActive(false);
                        morphStatesGO[2].SetActive(false);

                        break;

                    case 2:
                        chasePlayerScript.GetComponent<ChasePlayerScript>().enemyMove = false;
                        morphStatesGO[1].SetActive(true);
                        //Instantiate(morphStatesGO[1], transform.position, Quaternion.identity);
                        morphStatesGO[0].SetActive(false);
                        morphStatesGO[2].SetActive(false);

                        break;

                    case 3:
                        chasePlayerScript.GetComponent<ChasePlayerScript>().enemyMove = false;
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

   
}
