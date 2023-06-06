using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Tools.Trees.AI
{
    public class AIAgent : MonoBehaviour
    {
        [SerializeField] public float startingHealth;
        [SerializeField] public float lowHealthThreshHold;
        [SerializeField] public DCMoveVin player;
        [SerializeField] public PlayerHealth player_health;

        [SerializeField] public Transform[] projectileSpawnLocation;
        [SerializeField] public GameObject bulletPrefab;

        [SerializeField] public CheckpointIndex checkpoint;
        [SerializeField] public Transform[] checkpointLocation;

        [SerializeField] public NavMeshAgent meshAgent;

        public float currentHealth;

        private float fireRate;
        private float countDownFire = 2;

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
    }
}
