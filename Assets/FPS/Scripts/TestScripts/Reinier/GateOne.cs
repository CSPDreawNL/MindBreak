using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOne : MonoBehaviour
{
    [SerializeField] Animator gate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gate.SetTrigger("OpenGate");
        }
    }
}
