using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Player : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    bool isKeyPressedD,isKeyPressedA,isKeyPressed;

  
    [Range(0,100)]
    [SerializeField]
    float rotSpeed;

    [Range(0, 100)]
    [SerializeField]
    float speed;

    [SerializeField]
    List<GameObject> storyCapsuleList = new List<GameObject>();

    [SerializeField]
    StoryTracker storyTracker;

    bool turnOn;
    [SerializeField]
    int Health;

    [SerializeField]
    int currentHealth;

    [SerializeField]
    GameManager gm;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = Health;
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        if(storyCapsuleList.Count > 0)
        {
           // storyTracker.StoryProgression(storyCapsuleList.Count);

        }
    }
        // Update is called once per frame
    void FixedUpdate()
    {
       float direction = Input.GetAxisRaw("Vertical");
        float turn = Input.GetAxisRaw("Horizontal");
        Vector3 rot = new Vector3(0, 10, 0);


        // transform.Rotate(0, transform.position.y * rotSpeed, 0,Space.Self);
        //rb.MoveRotation(Quaternion.Euler(rot*speed));
        if (turn > 0)
        {
            rb.AddTorque(transform.up* turn * rotSpeed);

        }
        else if (turn < 0)
        {
            rb.AddTorque(-transform.up * -turn * rotSpeed);

        }


        if (direction > 0)
        {
            rb.velocity = transform.forward * speed;
        }
        else if (direction < 0)
        {
            rb.velocity = -transform.forward* speed;
        }

    }
   void StoryCapsuleCollected(GameObject storyCapsuleGO)
    {
        storyCapsuleList.Add(storyCapsuleGO);
        //Debug.Log(storyCapsuleList.Count);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PickUp")
        {
            Debug.Log(true);
            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
        }

        else if(collision.gameObject.tag == "EnemyBullet")
        {
            if (currentHealth >= 0)
            {
                currentHealth -= 1;
            }

            if(currentHealth <= 0)
            {
                gm.GameOver();
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "StoryCapsuleA")
        {
            turnOn = true;
            //storyCapsuleList.Add(other.gameObject);
            other.GetComponent<StoryTracker>().StoryTextA(turnOn);
          //  other.GetComponent<StoryTracker>().StoryProgression(storyCapsuleList.Count);
            
        }
        else if (other.gameObject.tag == "StoryCapsuleB")
        {
            turnOn = true;
            //storyCapsuleList.Add(other.gameObject);
            other.GetComponent<StoryTracker>().StoryTextB(turnOn);
            //  other.GetComponent<StoryTracker>().StoryProgression(storyCapsuleList.Count);

        }
        else if (other.gameObject.tag == "StoryCapsuleC")
        {
            turnOn = true;
            //storyCapsuleList.Add(other.gameObject);
            other.GetComponent<StoryTracker>().StoryTextC(turnOn);
            //  other.GetComponent<StoryTracker>().StoryProgression(storyCapsuleList.Count);

        }
        else if (other.gameObject.tag == "StoryCapsuleD")
        {
            turnOn = true;
            //storyCapsuleList.Add(other.gameObject);
            other.GetComponent<StoryTracker>().StoryTextD(turnOn);
            //  other.GetComponent<StoryTracker>().StoryProgression(storyCapsuleList.Count);

        }
        else if (other.gameObject.tag == "StoryCapsuleE")
        {
            turnOn = true;
            //storyCapsuleList.Add(other.gameObject);
            other.GetComponent<StoryTracker>().StoryTextE(turnOn);
            //  other.GetComponent<StoryTracker>().StoryProgression(storyCapsuleList.Count);

        }
        else if (other.gameObject.tag == "StoryCapsuleF")
        {
            turnOn = true;
            //storyCapsuleList.Add(other.gameObject);
            other.GetComponent<StoryTracker>().StoryTextF(turnOn);
            //  other.GetComponent<StoryTracker>().StoryProgression(storyCapsuleList.Count);
           

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "StoryCapsuleA")
        {
            turnOn = false;
            //storyCapsuleList.Add(other.gameObject);
            other.GetComponent<StoryTracker>().StoryTextA(turnOn);
        }
        else if(other.gameObject.tag == "StoryCapsuleB")
        {
                turnOn = false;
                //storyCapsuleList.Add(other.gameObject);
                other.GetComponent<StoryTracker>().StoryTextB(turnOn);
        }
        else if (other.gameObject.tag == "StoryCapsuleC")
        {
            turnOn = false;
            //storyCapsuleList.Add(other.gameObject);
            other.GetComponent<StoryTracker>().StoryTextC(turnOn);
        }
        else if (other.gameObject.tag == "StoryCapsuleD")
        {
            turnOn = false;
            //storyCapsuleList.Add(other.gameObject);
            other.GetComponent<StoryTracker>().StoryTextD(turnOn);
        }
        else if (other.gameObject.tag == "StoryCapsuleE")
        {
            turnOn = false;
            //storyCapsuleList.Add(other.gameObject);
            other.GetComponent<StoryTracker>().StoryTextE(turnOn);
        }
        else if (other.gameObject.tag == "StoryCapsuleF")
        {
            turnOn = false;
            //storyCapsuleList.Add(other.gameObject);
            other.GetComponent<StoryTracker>().StoryTextF(turnOn);
        }
    }


}
