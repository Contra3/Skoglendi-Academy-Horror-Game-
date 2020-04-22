using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockDoor : MonoBehaviour
{

    // Puzzle ID is set in the inspector
    public int PuzzleDoorID;
    private bool nearDoor = false;

    private bool hasKey;

    public Text DoorNotification;
    public bool isDoubleDoor;
    public GameObject DoorOne;
    public GameObject DoorTwo;
    private Rigidbody DoorOneRigid;
    private Rigidbody DoorTwoRigid;
    public PlayerAutoSaveScript autoSave;

    private void Start()
    {
        DoorNotification.gameObject.SetActive(false);

        DoorOneRigid = DoorOne.GetComponent<Rigidbody>();

        if(isDoubleDoor == true)
        {
            DoorTwoRigid = DoorTwo.GetComponent<Rigidbody>();
            DoorTwoRigid.isKinematic = true;
        }
        
        DoorOneRigid.isKinematic = true;

    }


    private void Update()
    {

        if (hasKey == false && nearDoor == true)
        {
            DoorNotification.gameObject.SetActive(true);
            DoorNotification.text = "Door is locked, there must be a key around here.";
        }

        if (Input.GetKeyDown(KeyCode.E))
        {

           if (hasKey == true && nearDoor == true)
            {
                DoorNotification.text = "Unlocked";
                DoorNotification.gameObject.SetActive(true);
                DoorOneRigid.isKinematic = false;

                if(isDoubleDoor == true)
                {
                    DoorTwoRigid.isKinematic = false;
                }

                if (PuzzleDoorID == 1) { PlayerSaveScript.PuzzleOneDone = true; PlayerSaveScript.PlayerSaveLocation = 1; }
                if (PuzzleDoorID == 2) { PlayerSaveScript.PuzzleTwoDone = true; PlayerSaveScript.PlayerSaveLocation = 3; }
                if (PuzzleDoorID == 3) { PlayerSaveScript.PuzzleThreeDone = true; }
                if (PuzzleDoorID == 4) { PlayerSaveScript.PuzzleFourDone = true; }
                if (PuzzleDoorID == 5) { PlayerSaveScript.PuzzleFiveDone = true; }

                autoSave.TriggerAutoSaveFeature();

            }

        }

        // Cheat to get the key
        if (Input.GetKeyDown(KeyCode.P))
        {
            hasKey = true;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Player near door");
        if (other.gameObject.CompareTag("Player"))
        {
            nearDoor = true;


            if (PuzzleDoorID == 1)
            {
                if (PlayerSaveScript.PuzzleKey1)
                {
                    hasKey = true;
                }
            }
            if (PuzzleDoorID == 2)
            {
                if (PlayerSaveScript.PuzzleKey2)
                {
                    hasKey = true;
                }
            }
            if (PuzzleDoorID == 3)
            {
                if (PlayerSaveScript.PuzzleKey3)
                {
                    hasKey = true;
                }
            }
            if (PuzzleDoorID == 4)
            {
                if (PlayerSaveScript.PuzzleKey4)
                {
                    hasKey = true;
                }
            }
            if (PuzzleDoorID == 5)
            {
                if (PlayerSaveScript.PuzzleKey5)
                {
                    hasKey = true;
                }
            }

        }

    }


    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Player no longer near door");
        if (other.gameObject.CompareTag("Player"))
        {
            DoorNotification.gameObject.SetActive(false);
            nearDoor = false;
        }

    }

}
