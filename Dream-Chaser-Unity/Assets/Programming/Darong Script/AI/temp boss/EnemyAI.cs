using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("enemy health start")]
    [SerializeField] public float startingHealth;
    [SerializeField] public int currentHealth;

    [Header("Player components")]
    [SerializeField] public DCMoveVin player;
    [SerializeField] public PlayerHealth player_health;

    [Header("bullet prefabs and spawn location")]
    [SerializeField] public Transform[] projectileSpawnLocation;
    [SerializeField] public GameObject bulletPrefab;

    [Header("checkpoint locations and checkpoint track")]
    [SerializeField] public CheckpointIndex checkpoint;
    [SerializeField] public Transform[] checkpointLocation;

    private float countDownTime = 0f;
    [SerializeField] private float firerate;

    void Start()
    {
        //currentHealth = startingHealth;
        /*
        player = GetComponent<DCMoveVin>();
        player_health = GetComponent<PlayerHealth>();
        checkpoint = GetComponent<CheckpointIndex>();
        meshAgent = GetComponent<NavMeshAgent>();
        */
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // if player is alive, enemy attack
        if (player_health.healthCheck())
        {
            attack();
        }
        
    }


    public void attack()
    {
        if (player_health.healthCheck())
        {
            if (countDownTime <= 0f) {

                Instantiate(bulletPrefab, projectileSpawnLocation[0].position, transform.rotation);

                countDownTime = 1f / firerate;
            }
            countDownTime -= Time.deltaTime;
        }
    }

    // teleport boss between checkpoints
    private void teleport()
    {

    }

}
