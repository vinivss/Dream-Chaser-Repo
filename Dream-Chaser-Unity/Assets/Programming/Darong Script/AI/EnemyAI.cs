using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] public float startingHealth;
    [SerializeField] public float lowHealthThreshHold;
    [SerializeField] public DCMoveVin player;
    [SerializeField] public PlayerHealth player_health;

    [SerializeField] public Transform[] projectileSpawnLocation;
    [SerializeField] public GameObject bulletPrefab;

    [SerializeField] public CheckpointIndex checkpoint;
    [SerializeField] public Transform[] checkpointLocation;

    public float currentHealth;

    void Start()
    {
        currentHealth = startingHealth;
        player = GetComponent<DCMoveVin>();
        checkpoint = GetComponent<CheckpointIndex>();
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
