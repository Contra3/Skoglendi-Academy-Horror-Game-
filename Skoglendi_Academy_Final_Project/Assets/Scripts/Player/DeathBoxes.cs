using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBoxes : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController.currentPlayerHealth = 0;
        }
    }
}
