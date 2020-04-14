using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureHit : MonoBehaviour
{
    public AudioSource gameSound;

    // Update is called once per frame
    void Update()
    {
        gameSound.Play();
    }
}
