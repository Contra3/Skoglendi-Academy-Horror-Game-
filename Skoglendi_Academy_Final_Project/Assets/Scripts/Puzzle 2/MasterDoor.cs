using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterDoor : MonoBehaviour
{

    public GameObject MasterDoorGO;
    private Text MasterDoorText;


    // Start is called before the first frame update
    void Start()
    {
        MasterDoorGO.SetActive(false);
        MasterDoorText = MasterDoorGO.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(PlayerController.hasMasterKey == false)
            {
                MasterDoorGO.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MasterDoorGO.SetActive(false);
        }
    }




}
