using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNearCreature : MonoBehaviour
{
    public static bool playerNearCreature = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CreatureMeleeRange"))
        {
            playerNearCreature = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CreatureMeleeRange"))
        {
            playerNearCreature = false;
        }
    }
}
