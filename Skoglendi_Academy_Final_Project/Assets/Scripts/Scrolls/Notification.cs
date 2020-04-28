using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Notification : MonoBehaviour
{
    public Text notification;
    public string TutorialText;

    private bool done;
    private void Start()
    {   
        done = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (done) return;
        done = true;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        notification.text = TutorialText;
        notification.gameObject.SetActive(true);
        notification.GetComponent<Animator>().SetTrigger("Enter");
        StartCoroutine(waiter());
    }


    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3);
        notification.GetComponent<Animator>().SetTrigger("Exit");
        notification.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
