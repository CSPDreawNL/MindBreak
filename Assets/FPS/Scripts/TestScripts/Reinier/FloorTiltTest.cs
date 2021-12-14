using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShortBurn.RiddleTest
{
    public class FloorTiltTest : MonoBehaviour
    {
        [SerializeField] bool m_Side = false;
        [SerializeField] Floor floor;

        // Start is called before the first frame update
        void Start()
        {
            floor = FindObjectOfType<Floor>();
        }

        // Update is called once per frame
        void Update()
        {
            if (m_Side == true)
            {
                if (gameObject.name == "Links")
                {
                    floor.m_Left = true;
                    floor.m_Right = false;
                    floor.m_Back = false;
                    floor.m_Front = false;
                }
                if (gameObject.name == "Rechts")
                {
                    floor.m_Right = true;
                    floor.m_Left = false;
                    floor.m_Back = false;
                    floor.m_Front = false;
                }
                if (gameObject.name == "Voor")
                {
                    floor.m_Front = true;
                    floor.m_Back = false;
                    floor.m_Left = false;
                    floor.m_Right = false;
                }
                if (gameObject.name == "Achter")
                {
                    floor.m_Back = true;
                    floor.m_Front = false;
                    floor.m_Left = false;
                    floor.m_Right = false;
                }
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                m_Side = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                m_Side = false;
            }
        }

    }
}
