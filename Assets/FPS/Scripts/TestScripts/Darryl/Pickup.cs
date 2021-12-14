using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform location;
    [SerializeField] GameObject cam;

    [SerializeField] Collider collider;

    [SerializeField] bool beinghold = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        location = GameObject.FindGameObjectWithTag("Location").transform;
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void PickUp()
    {
        HoldingSomething holdingSomething = location.gameObject.GetComponent<HoldingSomething>();
        Rigidbody rbody = GetComponent<Rigidbody>();

        // If the item is not being hold the collider will be turned on, it will be unparented and the gravity will be turned back on.
        if (beinghold)
        {
            beinghold = false;
            holdingSomething.holding = false;
            collider.enabled = true;
            transform.SetParent(null);
            rbody.useGravity = true;
        }

        else if (!beinghold)
        {
            if (!holdingSomething.holding)
            {
                // If the item is being hold the collider will be turned off, it's gravity will be also be turned off,
                // all of it's velicoty will be turned off and will be parented to the position to the camera.
                beinghold = true;
                holdingSomething.holding = true;
                collider.enabled = false;
                rbody.useGravity = false;
                rbody.velocity = Vector3.zero;
                transform.SetParent(cam.transform);
                transform.position = location.position;
            }
        }
    }
}