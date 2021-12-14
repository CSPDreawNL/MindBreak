using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This entire script has the purpose of using raycasts.
public class Vision : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float raycastDistance = 2f;

    // Update is called once per frame
    void Update()
    {
        // You start casting your ray here.
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                // This if statement is to make sure the object has the "Raycast" layer.
                if (hit.transform.gameObject.layer == 6)
                {
                    // From this level on we check the objects tag, so we can then specify what script it uses, and which function is needed to call.
                    if (hit.transform.gameObject.tag == "Cubes")
                    {
                        Pickup pickup = hit.transform.gameObject.GetComponent<Pickup>();
                        pickup.PickUp();
                    }
                    else if (hit.transform.gameObject.tag == "Keys")
                    {
                        if (hit.transform.gameObject.GetComponent<KeyOne>())
                        {
                            KeyOne keyOne = hit.transform.gameObject.GetComponent<KeyOne>();
                            keyOne.PickUp();
                        }
                        if (hit.transform.gameObject.GetComponent<KeyTwo>())
                        {
                            KeyTwo keyTwo = hit.transform.gameObject.GetComponent<KeyTwo>();
                            keyTwo.PickUp();
                        }
                        if (hit.transform.gameObject.GetComponent<KeyThree>())
                        {
                            KeyThree keyThree = hit.transform.gameObject.GetComponent<KeyThree>();
                            keyThree.PickUp();
                        }
                    }
                    else if (hit.transform.gameObject.tag == "Door")
                    {
                        Door door = hit.transform.gameObject.GetComponent<Door>();
                        door.KeyMinigame();
                    }

                    else if (hit.transform.gameObject.tag == "Paint")
                    {
                        Pickup pickup = hit.transform.gameObject.GetComponent<Pickup>();
                        pickup.PickUp();
                    }

                    else if (hit.transform.gameObject.tag == "Machine")
                    {
                        Machine machine = hit.transform.gameObject.GetComponent<Machine>();
                        machine.Activate();
                    }

                    else if (hit.transform.gameObject.tag == "Mixing")
                    {
                        Mixing mixing = hit.transform.gameObject.GetComponent<Mixing>();
                        mixing.Mix();
                    }
                }
            }
        }
    }
// This small function is so that we can see a line to what the character is lookng at in the scene view.
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raycastDistance, Color.red);
    }
#endif
}
