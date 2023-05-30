using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private float lowHealthThreshHold;
    [SerializeField] private DCMoveVin player;
    [SerializeField] private PlayerHealth player_health;


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
    }


    public void attack()
    {
        if (player_health.healthCheck())
        {
            player_health.underAttack();
        }
        else
        {
            /*
             stop
             */
        }
    }
}
