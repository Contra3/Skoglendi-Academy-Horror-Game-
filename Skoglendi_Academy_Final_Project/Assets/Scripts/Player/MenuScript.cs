using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{

    public static bool LoadGame = false;
    public GameObject LoadButton;
    public int SavedGameExists = 10;



    // Start is called before the first frame update
    void Start()
    {
        LoadButton.SetActive(false);
        SavedGameExists = PlayerPrefs.GetInt("PuzzleOneDone_AutoSave", -1);
        MenuButton();
    }

   void MenuButton()
    {
        if(SavedGameExists > -1)
        {
            LoadButton.SetActive(true);
        }
    }

    public void LoadGameData()
    {
        LoadGame = true;
    }

    public void NewGameData()
    {
        LoadGame = false;
        PlayerPrefs.DeleteAll();
    }





}
