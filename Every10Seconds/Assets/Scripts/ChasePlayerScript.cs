using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChasePlayerScript : MonoBehaviour
{
    [SerializeField]
    Enemy enemyScript;
    public bool enemyMove;
    GameObject player;
    Rigidbody rb;
    [Range(0, 100)]
    [SerializeField]
    float speed;
    [Range(0, 100)]
    [SerializeField]
    float damage;
    private void Awake()
    {
        enemyMove = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (player != null)
        {
            // Debug.Log("Found");
            //Debug.Log(player.transform.position);
        }

    }
    private void FixedUpdate()
    {

        if (enemyMove == true)
        {
            if (player.transform.position.y < 3f)
            {
                transform.LookAt(player.transform);
                rb.velocity = -(transform.position - player.transform.position).normalized * speed;
            }
          

        }
    }

   /* private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (rb.velocity.magnitude >= collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude)
            {
                collision.gameObject.GetComponent<Player3d>().TakeDamage(damage);

                this.gameObject.SetActive(false);
            }
     
               // Destroy(this.gameObject);

            
        }
    }*/
}
