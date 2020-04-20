using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathScreen : MonoBehaviour
{

    public GameObject deathPanel;


    // Start is called before the first frame update
    void Start()
    {
        deathPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.currentPlayerHealth <= 0)
        {
            PlayerController.haveKey = false;
            deathPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


    public void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }


}
