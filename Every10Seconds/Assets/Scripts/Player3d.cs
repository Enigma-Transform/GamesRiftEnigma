using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3d : MonoBehaviour
{

    Enemy enemyScript;
    [SerializeField]
    CinemachineImpulseSource impulseSource;
    Rigidbody rb;

    [SerializeField]
    bool isKeyPressedD, isKeyPressedA, isKeyPressed;

    [SerializeField]
    GameObject lr;
    //public Camera camera;

    [Range(0, 100)]
    [SerializeField]
    float rotSpeed;

    [Range(0, 100)]
    [SerializeField]
    float speed;

    [Range(0, 100)]
    [SerializeField]
    float dashSpeed;

    [Range (0, 100)]
    [SerializeField]
    float Health;

    [SerializeField]
    float currentHealth;



    [Range(0,100)]
    [SerializeField]
    float maxCharge;

    [SerializeField]
    Transform originPoint;

   // LineRenderer lrGO;
    [SerializeField]
    float maxDist;

   // [SerializeField]
   // AudioSource audioSo;
    Vector3 dir;

    [SerializeField]
    bool mbUp,mbDown;

    [SerializeField]
    bool isCharged;

   // [SerializeField]
  //  RoomUnlock roomUnlock;

    [SerializeField]
    Timer1 timer1;
    [SerializeField]
    bool shake = false;
    [SerializeField]
    float streakTimer, streakTimerMaxValue;
    
  public  int enemiesPurified;
    [SerializeField]
    int streak;
    [SerializeField]
    bool startStreak;
    [SerializeField]
    float deductionValueMultiplie;
    [SerializeField]
    GameManager gm;

    [SerializeField]
    float radius;
    [SerializeField]
    Transform groundCheckOrigin;
    LayerMask groundLayer;
  public  int roomNo;
  //  [SerializeField]
  //  GameObject trail1,trail2,trail3;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = Health;
        gm.setMaxValueHealth(currentHealth);
        gm.UpdateHealthBar(currentHealth);
     //   lrGO = lr.GetComponent<LineRenderer>();
      
    }

    private void Start()
    {
        gm.setMaxValue(streakTimer);

    }
    private void Update()
    {
        dir = (transform.forward * maxDist);

      
        if (transform.rotation.x > 0|| transform.rotation.x < 0)
        {
            transform.Rotate(new Vector3(0,transform.rotation.y,0));
        }

        if (Input.GetMouseButtonDown(0))
        {
           /* if (charge < maxCharge)
            {
                charge += Time.deltaTime;

            }*/
          //  lr.SetActive(true);
          //  lrGO.SetPosition(0, originPoint.position);
           // lrGO.SetPosition(1,dir+transform.position);
            mbUp = false;
            mbDown = true;
           
        }
        if (Input.GetMouseButtonUp(0))
        {
          //  lr.SetActive(false);
            mbUp = true;
            mbDown = false;
           /* if (charge >= maxCharge)
            {
                isCharged = true;
            }
             mbUp = true;*/
        }

        /*  if(charge == 0)
          {
              isCharged = false;
              mbUp = false;

          }*/
        /*if (rb.velocity.magnitude >= 25f)
        {
            rb.drag = 3f;
        }
        else
        {
            rb.drag = 0;
        }*/

        if (startStreak)
        {

            if (streakTimer > 0)
            {
                streakTimer -= Time.deltaTime * 1.5f;
                gm.UpdateStreakBar(streakTimer,startStreak);


            }

            if (streakTimer == 0)
            {
                startStreak = false;
                enemiesPurified = 0;
                gm.UpdateStreakBar(streakTimer, startStreak);
            }
            if (enemiesPurified == 5 && streakTimer>0)
            {
                gm.TreeSpawner();
                Debug.Log("spawn Tree");
                startStreak = false;
                enemiesPurified = 0;
                gm.UpdateStreakBar(streakTimer,startStreak);
            }
        }
    }
  
    // Update is called once per frame
    void FixedUpdate()
    {
       

        if (mbDown == true && mbUp == false)
        {

            //rb.velocity = (dir) * maxDist*dashSpeed;
           // trail1.SetActive(true);
          //  trail2.SetActive(true);
          //  trail3.SetActive(true);
            rb.AddForce(dir, ForceMode.Impulse);
             //charge = 0;
           
        }

        else
        {
            //trail1.SetActive(false);
           // trail2.SetActive(false);
            //trail3.SetActive(false);
        }
       
    
     float direction = Input.GetAxisRaw("Vertical");
        float turn = Input.GetAxisRaw("Horizontal");
        Vector3 rot = new Vector3(0, 10, 0);


        // transform.Rotate(0, transform.position.y * rotSpeed, 0,Space.Self);
        //rb.MoveRotation(Quaternion.Euler(rot*speed));
        if (turn > 0)
        {
            rb.AddTorque(transform.up * turn * rotSpeed);

        }
        else if (turn < 0)
        {
            rb.AddTorque(-transform.up * -turn * rotSpeed);

        }


       /* if (direction > 0)
        {
            rb.velocity = transform.forward * speed;
        }*/
        else if (direction < 0)
        {
            rb.velocity = -transform.forward*speed;
        }

    }

    public void TakeDamage(float damage)
    {
        if (currentHealth > 0)
        {

            currentHealth -= damage;
            gm.UpdateHealthBar(currentHealth);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Area1")
        {
             roomNo =1;

            gm.isArea1 = true;
            gm.isArea2 = false;
            gm.isArea3 = false;
        }
        else if (other.tag == "Area2")
        {
            roomNo = 2;

            gm.isArea1 = false;
            gm.isArea3 = false;
            gm.isArea2 = true;
        }
        else if (other.tag == "Area3")
        {
            roomNo = 3;
            gm.isArea1 = false;
            gm.isArea2 = false;
            gm.isArea3 = true;
        }

        if(other.tag == "DeadZone")
        {
            transform.position = new Vector3(0, 2f, -96.8f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Wall")
        {

            if (collision.gameObject.tag == "Enemy")
            {
                impulseSource.GenerateImpulse();


                if (rb.velocity.magnitude> 10)
                {

                    collision.gameObject.GetComponent<Enemy>().TakeDamageFromPlayer();
                        collision.gameObject.GetComponent<EnemyDeathEffectScript>().DeathEffect();
                        collision.gameObject.SetActive(false);
                    
                   
                    if(startStreak== false)
                    {
                        startStreak = true;
                    }
                    else if(startStreak == true)
                    {
                        streakTimer = streakTimerMaxValue;
                        gm.UpdateStreakBar(streakTimer,startStreak);
                    }
                    if (streakTimer > 0)
                    {
                        
                        enemiesPurified += 1;

                    }
                }
               
                

            }

            rb.velocity = Vector3.zero;
        }

        if(collision.gameObject.tag == "PatrollingEnemy")
        {
            impulseSource.GenerateImpulse();


            if (rb.velocity.magnitude > 10)

            {
                collision.gameObject.GetComponent<EnemyDeathEffectScript>().DeathEffect();
                collision.gameObject.GetComponent<ChasePlayerScript>().enemyMove = false;

                collision.gameObject.SetActive(false);
                if (startStreak == false)
                {
                    startStreak = true;
                }
                if (streakTimer > 0)
                {
                    enemiesPurified += 1;

                }
            }


        }

        if (collision.gameObject.tag == "StaticTurret")
        {
            impulseSource.GenerateImpulse();


            if (rb.velocity.magnitude > 10)
            {
                collision.gameObject.GetComponent<EnemyDeathEffectScript>().DeathEffect();
                collision.gameObject.SetActive(false);
            }


        }
        /*
        if (collision.gameObject.tag == "Key")
        {
          //  roomUnlock.GetComponent<RoomUnlock>().Room1TreeCount();
            //Destroy(collision.gameObject);

        }*/
    }

  
    public void RechargeHealth(float rechargeValue)
    {
        if(currentHealth < Health)
        {
            currentHealth += rechargeValue;
            gm.UpdateHealthBar(currentHealth);
        }
        
    }

}
