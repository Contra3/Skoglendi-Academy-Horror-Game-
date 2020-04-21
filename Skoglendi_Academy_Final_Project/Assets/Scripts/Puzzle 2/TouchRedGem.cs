﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchRedGem : MonoBehaviour
{

    [Tooltip("Place interact key gameobject here")]
    public GameObject interactKey;

    [Tooltip("Place Animation Holder here")]
    public GameObject angelStatue;

    private bool nearRedGem = false;
    public static bool puzzle1RedGemTrigger = false;
    private AudioSource audio;

    private void Start()
    {
        interactKey.gameObject.SetActive(false);
        angelStatue.SetActive(false);
        audio = GetComponentInChildren<AudioSource>();
    }

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.E) && nearRedGem == true)
        {
            angelStatue.SetActive(true);
            puzzle1RedGemTrigger = true;
            audio.Play(0);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactKey.gameObject.SetActive(true);
            nearRedGem = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactKey.gameObject.SetActive(false);
            nearRedGem = false;
        }
    }
}
