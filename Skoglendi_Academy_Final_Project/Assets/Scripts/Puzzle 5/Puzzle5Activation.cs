using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle5Activation : MonoBehaviour
{
    public GameObject creature;
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        creature.gameObject.SetActive(true);
        
    }
}
