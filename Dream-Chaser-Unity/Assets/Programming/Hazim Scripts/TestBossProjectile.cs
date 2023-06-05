using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBossProjectile : MonoBehaviour
{
    [SerializeField] GameObject BossProjectileSpawnerPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(BossProjectileSpawnerPrefab, transform.position + transform.forward, transform.rotation);
        }
    }
}
