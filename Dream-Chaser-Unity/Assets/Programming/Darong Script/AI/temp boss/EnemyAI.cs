using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [Header("Player components")]
    [SerializeField] public DCMoveVin player;
    [SerializeField] public PlayerHealth player_health;

    [Header("bullet prefabs and spawn location")]
    [SerializeField] public Transform projectileSpawnLocation;
    [SerializeField] public GameObject bulletPrefab;

    [Header("checkpoint locations and checkpoint track")]
    [SerializeField] public CheckpointIndex checkpoint;
    [SerializeField] public Transform[] checkpointLocation;

    private float countDownTime = 0f;
    [SerializeField] private float firerate;

    private GameManager gameManager;

    [Header("enemy gameobject")]
    [SerializeField] GameObject enemyObject;
    private GameObject playerObject;

    void Start()
    {
        //currentHealth = startingHealth;
        /*
        player = GetComponent<DCMoveVin>();
        player_health = GetComponent<PlayerHealth>();
        checkpoint = GetComponent<CheckpointIndex>();
        meshAgent = GetComponent<NavMeshAgent>();
        */
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        playerObject = GameObject.Find("Player");
    }


    // Update is called once per frame
    void Update()
    {
        teleport();
        //transform.LookAt(playerObject.transform);
        // if player is alive, enemy attack
        enemyObject.transform.LookAt(playerObject.transform);
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

                Instantiate(bulletPrefab, projectileSpawnLocation.position, transform.rotation);
                countDownTime = 1f / firerate;
            }
            countDownTime -= Time.deltaTime;
        }
    }

    // teleport boss between checkpoints
    private void teleport()
    {
        if (checkpoint.currentCheckpoint() != gameManager.cpCount && checkpoint.totalCheckpoints > gameManager.cpCount)
        {
            StartCoroutine("attackCooldown");
            checkpoint.arriveCheckpoint();
            enemyObject.transform.position = checkpointLocation[checkpoint.currentCheckpoint()+1].position;
            enemyObject.transform.position = new Vector3(enemyObject.transform.position.x, enemyObject.transform.position.y+100, enemyObject.transform.position.z);
            Debug.Log("tp to " + checkpoint.currentCheckpoint());
        }
        
    }

    IEnumerator attackCooldown()
    {
        yield return new WaitForSecondsRealtime(1f);
    }

}
