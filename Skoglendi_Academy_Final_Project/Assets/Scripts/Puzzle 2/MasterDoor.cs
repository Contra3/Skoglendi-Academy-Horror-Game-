using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterDoor : MonoBehaviour
{

    public GameObject MasterDoorGO;

    // Start is called before the first frame update
    void Start()
    {
        MasterDoorGO.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
             MasterDoorGO.SetActive(true);
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
