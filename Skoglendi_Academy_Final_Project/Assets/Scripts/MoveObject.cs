using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
      public GameObject playerCam;

    //public string GrabButton = "Grab";
    //public string ThrowButton = "Throw";

    private float PickupRange = 5f;
    private float ThrowStrength = 5f;
    private float distance = 2f;
    private float maxDistanceGrab = 25f;
   
    private Ray playerAim;
    private GameObject objectHeld;
    private bool isObjectHeld;
   
    void Start () {
        isObjectHeld = false;
        objectHeld = null;
    }
   
    void FixedUpdate () {
        if(Input.GetMouseButton(0)){
            if(!isObjectHeld){
                tryPickObject();
            } else {
                holdObject();
            }
        }else if(isObjectHeld){
            DropObject();
        }
       
        if(Input.GetKeyDown(KeyCode.E) && isObjectHeld){
            isObjectHeld = false;
            objectHeld.GetComponent<Rigidbody>().useGravity = true;
            ThrowObject();
        }      
    }
   
    private void tryPickObject(){
        Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
       
        if (Physics.Raycast (playerAim, out hit, PickupRange)){
            if(hit.collider.tag == "pickObject"){
                Debug.Log("Targeted Sack");
                isObjectHeld = true;
                objectHeld = hit.collider.gameObject;
                objectHeld.GetComponent<Rigidbody>().useGravity = false;
                objectHeld.GetComponent<Rigidbody>().freezeRotation = true;
            }
        }
    }
   
    private void holdObject(){
        Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
       
        Vector3 nextPos = playerCam.transform.position + playerAim.direction * distance;
        Vector3 currPos = objectHeld.transform.position;
       
        objectHeld.GetComponent<Rigidbody>().velocity = (nextPos - currPos) * 10;
       
        if (Vector3.Distance(objectHeld.transform.position, playerCam.transform.position) > maxDistanceGrab)
        {
            DropObject();
        }
    }
   
    private void DropObject()
    {
        isObjectHeld = false;
        objectHeld.GetComponent<Rigidbody>().useGravity = true;
        objectHeld.GetComponent<Rigidbody>().freezeRotation = false;
        objectHeld = null;
    }
   
    private void ThrowObject()
    {
        objectHeld.GetComponent<Rigidbody>().AddForce(playerCam.transform.forward * ThrowStrength);
        objectHeld.GetComponent<Rigidbody>().freezeRotation = false;
        objectHeld = null;
    }
}//End Script

