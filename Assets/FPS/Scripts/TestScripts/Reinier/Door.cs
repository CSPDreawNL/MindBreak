using UnityEngine;

public class Door : MonoBehaviour
{
    public bool keyInDoor1;
    public bool keyInDoor2;
    public bool keyInDoor3;
    public bool PanelOpen;

    public GameObject door;

    Inventory inventory;
    [SerializeField] GameObject messagePanel;
    [SerializeField] GameObject messagePanel2;
    [SerializeField] GameObject messagePanel3;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        if (PanelOpen && inventory.key1 && inventory.key2 && inventory.key3)
        {
            messagePanel3.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X) && keyInDoor1 == false && keyInDoor3 == false && keyInDoor2 == false)
            {
                keyInDoor2 = true;
            }

            if (Input.GetKeyDown(KeyCode.C) && keyInDoor1 == false && keyInDoor2 == true && keyInDoor3 == false)
            {
                keyInDoor3 = true;
            }

            if (Input.GetKeyDown(KeyCode.Z) && keyInDoor1 == false && keyInDoor2 == true && keyInDoor3 == true)
            {
                keyInDoor1 = true;
                inventory.key1 = false;
                inventory.key2 = false;
                inventory.key3 = false;
            }

            else if (Input.GetKeyDown(KeyCode.C) && keyInDoor1 == false && keyInDoor2 == false && keyInDoor3 == false)
            {
                ClosePanel();
            }

            else if (Input.GetKeyDown(KeyCode.Z) && keyInDoor1 == false && keyInDoor2 == false && keyInDoor3 == false)
            {
                ClosePanel();
            }

            else if (Input.GetKeyDown(KeyCode.Z) && keyInDoor1 == false && keyInDoor2 == true && keyInDoor3 == false)
            {
                ClosePanel();
            }

            if (keyInDoor1 && keyInDoor2 && keyInDoor3)
            {
                Destroy(door.gameObject);
                ClosePanel();
            }
        }

        if (PanelOpen)
        {
            if (!inventory.key1 || !inventory.key2 || !inventory.key3)
            {
                ClosePanel();
            }
        }
    }
    private void ClosePanel()
    {
        messagePanel3.SetActive(false);
        PanelOpen = false;
        keyInDoor1 = false;
        keyInDoor2 = false;
        keyInDoor3 = false;
    }

    public void KeyMinigame()
    {
        PanelOpen = true;
    }
}
