using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Enemy : MonoBehaviour
{
    GameObject player;

    [Range(0, 100)]
    [SerializeField]
    float damage;
   // [SerializeField]
    //GameObject[] treeGO;
    public bool enemyMove;

    public bool didEnemyHit;
    [SerializeField]
    float time= 0;
    public enum MorphState
    {
        TurretEnemy =1,
        ChasingEnemy=2,
    }
    [SerializeField]
    int state;

    [SerializeField]
    GameObject[] morphStatesGO;

    public MorphState morphStateEnum;
    [SerializeField]
    bool isEnemySate,isPowerUpState,isCalmState;



    bool treeSpawned = false;

    Vector3 pos;
    [SerializeField]
    GameManager gm;
    [Range(0, 100)]
    [SerializeField]
    float speed;
    public bool didPlayerHit;
    [SerializeField]
    ParticleSystem changePS;
    Rigidbody rb;
    [SerializeField]
    bool enemyChanged = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); player = GameObject.FindGameObjectWithTag("Player");

    }
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       // pos = morphStatesGO[1].transform.position;
      //  isEnemyHit = script.isEnemyHit;

     //   morphStatesGO[0].transform.position = pos;
      //  morphStatesGO[1].transform.position = pos;
        //isEnemyHit = script.isEnemyHit;
        
        if(didPlayerHit == false)
        {
            time += Time.deltaTime;
            if (time >= 10)
            {
                state = Random.Range(0,3);
                int currentState = state;

                time = 0;
              
                switch (state)
                {

                    case 0:
                        enemyChanged = true;
                        morphStatesGO[0].SetActive(true);
                        enemyMove = false;
                        // Instantiate(morphStatesGO[0], transform.position, Quaternion.identity);
                        morphStatesGO[1].SetActive(false);
                        morphStatesGO[2].SetActive(false);


                        break;

                    case 1:
                        enemyChanged = true;

                        morphStatesGO[1].SetActive(true);
                        enemyMove = true;
                        //Instantiate(morphStatesGO[1], transform.position, Quaternion.identity);
                        morphStatesGO[0].SetActive(false);
                        morphStatesGO[2].SetActive(false);

                        break;

                    case 2:
                        enemyChanged = true;

                        morphStatesGO[2].SetActive(true);
                        enemyMove = false;
                        //Instantiate(morphStatesGO[1], transform.position, Quaternion.identity);
                        morphStatesGO[1].SetActive(false);
                        morphStatesGO[0].SetActive(false);
                        break;
                    default:
                        break;
                }
            }
            if(enemyChanged == true)
            {
                changePS.Play();
                enemyChanged = false;
            }
            else
            {
                changePS.Stop();
            }
        }

        Destroy(this.gameObject, 40f);        
        
    }
    private void FixedUpdate()
    {
        if (enemyMove == true)
        {
            if (player.transform.position.y < 3f)
            {
                
                rb.velocity = -(transform.position - player.transform.position).normalized * speed;
            }


        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (rb.velocity.magnitude > collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude)
            {
                didEnemyHit = true;
                collision.gameObject.GetComponent<Player3d>().TakeDamage(damage);
                Destroy(this.gameObject);

              
            }

            // Destroy(this.gameObject);


        }
        if(collision.gameObject.tag == "Enemy")
        {
            Physics.IgnoreCollision(collision.collider, this.gameObject.GetComponent<Collider>(),true);
        }
    }

    public void TakeDamageFromPlayer()
    {
       
            //Debug.Log(didPlayerHit);
            if (treeSpawned == false)
            {
                // Instantiate(treeGO[Random.Range(0,treeGO.Length-1)], new Vector3(pos.x, 0.804f, pos.z),transform.rotation);
                if (gm != null)
                {
                    gm.NatureSpawn(transform.position, player.GetComponent<Player3d>().roomNo,state);
                    treeSpawned = true;

                }
                Destroy(this.gameObject);
           }
        
    }
}
