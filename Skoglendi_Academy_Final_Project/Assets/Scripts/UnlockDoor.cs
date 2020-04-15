using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockDoor : MonoBehaviour
{

    public static bool haveKey = false;
    private bool nearDoor = false;
    public Text DoorNotification;
    public GameObject DoorOne;
    public GameObject DoorTwo;
    private Rigidbody DoorOneRigid;
    private Rigidbody DoorTwoRigid;

    private void Start()
    {
        DoorNotification.gameObject.SetActive(false);

        DoorOneRigid = DoorOne.GetComponent<Rigidbody>();
        DoorTwoRigid = DoorTwo.GetComponent<Rigidbody>();

        DoorOneRigid.isKinematic = true;
        DoorTwoRigid.isKinematic = true;

    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {

            if(haveKey == false && nearDoor == true)
            {
                DoorNotification.gameObject.SetActive(true);
                DoorNotification.text = "Door Locked";
            }
            else if (haveKey == false && nearDoor == true)
            {
                DoorNotification.text = "Unlocked";
                DoorNotification.gameObject.SetActive(true);
                DoorOneRigid.isKinematic = false;
                DoorTwoRigid.isKinematic = false;
            }

        }

        // Cheat to get the key
        if (Input.GetKeyDown(KeyCode.P))
        {
            haveKey = true;
        }


    }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player near door");
        if (other.gameObject.CompareTag("Player"))
        {
            nearDoor = true;
        }

    }


    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player no longer near door");
        if (other.gameObject.CompareTag("Player"))
        {
            DoorNotification.gameObject.SetActive(false);
            nearDoor = false;
        }

    }

}
