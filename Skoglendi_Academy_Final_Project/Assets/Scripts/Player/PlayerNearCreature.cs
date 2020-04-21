using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNearCreature : MonoBehaviour
{
    public static bool playerNearMeleeRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CreatureMeleeRange"))
        {
            playerNearMeleeRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerNearMeleeRange = false;
    }
}
