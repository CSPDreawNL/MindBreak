using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseMenuUI;
    public static bool MenuOn = false;

    // Update is called once per frame
    public void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!MenuOn)
            {
                Paused();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Resume();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
          
        }

        
      
    }

    public void Paused()
    {
        Time.timeScale = 0f;
        PauseMenuUI.SetActive(true);
        
        MenuOn = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);     
        MenuOn = false;
    }

    public void QuitButton()
    {
        Time.timeScale = 1f;
        Application.Quit();   
    }
}
