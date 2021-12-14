using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositionPaint : MonoBehaviour
{

    public static ResetPositionPaint instance;
    Vector3 startlocation;
    Quaternion startRotation;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        startlocation = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        startRotation = transform.rotation;
    }

    public void ResetPos()
    {
        transform.position = startlocation;
        transform.rotation = startRotation;
    }
}
