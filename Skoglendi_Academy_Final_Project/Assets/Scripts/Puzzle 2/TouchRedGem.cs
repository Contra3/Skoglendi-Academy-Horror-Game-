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

    private void Start()
    {
        interactKey.gameObject.SetActive(false);
        angelStatue.SetActive(false);
    }

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.E) && nearRedGem == true)
        {
            angelStatue.SetActive(true);
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