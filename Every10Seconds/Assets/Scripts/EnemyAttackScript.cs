using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    //EnemyAttackStateVariables
    [SerializeField]
    Transform RayoriginPoint;
    [SerializeField]
    float maxDist = 2f;
    [SerializeField]
    LayerMask layerMask;

    [Range(0, 100)]
    [SerializeField]
    float speed;

    Rigidbody rb;
    [SerializeField]
    float damage;
    [Range(0, 100)]
    [SerializeField]
    int floatSpeed;
    [SerializeField]
    bool chasePlayer;

    [SerializeField]
    EnemyBullet enemyBullet;

    bool isShot;

    [SerializeField]
    float time;
    RaycastHit hitinfo;
    [SerializeField]
    float size;
    Color iniColor;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
       iniColor=  gameObject.GetComponent<Renderer>().material.color;

        ///StartCoroutine(Enemyrotation());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //AttackState();

       // TurretAiming(); 


    }

    void AttackState()
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
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            TurretAiming();
            gameObject.GetComponent<Renderer>().material.color = Color.black;
            gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
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
        if (time >= 2.5)
        {

            StartCoroutine(shooting());
            time = 0;

        }
        if (Physics.Raycast(RayoriginPoint.position, RayoriginPoint.transform.forward, out hitinfo, maxDist, layerMask))
        {
            if (hitinfo.collider.gameObject.tag == "Player")
            {

                //Debug.Log(time++ +"Player") ;
                
            }
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

        yield return new WaitForSeconds(1f);
        isShot = false;
    
        //Debug.Log(isShot);

    }

    IEnumerator Enemyrotation()
    {
        transform.Rotate(new Vector3(0,90,0));

        yield return new WaitForSeconds(4f);
        transform.Rotate(new Vector3(0, -90, 0));

        yield return new WaitForSeconds(1f);

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;


        Gizmos.DrawSphere(hitinfo.point,size);
    }

}
