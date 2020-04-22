using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{

    private bool nearKey = false;
    private AudioSource audio;
    public int keyID;

    [Tooltip("Add the PlayerAutoSaveScript that is attached to the MainCharacter")]
    public PlayerAutoSaveScript autoSave_Key;


    private void Start() {
        audio = GetComponentInChildren<AudioSource>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && nearKey == true)
        {
            Destroy(gameObject);

            if(keyID == 1)
            {
                PlayerSaveScript.PuzzleKey1 = true;
                PlayerSaveScript.PlayerSaveLocation = 0;
            }
            else if (keyID == 2)
            {
                PlayerSaveScript.PuzzleKey2 = true;
            }
            else if (keyID == 3)
            {
                PlayerSaveScript.PuzzleKey3 = true;
            }
            else if (keyID == 4)
            {
                PlayerSaveScript.PuzzleKey4 = true;
            }
            else if (keyID == 5)
            {
                PlayerSaveScript.PuzzleKey5 = true;
            }

            autoSave_Key.TriggerAutoSaveFeature();
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
