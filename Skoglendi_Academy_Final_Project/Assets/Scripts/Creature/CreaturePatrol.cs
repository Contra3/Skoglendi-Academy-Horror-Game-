using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreaturePatrol : MonoBehaviour
{

    private Animator anim;
    private NavMeshAgent NPC;
    private int NPCWait = 0;

    // Deals with waypoints
    [SerializeField] List<GameObject> WayPoints = new List<GameObject>();
    public int waypointTarget;
    public string waypointName;
    public string waypointDesc;
    public Transform waypointLocation;
    public int lastWaypoint;
    public bool Contact;
    public int WayPointCount;


    void Start()
    {
        WayPointCount = WayPoints.Count;
        waypointTarget = Random.Range(0, WayPointCount);
        waypointLocation = WayPoints[waypointTarget].transform;
        MoveToWaypoint();
        anim = GetComponentInParent<Animator>();
        lastWaypoint = waypointTarget;
        anim.SetInteger("moving", 1);
    }

    // When the npc enters the trigger it will count the CurrentTarget that will choose a targetCube linearly
    public void OnTriggerEnter(Collider other)
    {

        Debug.Log("Trigger activated");

        if (other.gameObject.CompareTag("Target")) // Searches for tag
        {
            // Grabs the name of the current collider
            waypointName = other.GetComponent<Collider>().name;

            // Compares the name of the current collider to the name of the current target that the npc is going to
            if (waypointName == waypointDesc)
            {
                if (Contact == false)
                {
                    Contact = true;
                    waypointTarget = Random.Range(0, WayPointCount);

                    if (waypointTarget == lastWaypoint) // We want to change the CurrentTarget to a different number that is not the same as the LastTarget, so the npc character does not get stuck on a waypoint
                    {
                        PickAnotherWayPoint();
                    }
                    else
                    {
                        Contact = false;
                        MoveToWaypoint();
                    }

                }
            }

        }
    }

    void PickAnotherWayPoint()
    {
        if (lastWaypoint == 0)
        {
            waypointTarget = lastWaypoint + 1;
        }
        else if (lastWaypoint > 0)
        {
            waypointTarget = lastWaypoint - 1;
        }

        Contact = false;
        MoveToWaypoint();
    }



    void MoveToWaypoint()
    {
        waypointLocation = WayPoints[waypointTarget].transform; // Where the target is at
        waypointDesc = WayPoints[waypointTarget].name.ToString(); // The name of the target
        GetComponentInParent<NavMeshAgent>().destination = waypointLocation.position; // Move to the target position
        lastWaypoint = waypointTarget;

    }

}