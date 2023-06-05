using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossBeetlesBehavior : MonoBehaviour
{
    public Transform target; 
    public string[] collisionTagsToCheck;
    [SerializeField] float duration, rotationSpeed, beforeTurnSpeed, afterTurnSpeed, defaultDestinationDistance, distanceBeforeTurn, destroyDelay;

    Vector3 defaultDestination, startPosition, faceDirection, goingToPosition;
    float distance;
    Quaternion rotation;
    ParticleSystem loopFX, impactFX;

    bool hasTurned = false, isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        loopFX = transform.Find("BeetlesLoop").GetComponent<ParticleSystem>();
        impactFX = transform.Find("ImpactFX").GetComponent<ParticleSystem>();

        startPosition = transform.position;
        defaultDestination = transform.position + transform.forward * defaultDestinationDistance;

        var rot = transform.position;
        rot.y += 90;
        rot.x = Random.Range(0,360);
        transform.rotation = Quaternion.Euler(rot);
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead) {return;}

        if(hasTurned)
        {
            if(target)
            {
                faceDirection = target.position - transform.position;
                goingToPosition = target.position;
            }
            else 
            {
                faceDirection = defaultDestination - transform.position;
                goingToPosition = defaultDestination;
            }

            rotation = Quaternion.LookRotation(faceDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            transform.Translate(transform.forward * afterTurnSpeed * Time.deltaTime, Space.World);

            distance = Vector3.Distance(transform.position, goingToPosition);
            if(distance <= 0.2f) {Explode();}
        }
        else
        {
            transform.Translate(transform.forward * beforeTurnSpeed * Time.deltaTime, Space.World);

            distance = Vector3.Distance(transform.position, startPosition);
            if(distance > distanceBeforeTurn) {hasTurned = true;}
        }

        if(duration <= 0) {Explode();} else {duration -= Time.deltaTime;}
    }

    void Explode()
    {
        isDead = true;
        loopFX.Stop();
        impactFX.Play();
        Destroy(gameObject, destroyDelay);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(collisionTagsToCheck.Contains(other.tag) && !isDead)
        {
            // in the Future the player would die and you would restart from a checkpoint
            Destroy(other.gameObject);
            Explode();
        }
    }
}
