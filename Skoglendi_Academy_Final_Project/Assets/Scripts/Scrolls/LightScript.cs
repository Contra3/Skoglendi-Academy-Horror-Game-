using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightScript : MonoBehaviour 
{
    protected bool nearItem = false;
    protected AudioSource audio;
    private bool gotScroll = false;
    public Text notification;

    private void Start()
    {
        audio = GetComponentInChildren<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        nearItem = true;
    }

    private void OnTriggerExit(Collider other)
    {
        nearItem = false;
        notification.gameObject.SetActive(false);
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && nearItem == true)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            PlayerController.abilities["ILLUMINATE"] = true;
            notification.text = "You found the illumination scroll. Press 'Q' to brighten the area.";
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
