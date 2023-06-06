using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// attach this once the projectile prefab is made and create a game object using rb
public class EnemyProjectile : MonoBehaviour
{

    [SerializeField] private Rigidbody rb; // game object of the bullet
    
    [SerializeField] private float lanuchForce; // force when lanuch

    [SerializeField] private float destroyTime; // destory time after lanuch

    [SerializeField] private PlayerHealth player_health;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * lanuchForce; // set the bullet velocity
        rb.useGravity = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyTime); // destroy bullet if not hit
    }

    // check for collision with player
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player") // check if hit player
        {
            
            //PlayerHealth player_health = other.transform.GetComponent<PlayerHealth>();

            if (!player_health)
            {
                Debug.Log("null");
            }

            player_health.underAttack();

            Destroy(gameObject);

        }
    }
}
