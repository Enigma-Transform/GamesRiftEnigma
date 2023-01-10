using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    
    [SerializeField]
    Enemy enemyScript;

    //EnemyAttackStateVariables
    [SerializeField]
    Transform RayoriginPoint;
    [SerializeField]
    float maxDist = 2f;
    [SerializeField]
    LayerMask layerMask;

    Rigidbody rb;
    [SerializeField]
    float damage;

    [SerializeField]
    bool chasePlayer;

    [SerializeField]
    EnemyBullet enemyBullet;

    bool isShot;

    [SerializeField]
    float time;
    RaycastHit hitinfo;

    Color iniColor;
    [Range(0,100)]
    [SerializeField]
    float maxChargeTime;
    // Start is called before the first frame update

    [SerializeField]
    float size;

    [SerializeField]
    GameObject lrGO;

    LineRenderer lr;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        lr = lrGO.GetComponent<LineRenderer>();
    }
    void Start()
    {
       iniColor=  gameObject.GetComponent<Renderer>().material.color;

        ///StartCoroutine(Enemyrotation());
    }



    private void Update()
    {
            lrGO.SetActive(true);
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, Vector3.forward);
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //AttackState();

       // TurretAiming(); 
     

    }

  /*  void AttackState()
    {
        Vector3 pos = transform.position;
        RaycastHit hitinfo;
        if (Physics.SphereCast(RayoriginPoint.position, size, Vector3.forward, out hitinfo, maxDist, layerMask))
        { 
            if (hitinfo.collider.gameObject.tag == "Player")
            {
               // Debug.Log("player");
                //Makes the object rotate and look at the player
               // transform.LookAt(hitinfo.collider.transform);
                if (hitinfo.collider != null)
                {
                    rb.velocity = new Vector3(hitinfo.collider.transform.position.x - transform.position.x, 0, hitinfo.collider.transform.position.z - transform.position.z) * speed;
                    //Debug.Log(true);
                }


                Debug.DrawRay(RayoriginPoint.position, transform.forward * maxDist, Color.yellow);

            }
        }
        else
        {
            transform.position = pos;
            //  Debug.Log("none");
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(enemyScript.isEnemyHit == false)
            {
                TurretAiming();
                gameObject.GetComponent<Renderer>().material.color = Color.black;
                gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

            }

        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            enemyScript.isEnemyHit = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {   
        {
            gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");

            gameObject.GetComponent<Renderer>().material.color = iniColor; ;

        }
    }
    void TurretAiming()
    {
        time +=Time.deltaTime;
        if (time >= maxChargeTime)
        {

            StartCoroutine(shooting());
            time = 0;

        }
       
    }

    IEnumerator shooting()
    {
        if (isShot == false)
        {
            Instantiate(enemyBullet, RayoriginPoint.position, transform.rotation);
            isShot = true;
            //Debug.Log(isShot);

        }

        yield return new WaitForSeconds(0.5f);
        isShot = false;
    
        //Debug.Log(isShot);

    }

  /*  void OnDrawGizmos()
    {
        Gizmos.color = Color.red;


        Gizmos.DrawSphere(hitinfo.point,size);
    }*/
   
}
