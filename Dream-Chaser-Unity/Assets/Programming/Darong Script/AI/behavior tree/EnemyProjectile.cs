using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


// attach this once the projectile prefab is made and create a game object using rb
public class EnemyProjectile : MonoBehaviour
{

    [SerializeField] private Rigidbody rb; // game object of the bullet
    
    [SerializeField] private float lanuchForce; // force when lanuch

    [SerializeField] private float rotationForce; // force when lanuch

    [SerializeField] private float destroyTime; // destory time after lanuch

    private PlayerHealth player_health;

    private Transform player;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //transform.position = Vector3.MoveTowards(transform.position, player.position, 10000f);
        //rb.velocity = transform.forward * lanuchForce;
        rb.useGravity = false;
        player_health = GameObject.Find("Player").GetComponent<PlayerHealth>();
        player = GameObject.Find("Player").transform;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        // homing
        if (player_health.healthCheck() )
        {
            Vector3 direction = player.position - rb.position;
            direction.Normalize();
            Vector3 rotationAmount = Vector3.Cross(transform.forward,direction);
            rb.angularVelocity = rotationAmount * rotationForce;
            rb.velocity = transform.forward * lanuchForce;
            
        }
        
        Destroy(gameObject, destroyTime); // destroy bullet if not hit
    }

    // check for collision with player
    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.tag != "Bullet")
        {
            if (other.gameObject.tag == "Player") // check if hit player
            {

                // if player still alive, take damage
                if (player_health.healthCheck())
                {
                    player_health.underAttack();
                }



            }
            Destroy(gameObject);
        }
        
    }
}
