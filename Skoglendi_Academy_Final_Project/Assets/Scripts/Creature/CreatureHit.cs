using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureHit : MonoBehaviour
{
    public AudioSource gameSound;
    public PlayerController player;

    // Update is called once per frame
    void LateUpdate()
    {
        gameSound.Play();
        player.PlayerTakeDamage(15, 100);
    }
}
