using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{

    private bool nearKey = false;


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && nearKey == true)
        {
            Destroy(gameObject);
            PlayerController.haveKey = true;
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
