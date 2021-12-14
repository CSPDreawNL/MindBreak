using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShortBurn.RiddleTest
{
    public class Floor : MonoBehaviour
    {
        [SerializeField] public bool m_Left = false;
        [SerializeField] public bool m_Right = false;
        [SerializeField] public bool m_Front = false;
        [SerializeField] public bool m_Back = false;

        public Transform right;
        public Transform left;
        public Transform front;
        public Transform back;

        private float timeCount = 3.0f;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (m_Left == true && transform.rotation.z < 5)
            {
                transform.rotation = Quaternion.Slerp(right.rotation, left.rotation, timeCount);
                timeCount = timeCount + Time.deltaTime;
            }

            if (m_Right == true && transform.rotation.z > -5)
            {
                transform.rotation = Quaternion.Slerp(left.rotation, right.rotation, timeCount);
                timeCount = timeCount + Time.deltaTime;
            }

            if (m_Front == true && transform.rotation.x < 5)
            {
                transform.rotation = Quaternion.Slerp(back.rotation, front.rotation, timeCount);
                timeCount = timeCount + Time.deltaTime;
            }

            if (m_Back == true && transform.rotation.z > -5)
            {
                transform.rotation = Quaternion.Slerp(front.rotation, back.rotation, timeCount);
                timeCount = timeCount + Time.deltaTime;
            }
        }
    }
}