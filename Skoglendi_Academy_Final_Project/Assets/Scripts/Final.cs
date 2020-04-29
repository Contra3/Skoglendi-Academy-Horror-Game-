using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource heartbeat;
    private bool done;
    public GameObject credits;
    public GameObject playerCharacter;
    public GameObject MainUICamera;
    void Start()
    {
        heartbeat = gameObject.GetComponentInChildren<AudioSource>();
        done = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (done) return;
        if (other.gameObject.tag != "Player") return;
        done = true;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(finalCutScene());
    }

    IEnumerator finalCutScene()
    {
        heartbeat.Play(0);
        Animator anim = playerCharacter.gameObject.GetComponent<Animator>();
        anim.SetTrigger("Death");
        CanvasGroup cg = credits.GetComponentInParent<CanvasGroup>();
        while (cg.alpha > 0) 
        {
            cg.alpha -= Time.deltaTime / 5;
            yield return null;
        }
        playerCharacter.SetActive(false);
        MainUICamera.SetActive(true);
        credits.SetActive(true);
        while (cg.alpha < 1) 
        {
            cg.alpha += Time.deltaTime / 4;
            yield return null;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
