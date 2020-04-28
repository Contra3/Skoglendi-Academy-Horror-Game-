using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaScroll : MonoBehaviour 
{
    protected bool nearItem = false;
    protected AudioSource audio;
    public Text notification;
    private void Start() {
        audio = GetComponentInChildren<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        nearItem = true;
    }

    private void OnTriggerExit(Collider other)
    {
        nearItem = false;
    }
    public float increaseStamina;
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && nearItem == true)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            PlayerController.maxStamina += increaseStamina;
            notification.text = "Maximum stamina increased";
            notification.gameObject.SetActive(true);
            audio.Play(0);

            StartCoroutine(waiter());
        }

    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(5);
        notification.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}