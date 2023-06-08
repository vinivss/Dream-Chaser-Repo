using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Tools.Trees.AI
{
    public class AIAgent : MonoBehaviour
    {
        [Header("enemy health start")]
        [SerializeField] public float startingHealth;
        [SerializeField] public DCMoveVin player;
        [SerializeField] public PlayerHealth player_health;

        [Header("Player components")]
        [SerializeField] public Transform[] projectileSpawnLocation;
        [SerializeField] public GameObject bulletPrefab;

        [Header("bullet prefabs and spawn location")]
        [SerializeField] public CheckpointIndex checkpoint;
        [SerializeField] public Transform[] checkpointLocation;

        [Header("NavMesh Agent")]
        [SerializeField] public NavMeshAgent meshAgent;

        // enemy current health
        public float currentHealth;

        // fire rate
        private float fireRate;
        private float countDownFire = 2;

        // checkpoint track temp
        public bool checkpoint1;
        public bool checkpoint2;
        public bool checkpoint3;

        void Start()
        {
            currentHealth = startingHealth;
            /*
            player = GetComponent<DCMoveVin>();
            player_health = GetComponent<PlayerHealth>();
            checkpoint = GetComponent<CheckpointIndex>();
            meshAgent = GetComponent<NavMeshAgent>();
            */
        }

        // Update is called once per frame
        void Update()
        {
            if (!player_health.healthCheck())
            {
                Destroy(gameObject);
            }
        }

        public float GetCurrentHealth()
        {
            return currentHealth;
        }

        public void attack()
        {
            // enemy fire
            if (player_health.healthCheck())
            {
                if (countDownFire <= 0f) {
                    foreach (Transform SpawnBullets in projectileSpawnLocation)
                    {
                        Instantiate(bulletPrefab, SpawnBullets.position, transform.rotation);
                    }
                    countDownFire = 1f / fireRate;
                }
                countDownFire -= Time.deltaTime;
            }
            else
            {
                /*
                 stop
                 */
            }
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Checkpoint")
            {
                Debug.Log("enter checkpoint");
                checkpoint1 = true;
            }
        }
    }
}
