using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoadScript : MonoBehaviour
{
    [SerializeField] List<Transform> SaveLocations = new List<Transform>();
    public GameObject PlayerCharacterLocation;

    // Start is called before the first frame update
    void Start()
    {
        if(MenuScript.LoadGame == true || DeathScreen.PlayerDied == true ) { 
            // Load puzzle done if it was saved
            if (PlayerPrefs.GetInt("PuzzleOneDone_AutoSave")   == 1) { PlayerSaveScript.PuzzleOneDone = true; } else { PlayerSaveScript.PuzzleOneDone = false; }
            if (PlayerPrefs.GetInt("PuzzleTwoDone_AutoSave")   == 1) { PlayerSaveScript.PuzzleTwoDone = true; } else { PlayerSaveScript.PuzzleTwoDone = false; }
            if (PlayerPrefs.GetInt("PuzzleThreeDone_AutoSave") == 1) { PlayerSaveScript.PuzzleThreeDone = true; } else { PlayerSaveScript.PuzzleThreeDone = false; }
            if (PlayerPrefs.GetInt("PuzzleFourDone_AutoSave")  == 1) { PlayerSaveScript.PuzzleFourDone = true; } else { PlayerSaveScript.PuzzleFourDone = false; }
            if (PlayerPrefs.GetInt("PuzzleFiveDone_AutoSave")  == 1) { PlayerSaveScript.PuzzleFiveDone = true; } else { PlayerSaveScript.PuzzleFiveDone = false; }
            if (PlayerPrefs.GetInt("PuzzleSixDone_AutoSave")   == 1) { PlayerSaveScript.PuzzleSixDone = true; } else { PlayerSaveScript.PuzzleSixDone   = false; }

            // Load keys if it was saved
            if (PlayerPrefs.GetInt("PuzzleKey1_AutoSave") == 1) { PlayerSaveScript.PuzzleKey1 = true; } else { PlayerSaveScript.PuzzleKey1 = false; }
            if (PlayerPrefs.GetInt("PuzzleKey2_AutoSave") == 1) { PlayerSaveScript.PuzzleKey2 = true; } else { PlayerSaveScript.PuzzleKey2 = false; }
            if (PlayerPrefs.GetInt("PuzzleKey3_AutoSave") == 1) { PlayerSaveScript.PuzzleKey3 = true; } else { PlayerSaveScript.PuzzleKey3 = false; }
            if (PlayerPrefs.GetInt("PuzzleKey4_AutoSave") == 1) { PlayerSaveScript.PuzzleKey4 = true; } else { PlayerSaveScript.PuzzleKey4 = false; }
            if (PlayerPrefs.GetInt("PuzzleKey5_AutoSave") == 1) { PlayerSaveScript.PuzzleKey5 = true; } else { PlayerSaveScript.PuzzleKey5 = false; }

            // Load Starting Location
            if (PlayerPrefs.GetInt("PlayerSaveLocation_AutoSave") == 0)
            {
                PlayerCharacterLocation.SetActive(false);
                PlayerCharacterLocation.transform.position = SaveLocations[0].position;
                PlayerCharacterLocation.SetActive(true);
            }

            // Load After Solving Puzzle 1 Location
            if (PlayerPrefs.GetInt("PlayerSaveLocation_AutoSave") == 1)
            {
                PlayerCharacterLocation.SetActive(false);
                PlayerCharacterLocation.transform.position = SaveLocations[1].position;
                PlayerCharacterLocation.SetActive(true);
            }

            // Load after pressing red gem and before solving Puzzle 2 location
            if (PlayerPrefs.GetInt("PlayerSaveLocation_AutoSave") == 2)
            {
                PlayerCharacterLocation.SetActive(false);
                PlayerCharacterLocation.transform.position = SaveLocations[2].position;
                PlayerCharacterLocation.SetActive(true);
            }

            // Load after solving Puzzle 2 getting into green room
            if (PlayerPrefs.GetInt("PlayerSaveLocation_AutoSave") == 3)
            {
                PlayerCharacterLocation.SetActive(false);
                PlayerCharacterLocation.transform.position = SaveLocations[3].position;
                PlayerCharacterLocation.SetActive(true);
            }

            // Load after solving Puzzle 2 getting into green room
            if (PlayerPrefs.GetInt("PlayerSaveLocation_AutoSave") == 4)
            {
                PlayerCharacterLocation.SetActive(false);
                PlayerCharacterLocation.transform.position = SaveLocations[4].position;
                PlayerCharacterLocation.SetActive(true);
            }




            DeathScreen.PlayerDied = false;
        }
        // If it's not loading then it's a new game. Reset everything back to its default.
        else if(MenuScript.LoadGame == false)
        {
            // Puzzle booleans that indicate what puzzles the player has completed
            PlayerSaveScript.PuzzleOneDone = false;
            PlayerSaveScript.PuzzleTwoDone = false;
            PlayerSaveScript.PuzzleThreeDone = false;
            PlayerSaveScript.PuzzleFourDone = false;
            PlayerSaveScript.PuzzleFiveDone = false;
            PlayerSaveScript.PuzzleSixDone = false;
            PlayerSaveScript.PuzzleSevenDone = false;

            // Puzzle booleans that indicate what keys the player has attained a puzzle key
            PlayerSaveScript.PuzzleKey1 = false;
            PlayerSaveScript.PuzzleKey2 = false;
            PlayerSaveScript.PuzzleKey3 = false;
            PlayerSaveScript.PuzzleKey4 = false;
            PlayerSaveScript.PuzzleKey5 = false;

            // Player default stats
            PlayerSaveScript.PlayerMaxStamina = 100f;
            PlayerSaveScript.PlayerMaxHealth = 100f;

            // Default player saved location
            PlayerSaveScript.PlayerSaveLocation = 0;
}


    }

    // Update is called once per frame
    void Update()
    {

    }
}
