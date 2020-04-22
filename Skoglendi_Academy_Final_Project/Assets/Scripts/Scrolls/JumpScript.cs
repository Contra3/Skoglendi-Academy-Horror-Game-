using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpScript : MonoBehaviour 
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
        notification.gameObject.SetActive(false);
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && nearItem == true)
        {
            gameObject.SetActive(false);
            PlayerController.abilities["JUMP"] = true;
            notification.text = "You found the super jump scroll. Press 'R' to aim and L Mouse to jump";
            notification.gameObject.SetActive(true);
            audio.Play(0);
            IEnumerator waiter() 
            {
                yield return new WaitForSeconds(4);
                notification.gameObject.SetActive(false);
            }
            StartCoroutine(waiter());
        }

    }
}
