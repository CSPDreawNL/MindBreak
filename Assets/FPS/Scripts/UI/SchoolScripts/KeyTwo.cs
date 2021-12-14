using UnityEngine;

// This entire script is so you can pick up the key and so it can show in the inventory.
public class KeyTwo : MonoBehaviour
{
    Inventory inventory;
    [SerializeField] GameObject messagePanel;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void PickUp()
    {
        inventory.key2 = true;
        messagePanel.SetActive(false);
        Destroy(gameObject);
    }
}
