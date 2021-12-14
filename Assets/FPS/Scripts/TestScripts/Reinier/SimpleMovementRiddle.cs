using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShortBurn.RiddleTest
{
    public class SimpleMovementRiddle : MonoBehaviour
    {
        private float m_HorizontalInput;
        private float m_ForwardInput;
        private float m_TurnSpeed = 0.5f;
        private float m_Speed = 3f;


        void Update()
        {
            m_HorizontalInput = Input.GetAxis("Horizontal");
            m_ForwardInput = Input.GetAxis("Vertical");

            transform.Translate(Vector3.forward * Time.deltaTime * m_ForwardInput * m_Speed);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.position += new Vector3(0, 2f, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Vector3 rotationVector = new Vector3(0, m_TurnSpeed, 0);
                transform.rotation *= Quaternion.Euler(rotationVector);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Vector3 rotationVector = new Vector3(0, -m_TurnSpeed, 0);
                transform.rotation *= Quaternion.Euler(rotationVector);
            }
        }
    }
}
