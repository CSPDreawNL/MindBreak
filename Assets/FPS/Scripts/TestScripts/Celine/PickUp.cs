using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool key1;
    public bool key2;
    public bool key3;
    public bool inTrigger1;
    public bool inTrigger2;
    public bool inTrigger3;
    public bool inDoorTrigger;
    public bool KeyinDoor1;
    public bool KeyinDoor2;
    public bool KeyinDoor3;

    public GameObject pickup;
    public GameObject door;
    public GameObject MessagePanel;
    public GameObject MessagePanel2;
    public GameObject MessagePanel3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup1")
        {
            MessagePanel.SetActive(true);
            pickup = other.gameObject;
            inTrigger1 = true;        
        }
        if (other.gameObject.tag == "Pickup2")
        {
            MessagePanel.SetActive(true);
            pickup = other.gameObject;
            inTrigger2 = true;        
        }
        if (other.gameObject.tag == "Pickup3")
        {
            MessagePanel.SetActive(true);
            pickup = other.gameObject;
            inTrigger3 = true;        
        }

        if (other.gameObject.tag == "Door")
        {
            if (key1 || key2 || key3)
            {
                MessagePanel2.SetActive(true);
            }
            else
            {
                MessagePanel3.SetActive(true);
            }
            
            inDoorTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Door" || other.gameObject.tag == "Pickup1" || other.gameObject.tag == "Pickup2" || other.gameObject.tag == "Pickup3")
        {
            inTrigger1 = false;
            inTrigger2 = false;
            inTrigger3 = false;
            inDoorTrigger = false;
            MessagePanel.SetActive(false);
            MessagePanel2.SetActive(false);
            MessagePanel3.SetActive(false);
        }
    
    }

    private void Update()
    {
        if (inTrigger1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                MessagePanel.SetActive(false);
                key1 = true;
                inTrigger1 = false;
                Destroy(pickup.gameObject);
            }
        }
        if (inTrigger2)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                MessagePanel.SetActive(false);
                key2 = true;
                inTrigger2 = false;
                Destroy(pickup.gameObject);
            }
        }
        if (inTrigger3)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                MessagePanel.SetActive(false);
                key3 = true;
                inTrigger3 = false;
                Destroy(pickup.gameObject);
            }
        }

        if (inDoorTrigger == true && key1 == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                MessagePanel2.SetActive(false);
                key1 = false;
                inDoorTrigger = false;
                KeyinDoor1 = true;
            }
        }
        if (inDoorTrigger == true && key2 == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                MessagePanel2.SetActive(false);
                key2 = false;
                inDoorTrigger = false;
                KeyinDoor2 = true;
            }
        }
        if (inDoorTrigger == true && key3 == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                MessagePanel2.SetActive(false);
                key3 = false;
                inDoorTrigger = false;
                KeyinDoor3 = true;
            }
        }

        if (KeyinDoor1 == true && KeyinDoor2 == true && KeyinDoor3 == true)
        {
            Destroy(door.gameObject);
        }
    }
}
