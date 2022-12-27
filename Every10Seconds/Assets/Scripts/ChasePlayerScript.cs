using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayerScript : MonoBehaviour
{

    public bool enemyMove;
    GameObject player;
    Rigidbody rb;
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
            Debug.Log(player.transform.position);
        }

    }
    private void FixedUpdate()
    {

        if (enemyMove == true)
        {
            transform.LookAt(player.transform);
            rb.velocity = -(transform.position - player.transform.position).normalized * 5f;

        }
    }
}
