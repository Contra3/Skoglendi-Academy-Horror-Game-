using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenEnter : MonoBehaviour
{
    public GameObject StartScreenPanel;
    public GameObject MainMenuPanel;
    private bool startScreenDisabled = false;

    // Start is called before the first frame update
    void Start()
    {

        MainMenuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKey("return") && startScreenDisabled == false)
        {
            StartScreenPanel.SetActive(false);
            MainMenuPanel.SetActive(true);
            startScreenDisabled = true;

        }
    }
}
