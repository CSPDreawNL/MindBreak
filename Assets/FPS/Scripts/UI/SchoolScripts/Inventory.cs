using UnityEngine;

// This entire script is just to keep track of the keys through the entire game.
public class Inventory : MonoBehaviour
{
    static Inventory instance = null;

    // For the singleton
    void Awake()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        if (instance == null)
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    public bool key1;
    public bool key2;
    public bool key3;
}
