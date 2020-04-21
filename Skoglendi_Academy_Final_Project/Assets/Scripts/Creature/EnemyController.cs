using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius;
    public GameObject chaseMusic;
    static AudioSource theChaseMusic;
    private bool chaseMusicPlaying = false;
    private bool creatureAttack = true;
    public static bool playerNearCreature = false;

    // target
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
        agent.updateRotation = false; // For faster turning
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void LateUpdate()
    {

        //Faster turning of creature
        if (agent.velocity.sqrMagnitude > Mathf.Epsilon)
        {
            transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
        }

        float playerDistance = Vector3.Distance(target.position, transform.position);

        // If player is within the lookRadius then chase
        if (playerDistance <= lookRadius)
        {
            if(chaseMusicPlaying == false)
            {
                StartCoroutine(FadeIn(theChaseMusic, 1.0f));
                chaseMusicPlaying = true;
            }
            
            //lookRadius = 15f;

            // If player is within melee range of creature then creature will attack
            if(PlayerNearCreature.playerNearMeleeRange == true)
            {
                anim.SetInteger("creatureRun", 2);
                anim.SetInteger("moving", 4);         
            }
            else
            {
                anim.SetInteger("moving", 0);
                anim.SetInteger("battle", 1);
                anim.SetInteger("creatureRun", 1);
                agent.speed = 10f;
                agent.SetDestination(target.position);
            }
        }
        else if (chaseMusicPlaying == true || playerDistance > lookRadius)
        {
            anim.SetInteger("creatureRun", 2);
            anim.SetInteger("battle", 0);
            anim.SetInteger("moving", 1);
            agent.speed = 2.5f;
            StartCoroutine(FadeOut(theChaseMusic, 1.0f));
            chaseMusicPlaying = false;
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

    IEnumerator FadeOut(AudioSource audioSource, float fadeTime)
    {
        float initialVolume = theChaseMusic.volume;

        while (theChaseMusic.volume > 0)
        {
            theChaseMusic.volume -= initialVolume * Time.deltaTime / fadeTime;
        }

        theChaseMusic.Stop();
        yield return null;
    }

    IEnumerator FadeIn(AudioSource audioSource, float fadeTime)
    {
        audioSource.Play();
        audioSource.volume = 0f;

        while (audioSource.volume < 1)
        {
            audioSource.volume += Time.deltaTime / fadeTime;

            yield return null;
        }
    }

}// end of EnemyController class

