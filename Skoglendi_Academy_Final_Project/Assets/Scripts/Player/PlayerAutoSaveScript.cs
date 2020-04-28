using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoSaveScript : MonoBehaviour
{

    // Puzzle booleans that indicate what puzzles the player has done
    private int PuzzleOneDone_AutoSave;
    private int PuzzleTwoDone_AutoSave;
    private int PuzzleThreeDone_AutoSave;
    private int PuzzleFourDone_AutoSave;
    private int PuzzleFiveDone_AutoSave;
    private int PuzzleSixDone_AutoSave;
    private int PuzzleSevenDone_AutoSave;

    // Puzzle booleans that indicate what keys the player has attained
    private int PuzzleKey1_AutoSave;
    private int PuzzleKey2_AutoSave;
    private int PuzzleKey3_AutoSave;
    private int PuzzleKey4_AutoSave;
    private int PuzzleKey5_AutoSave;
    private int PuzzleKey6_AutoSave;

    // Player default stats
    private float PlayerMaxStamina_AutoSave;
    private float PlayerMaxHealth_AutoSave;

    // Default player saved location
    public int PlayerSaveLocation_AutoSave = 0;

    //Test
    public int TestData;

    // Update is called once per frame
    void Update()
    {

    }

    public void TriggerAutoSaveFeature()
    {
        if (PlayerSaveScript.PuzzleOneDone   == true) { PuzzleOneDone_AutoSave = 1;   } else { PuzzleOneDone_AutoSave = 0; }
        if (PlayerSaveScript.PuzzleTwoDone   == true) { PuzzleTwoDone_AutoSave = 1;   } else { PuzzleTwoDone_AutoSave = 0; }
        if (PlayerSaveScript.PuzzleThreeDone == true) { PuzzleThreeDone_AutoSave = 1; } else { PuzzleThreeDone_AutoSave = 0; }
        if (PlayerSaveScript.PuzzleFourDone  == true) { PuzzleFourDone_AutoSave = 1;  } else { PuzzleFourDone_AutoSave = 0; }
        if (PlayerSaveScript.PuzzleFiveDone  == true) { PuzzleFiveDone_AutoSave = 1;  } else { PuzzleFiveDone_AutoSave = 0; }
        if (PlayerSaveScript.PuzzleSixDone   == true) { PuzzleSixDone_AutoSave = 1;   } else { PuzzleSixDone_AutoSave = 0; }
        if (PlayerSaveScript.PuzzleSevenDone == true) { PuzzleSevenDone_AutoSave = 1; } else { PuzzleSevenDone_AutoSave = 0; }

        if (PlayerSaveScript.PuzzleKey1 == true) { PuzzleKey1_AutoSave = 1; } else { PuzzleKey1_AutoSave = 0; }
        if (PlayerSaveScript.PuzzleKey2 == true) { PuzzleKey2_AutoSave = 1; } else { PuzzleKey2_AutoSave = 0; }
        if (PlayerSaveScript.PuzzleKey3 == true) { PuzzleKey3_AutoSave = 1; } else { PuzzleKey3_AutoSave = 0; }
        if (PlayerSaveScript.PuzzleKey4 == true) { PuzzleKey4_AutoSave = 1; } else { PuzzleKey4_AutoSave = 0; }
        if (PlayerSaveScript.PuzzleKey5 == true) { PuzzleKey5_AutoSave = 1; } else { PuzzleKey5_AutoSave = 0; }
        if (PlayerSaveScript.PuzzleKey6 == true) { PuzzleKey6_AutoSave = 1; } else { PuzzleKey6_AutoSave = 0; }

        // Save which puzzles the player has done
        PlayerPrefs.SetInt("PuzzleOneDone_AutoSave", PuzzleOneDone_AutoSave);
        PlayerPrefs.SetInt("PuzzleTwoDone_AutoSave", PuzzleTwoDone_AutoSave);
        PlayerPrefs.SetInt("PuzzleThreeDone_AutoSave", PuzzleThreeDone_AutoSave);
        PlayerPrefs.SetInt("PuzzleFourDone_AutoSave", PuzzleFourDone_AutoSave);
        PlayerPrefs.SetInt("PuzzleFiveDone_AutoSave", PuzzleFiveDone_AutoSave);
        PlayerPrefs.SetInt("PuzzleSixDone_AutoSave", PuzzleSixDone_AutoSave);
        PlayerPrefs.SetInt("PuzzleSevenDone_AutoSave", PuzzleSevenDone_AutoSave);

        // Save the keys the player has gotten
        PlayerPrefs.SetInt("PuzzleKey1_AutoSave", PuzzleKey1_AutoSave);
        PlayerPrefs.SetInt("PuzzleKey2_AutoSave", PuzzleKey2_AutoSave);
        PlayerPrefs.SetInt("PuzzleKey3_AutoSave", PuzzleKey3_AutoSave);
        PlayerPrefs.SetInt("PuzzleKey4_AutoSave", PuzzleKey4_AutoSave);
        PlayerPrefs.SetInt("PuzzleKey5_AutoSave", PuzzleKey5_AutoSave);

        // Save their current stats
        PlayerPrefs.SetFloat("PlayerMaxStamina_AutoSave", PlayerSaveScript.PlayerMaxStamina);
        PlayerPrefs.SetFloat("PlayerMaxHealth_AutoSave", PlayerSaveScript.PlayerMaxStamina);

        // Save their current location
        PlayerPrefs.SetInt("PlayerSaveLocation_AutoSave", PlayerSaveScript.PlayerSaveLocation);
    }



}
