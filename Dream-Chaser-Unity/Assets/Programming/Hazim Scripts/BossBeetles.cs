using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBeetles : MonoBehaviour
{
    public LayerMask layerMask;
    public Transform target;
    public GameObject beetlesPrefab;
    public GameObject boss;
    [SerializeField] int amount;
    [SerializeField] float spawnInterval, destroyDelay;

    ParticleSystem ps; 

    bool isDead = false;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");
        ps = transform.Find("BeetlesLoop").GetComponent<ParticleSystem>();
        timer = spawnInterval;

        RaycastHit hit;
        if(Physics.Raycast(boss.transform.position, boss.transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            if(hit.transform.tag == "Player") 
            {
                target = hit.transform;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(isDead) {return;}

        if(amount > 0)
        {
            if(timer <= 0)
            {
                SpawnBeetles();
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        else
        {
            Destroy(gameObject, destroyDelay);
            ps.Stop();
            isDead = true;
        }
    }

    void SpawnBeetles()
    {
        timer = spawnInterval;
        amount -= 1;
        var beetles = Instantiate(beetlesPrefab, transform.position, transform.rotation);
        if(target)
        {
            beetles.GetComponent<BossBeetlesBehavior>().target = target;
        }
    }
}
