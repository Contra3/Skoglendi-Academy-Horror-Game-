using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{

    private bool nearKey = false;
    private AudioSource audio;
    public int keyID;

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
