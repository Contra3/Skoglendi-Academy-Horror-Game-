using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public SimpleHealthBar healthBar;
    public static float maxPlayerHealth = 100f;
    public static float currentPlayerHealth = 100f;

    // First puzzle of game
    public static bool haveKey = false;


    // For the last puzzle of the game
    public static bool hasMasterKey = false;


    // Start is called before the first frame update
    void Start()
    {
        PlayerController.currentPlayerHealth = 100;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Players health: " + currentPlayerHealth);

        if (Input.GetKeyDown(KeyCode.G))
        {
            currentPlayerHealth = 0;
        }



    }

    public void PlayerTakeDamage(float damage, float maxHealth)
    {
        // The damage that will player take. Can later be recovered using Health Scrolls
        currentPlayerHealth -= damage;

        // The health cap for player when taken hard hits that will no longer recover the lost health.
        maxPlayerHealth = maxHealth;

        healthBar.UpdateBar(currentPlayerHealth, maxPlayerHealth);
    }


}
