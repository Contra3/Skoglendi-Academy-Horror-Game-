using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaScroll : MonoBehaviour 
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
    public float increaseStamina;
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && nearItem == true)
        {
            Destroy(gameObject);
            PlayerController.maxStamina += increaseStamina;
            audio.Play(0);
        }

    }
}