using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUpScroll : MonoBehaviour
{

    protected bool nearItem = false;
    protected AudioSource audio;

    private void Start() {
        audio = GetComponentInChildren<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        nearItem = true;
    }

    private void OnTriggerExit(Collider other)
    {
        nearItem = false;
    }
}
