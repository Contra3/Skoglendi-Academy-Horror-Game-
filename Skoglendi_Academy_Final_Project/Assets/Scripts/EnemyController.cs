using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 5.0f;

    // target
    Transform target;
    NavMeshAgent agent;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(target.position, transform.position);

        if (dist <= lookRadius)
        {
            lookRadius = 10000.0f;
            anim.SetInteger("moving", 0);
            anim.SetInteger("battle", 1);
            anim.SetInteger("creatureRun", 1);
            agent.speed = 10;
            agent.SetDestination(target.position);
        }
    }

    // draw the look radius within the editor to get an idea of it
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}

