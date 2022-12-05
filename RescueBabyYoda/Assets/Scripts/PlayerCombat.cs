using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    EnemyHealth enemyHealth;
    [SerializeField]
    Transform rayOriginPoint,barrelPoint;

    [SerializeField]
    LayerMask layerMask;
    [Range(0, 100)]
    [SerializeField]
    float damage;
    [SerializeField]
    GameObject sonicCannon;
    [SerializeField]
    bool isGravityGun,isLightDisc = false;
   
    //bool isSonicCannon;
    [SerializeField]
    Rigidbody enemyRB;

    /*[Range(0, 100)]
    [SerializeField]
    float pushBackForce;

    [SerializeField]
    LineRenderer lineRenderer;
    */
    [SerializeField]
    LightDiscMovement lightDisc;

    [SerializeField]
    GravityDiscMovement gravityDisc;

    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    GameObject lighDiscGun, gravityDiscGun;
    [SerializeField]
    AudioSource audioSourceLightDiscGun,audioSourceGravityGun;

    [SerializeField]
    AudioClip audioClip, audioClipGravityGun;
    Ray ray;
    private void Awake()
    {
    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        //Checks Input from Primary fire button or left mouse button to be exact is pressed and also checks if isLightDisc boolean variable is true
         if (Input.GetMouseButtonDown(0) && isLightDisc == true)
         {
            //plays the audio clip for before each object is instantiated into the world.
            audioSourceLightDiscGun.PlayOneShot(audioClip);

            //instantiates the object into the world at the start of the barrell point.
            Instantiate(lightDisc,barrelPoint.position,barrelPoint.rotation);

         }

        if (Input.GetMouseButtonDown(0) && isGravityGun == true)
        {
            //plays the audio clip for before each object is instantiated into the world.
            audioSourceGravityGun.PlayOneShot(audioClip);

            //instantiates the object into the world at the start of the barrell point.
            Instantiate(gravityDisc, barrelPoint.position, barrelPoint.rotation);

        }
        /*
        //Checks Input from left mouse button is pressed
        if (Input.GetMouseButton(0))
        {
            mouseButtonPress = true;
            //ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        }
        else
        {
            mouseButtonPress = false;
        }*/
    }
    void FixedUpdate()
    {
        /*if(isSonicCannon == true)
        {
            if (mouseButtonPress == true)
            {
                RaycastHit hitinfo; Debug.DrawRay(rayOriginPoint.position, transform.forward * maxDist, Color.yellow);

                if (Physics.Raycast(ray, out hitinfo, maxDist, layerMask))
                {
                    if (hitinfo.collider.gameObject.tag == "Enemy" || hitinfo.collider.gameObject.tag == "StaticEnemy")
                    {
                        lineRenderer.SetPosition(0, rayOriginPoint.position);
                        lineRenderer.SetPosition(1, hitinfo.point);
                        hitinfo.collider.GetComponent<EnemyHealth>().DamageTaken(damage);
                        enemyRB = hitinfo.collider.GetComponent<Rigidbody>();
                        Vector3 dir = hitinfo.transform.position- transform.position;
                        enemyRB.AddForce(dir*pushBackForce,ForceMode.Impulse);
                        
                    }
                }
                else
                {
                    Debug.DrawLine(rayOriginPoint.position, rayOriginPoint.position + rayOriginPoint.forward * maxDist, Color.yellow);
                    lineRenderer.SetPosition(0, rayOriginPoint.position);
                    lineRenderer.SetPosition(1, rayOriginPoint.position + rayOriginPoint.forward * maxDist  );
                }
                lineRenderer.enabled = true;

            }*/
            /*else
            {
                lineRenderer.enabled = false;
            }*/
      
       //Checks if mouseButtonPress boolean value is true and isGravityGun boolean is true
       /*if(isGravityGun == true)
        {
            if (mouseButtonPress == true)
            {
                RaycastHit hitinfo;
                Debug.DrawRay(rayOriginPoint.position, transform.forward * maxDist, Color.yellow);
                //Casts a ray from the origin point in the foward direcion and extends the ray by the maxDist.
                if (Physics.Raycast(rayOriginPoint.position, transform.forward, out hitinfo, maxDist, layerMask))
                {
                    //Checks if the tag of the gameobject the ray has come in contact with.
                    if (hitinfo.collider.gameObject.tag == "Enemy")
                    {
                        //plays the audio source
                        audioSourceGravityGun.PlayOneShot(audioClipGravityGun);

                        ////draws the line renderer from the origin poin to the point it comes in contact with.
                        // lineRenderer.SetPosition(0, rayOriginPoint.position);
                        //lineRenderer.SetPosition(1, hitinfo.point);

                        //Gets the EnemyScript compopent and calls the GravityChange funcion.
                        hitinfo.collider.gameObject.GetComponent<EnemyScript>().GravityChange();
                    }
                    else if (hitinfo.collider.tag == "Environment")
                    {
                        hitinfo.collider.GetComponent<Environment>().GravityChange();
                    }


                }
                else
                {
                    //Debug.DrawLine(rayOriginPoint.position, rayOriginPoint.position + rayOriginPoint.forward * maxDist, Color.yellow);
                    // lineRenderer.SetPosition(0, rayOriginPoint.position);
                    //lineRenderer.SetPosition(1, rayOriginPoint.position + rayOriginPoint.forward * maxDist);
                }
                //  lineRenderer.enabled = true;

            }
            else
            {
                //  lineRenderer.enabled = false;

            }
        }*/
       

    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.tag == "SonicBlasterPWRUP")
        {
            isSonicCannon = true;
            //sonicCannon.SetActive(true);
            Destroy(other.gameObject);
        }
        */

        //Checks if the objects tag is LightDiscPWRUP
        if (other.tag == "LightDiscPWRUP")
        {
            //sets the values to true
            isLightDisc = true;
            lighDiscGun.SetActive(true);
            //destroys the game object that came the player came in contact with
            Destroy(other.gameObject);
        }

        //Checks if the objects tag is GravityGunPWRUP
        if (other.tag == "GravityGunPWRUP")
        {
            //sets the values to true
            gravityDiscGun.SetActive(true);
            isGravityGun = true;
            Destroy(other.gameObject);
        }

        //Checks if the objects tag is RoomExit
        if (other.tag == "RoomExit")
        {
            
            //check if the value is true
            if (isLightDisc == true)
            {   
                //sets the values to false
                isLightDisc = false;
                lighDiscGun.SetActive(false);


            }
         
            /*if (isSonicCannon == true)
            {
                isSonicCannon = false;


            }*/
        }
    } 
}
