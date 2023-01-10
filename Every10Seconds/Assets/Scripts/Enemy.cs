using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject[] treeGO;

    public bool isEnemyHit;
    [SerializeField]
    float time= 0;
    public enum MorphState
    {
        TurretEnemy =1,
        ChasingEnemy=2,
        PickUp=3,
    }
    [SerializeField]
    int state;

    [SerializeField]
    GameObject[] morphStatesGO;

    public MorphState morphStateEnum;
    [SerializeField]
    bool isEnemySate,isPowerUpState,isCalmState;

    GameObject enemyGO, calmGO, pickupGO, powerUpGo;

    bool treeSpawned = false;

    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = morphStatesGO[1].transform.position;
      //  isEnemyHit = script.isEnemyHit;

        morphStatesGO[0].transform.position = pos;
        morphStatesGO[2].transform.position = pos;
        //isEnemyHit = script.isEnemyHit;
        
        if(isEnemyHit == false)
        {
            time += Time.deltaTime;
            if (time >= 10)
            {
                state = Random.Range(0,4);
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
                        morphStatesGO[1].GetComponent<ChasePlayerScript>().enemyMove = true;
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
        else if(isEnemyHit == true)
        {
            if(treeSpawned == false)
            {
                Instantiate(treeGO[Random.Range(0,treeGO.Length-1)], new Vector3(pos.x, 0.804f, pos.z),transform.rotation);
                treeSpawned = true;

            }
        }
        
        
    }

  

  
}
