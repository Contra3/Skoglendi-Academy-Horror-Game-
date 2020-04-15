using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{

    private bool nearKey = false;
    private AudioSource audio;


    private void Start() {
        audio = GetComponentInChildren<AudioSource>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && nearKey == true)
        {
            Destroy(gameObject);
            UnlockDoor.haveKey = true;
            audio.Play(0);
        }

    }





    private void OnTriggerEnter(Collider other)
    {
        nearKey = true;
    }

    private void OnTriggerExit(Collider other)
    {
        nearKey = false;
    }







}
