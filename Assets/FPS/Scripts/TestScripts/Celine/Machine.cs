using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public GameObject MachinePanel;
    public bool getkeybool;
    public bool goodcolor;
    public GameObject Key;

    public Collider collider;

    public void Activate()
    {
        if (goodcolor)
        {
            if (getkeybool == false)
            {
                collider.enabled = false;
                Key.SetActive(true);
                getkeybool = true;

            }
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "emmer_cement")
        {
            if (Mixing.instance.cementKey)
            {
                goodcolor = true;
                Mixing.instance.CementKey.SetActive(false);
            }
        }
       
    }

    private void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
       
       
    }


}
