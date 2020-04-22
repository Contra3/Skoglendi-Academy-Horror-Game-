using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject JournalPanel;
    public GameObject SettingsPanel;
    public GameObject MainCharacter;
    public GameObject MenuCamera;
    public GameObject CreditsPanel;

    private bool isPausePanelEnabled = false;
    private int secondaryMenuTriggered = 0;

    // Start is called before the first frame update
    void Start()
    {
        PausePanel.SetActive(false);
        JournalPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        MenuCamera.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            // Show Pause screen
            if (isPausePanelEnabled == false)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;


                PausePanel.SetActive(true);
                MainCharacter.SetActive(false);
                MenuCamera.SetActive(true);

                Time.timeScale = 0f;
                isPausePanelEnabled = true;
                
            }
            // Hide Pause screen
            else if (isPausePanelEnabled == true && secondaryMenuTriggered == 0)
            {

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                PausePanel.SetActive(false);
                MenuCamera.SetActive(false);
                MainCharacter.SetActive(true);

                isPausePanelEnabled = false;
                Time.timeScale = 1f;
            }
            // Hide Journal
            else if (secondaryMenuTriggered == 1)
            {
                JournalPanel.SetActive(false);
                PausePanel.SetActive(true);
                secondaryMenuTriggered = 0;
            }
            // Hide Settings
            else if (secondaryMenuTriggered == 2)
            {
                SettingsPanel.SetActive(false);
                PausePanel.SetActive(true);
                secondaryMenuTriggered = 0;
            }
            //Hide Credits
            else if (secondaryMenuTriggered == 3)
            {
                CreditsPanel.SetActive(false);
                PausePanel.SetActive(true);
                secondaryMenuTriggered = 0;
            }

        }
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        PausePanel.SetActive(false);
        MenuCamera.SetActive(false);
        MainCharacter.SetActive(true);
       
        isPausePanelEnabled = false;
        Time.timeScale = 1f;
    }
    public void ShowJournal()
    {
        secondaryMenuTriggered = 1;
        PausePanel.SetActive(false);
        JournalPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }

    public void ShowSettings()
    {
        secondaryMenuTriggered = 2;
        PausePanel.SetActive(false);
        JournalPanel.SetActive(false);
        SettingsPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }

    public void ShowCredits()
    {
        secondaryMenuTriggered = 3;
        PausePanel.SetActive(false);
        CreditsPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        JournalPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
