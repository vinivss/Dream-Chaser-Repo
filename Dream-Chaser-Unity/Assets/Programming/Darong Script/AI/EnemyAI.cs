using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private float lowHealthThreshHold;
    [SerializeField] private DCMoveVin player;
    [SerializeField] public PlayerHealth player_health;

    [SerializeField] private Transform[] projectileSpawnLocation;
    [SerializeField] private GameObject bulletPrefab;

    private float currentHealth;

    void Start()
    {
        currentHealth = startingHealth;
        player = GetComponent<DCMoveVin>();
        
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        attack();
        Debug.Log(player_health.healthCheck());
        if (!player_health.healthCheck())
        {
            Destroy(gameObject);
        }
    }


    public void attack()
    {
        if (player_health.healthCheck() && Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Transform SpawnBullets in projectileSpawnLocation)
            {
                Instantiate(bulletPrefab, SpawnBullets.position, transform.rotation);
            }
             // check for player collision;

        }
        else
        {
            /*
             stop
             */
        }
    }
}
