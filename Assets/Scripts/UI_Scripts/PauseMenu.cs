using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject controlPanel;
    public GameObject pauseMenu;
    public GameObject firstButtonControlsPanel;
    public GameObject controllerSprite, mouseAndKeyboardSprite;

   
    
    void Update() 
        {
            if(Input.GetButtonDown("Cancel_Player1"))
            {
                    pauseMenu.SetActive(false);
                    Time.timeScale = 1; 
            }
        }
    
    public void Resume()
    {
       pauseMenu.SetActive(false);
       Time.timeScale = 1;       
    }

    public void Controls()
    {
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(firstButtonControlsPanel, null);
        pauseMenu.SetActive(false);
        controlPanel.SetActive(true);

    }

    public void Controller()
    {
        controllerSprite.SetActive(true);
        mouseAndKeyboardSprite.SetActive(false);

    }

    public void MouseAndKeyboard()
    {
        controllerSprite.SetActive(false);
        mouseAndKeyboardSprite.SetActive(true);
    }

    public void QuitMatch()
    {
        SceneManager.LoadScene(0);
        GameManagement.player1RoundCount = 0;
        GameManagement.player2RoundCount = 0;
        Player1Controls.movementActive = false;
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Debug.Log("Game exiting....");
        Application.Quit();

    }
}
