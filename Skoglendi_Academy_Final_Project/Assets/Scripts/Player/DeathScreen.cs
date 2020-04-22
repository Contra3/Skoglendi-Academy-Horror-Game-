using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathScreen : MonoBehaviour
{

    public GameObject deathPanel;
    public GameObject playerCharacter;
    public GameObject MainUICamera;
    public static bool PlayerDied = false;

    // Start is called before the first frame update
    void Start()
    {
        deathPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.currentPlayerHealth <= 0)
        {
            playerCharacter.SetActive(false);
            MainUICamera.SetActive(true);
            deathPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


    public void ReloadLevel()
    {
        PlayerDied = true;
        SceneManager.LoadScene(1);
    }


    public void QuitGameDeathScreen()
    {
        Application.Quit();
    }

}
