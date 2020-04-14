using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public SimpleHealthBar healthBar;
    public static float maxPlayerHealth = 100f;
    public static float currentPlayerHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Players health: " + currentPlayerHealth);
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
