using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBossProjectile : MonoBehaviour
{
    [SerializeField] GameObject BossProjectileSpawnerPrefab;

    private Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(BossProjectileSpawnerPrefab, cam.position + cam.forward, cam.rotation);
        }
    }
}
