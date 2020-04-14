using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 5.0f;
    public GameObject chaseMusic;
    AudioSource theChaseMusic;
    private bool chaseMusicPlaying = false;
    private bool creatureAttack = true;


    // target
    PlayerController MainPlayer;
    Transform target;
    NavMeshAgent agent;
    Animator anim;

    // Creature sounds
    public AudioSource creatureAttack_1;
    public AudioSource creatureGrowl_1;

    // Start is called before the first frame update
    void Start()
    {
        theChaseMusic = chaseMusic.GetComponent<AudioSource>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float playerDistance = Vector3.Distance(target.position, transform.position);

        // If player is within the lookRadius then chase
        if (playerDistance <= lookRadius)
        {
            if(chaseMusicPlaying == false)
            {
                theChaseMusic.Play();
                chaseMusicPlaying = true;
            }
            
            lookRadius = 10000.0f;

            // If player is within melee range of creature then creature will attack
            if(PlayerNearCreature.playerNearCreature == true)
            {
                anim.SetInteger("creatureRun", 2);
                anim.SetInteger("moving", 4);
                    
            }
            else
            {
                anim.SetInteger("moving", 0);
                anim.SetInteger("battle", 1);
                anim.SetInteger("creatureRun", 1);
                agent.speed = 10;
                agent.SetDestination(target.position);
            }

        }
    }

    // draw the look radius within the editor to get an idea of it
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    IEnumerator CreatureAttackWait() // Adding a pause to the script
    {
        yield return new WaitForSeconds(1.5f);
        creatureAttack = true;
    }








}// end of EnemyController class

