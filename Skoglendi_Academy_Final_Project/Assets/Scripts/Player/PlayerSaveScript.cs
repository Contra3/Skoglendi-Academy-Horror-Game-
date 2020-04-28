using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveScript : MonoBehaviour
{

    // Puzzle booleans that indicate what puzzles the player has completed
    public static bool PuzzleOneDone = false;
    public static bool PuzzleTwoDone = false;
    public static bool PuzzleThreeDone = false;
    public static bool PuzzleFourDone = false;
    public static bool PuzzleFiveDone = false;
    public static bool PuzzleSixDone = false;
    public static bool PuzzleSevenDone = false;

    // Puzzle booleans that indicate what keys the player has attained a puzzle key
    public static bool PuzzleKey1 = false;
    public static bool PuzzleKey2 = false;
    public static bool PuzzleKey3 = false;
    public static bool PuzzleKey4 = false;
    public static bool PuzzleKey5 = false;
    public static bool PuzzleKey6 = false;

    // Player default stats
    public static float PlayerMaxStamina = 100f;
    public static float PlayerMaxHealth  = 100f;

    // Default player saved location
    public static int PlayerSaveLocation = 0;

}
