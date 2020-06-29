using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameComplete : MonoBehaviour
{
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManagement.gameComplete = false;
        GameManagement.player1RoundCount = 0;
        GameManagement.player2RoundCount = 0;
        GameManagement.roundComplete = false;
    }

    public void BackToMainMenu()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
        GameManagement.player1RoundCount = 0;
        GameManagement.player2RoundCount = 0;
        
    }

    public void ExitGame()
    {
        Debug.Log("Game Exiting...");
        Application.Quit();
    }
}
