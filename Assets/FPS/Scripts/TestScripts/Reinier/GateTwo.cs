using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTwo : MonoBehaviour
{
    [SerializeField] Animator gate;
    [SerializeField] bool key;
    [SerializeField] GameObject keyPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gate.SetTrigger("OpenGate");
            if (!key)
            {
                keyPanel.SetActive(true);
            }
        }
        if (other.name == "DeurKey")
        {
            gate.SetBool("Key", true);
            key = true;
            other.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            keyPanel.SetActive(false);
        }
    }
}
