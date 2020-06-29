using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManagement : MonoBehaviour
{
    public static float player1Health = 100f;
    public static float player2Health = 100f;
    public GameObject CountdownTimerText;
    public GameObject scorePanel;
    public GameObject NextRoundButton;
    public GameObject gameCompletePanel;
    public GameObject firstButtonGameCompletePanel;
    public bool isWon = true;
    public static bool roundComplete = false;

    public GameObject player1, player2;
    public static int player1RoundCount;
    public static int player2RoundCount;
    public int winningRoundNumber;
    private int matchPointNumber;
    public GameObject player1MatchPointText;
    public GameObject player2MatchPointText;

    public Image locationSprite;
    private bool isActive = true;

    public GameObject pauseMenu, firstButtonPauseMenu;

    public float roundTime;
    private float currentRoundTime;

    public bool abilitySpawn;

    public float countdownTimer;
    private float currentCountdownTimer;
    public Text countdownTimeText;

    public Text timeText;
    public Text player1RoundsWon;
    public Text player2RoundsWon;

    public Text player1ScorePanel;
    public Text player2ScorePanel;
    public static bool gameComplete = false;

    public GameObject stewieWinsPanel;
    public GameObject gooeyWinsPanel;
    public PauseMenu pauseMenuScript;


    void Start() 
    {
        //Invoke("Delay", 0.01f);
        CountdownTimerText.SetActive(true);
        currentRoundTime = roundTime;
        currentCountdownTimer = countdownTimer;
        matchPointNumber = winningRoundNumber - 1;
        PauseControls();
        abilitySpawn = true;

    }
    void Update() 
        {
            Debug.Log("Round complete: " + roundComplete);
            //Debug.Log("Player 1 heath: " + player1Health);
            //Debug.Log("Player 2 heath: " + player2Health);
            // Debug.Log("Player 1 rounds: " + player1RoundCount);
            // Debug.Log("Player 2 rounds: " + player2RoundCount);
            player1RoundsWon.text = player1RoundCount.ToString();
            player2RoundsWon.text = player2RoundCount.ToString();
            player1ScorePanel.text = player1RoundCount.ToString();
            player2ScorePanel.text = player2RoundCount.ToString();
            if (player1RoundCount < winningRoundNumber && player2RoundCount < winningRoundNumber)
                {
                    currentCountdownTimer -= 1 * Time.deltaTime;
                }
            // Debug.Log("Countdown: " + currentCountdownTimer);
            countdownTimeText.text = currentCountdownTimer.ToString("0");

            if(Input.GetButtonDown("Pause_Player1") || Input.GetButtonDown("Pause_Player2"))
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(firstButtonPauseMenu, null);                     
                    
            }
            //currentRoundTime -= 1 * Time.deltaTime;
            //Debug.Log(currentRoundTime);
            //timeText.text = currentRoundTime.ToString("00");

            if (currentCountdownTimer <= 1.5f && isActive == true)
            {
                isActive = false;
            }

            if (isActive == false)
            {
                //Debug.Log("gets to crossfade");
                locationSprite.CrossFadeAlpha(0, 0.5f, false);
            }          

            if (player2Health <= 0 && isWon == true)
            {
                Debug.Log("Player1 wins!!!!!");
                isWon = false;
                roundComplete = true;
                player1RoundCount = player1RoundCount + 1;
            }

            if (player1Health <= 0 && isWon == true)
            {
                Debug.Log("Player2 wins!!!!!");
                isWon = false;
                roundComplete = true;
                player2RoundCount = player2RoundCount + 1;
            }


            if (currentCountdownTimer <= 1)
            {
                currentCountdownTimer = 0;
                CountdownTimerText.SetActive(false);
                // player1.GetComponent<Player1Controls>().enabled = true;
                // player2.GetComponent<Player2Controls>().enabled = true;
                Player1Controls.movementActive = true;
                Player2Controls.movementActive = true;
                if (abilitySpawn == true)
                {
                    SpecialAbilitySpawn.abilityUsed = true;
                    abilitySpawn = false;
                }
                

            }

            if (roundComplete == true)
            {
                if ((player1RoundCount < winningRoundNumber) && (player2RoundCount < winningRoundNumber))
                    {
                        PauseControls();
                        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(NextRoundButton, null);
                        scorePanel.SetActive(true);
                        //RoundReset();
                    }
                
                if (player1RoundCount == matchPointNumber)
                    {
                        player1MatchPointText.SetActive(true);
                    }
                
                if (player2RoundCount == matchPointNumber)
                    {
                        player2MatchPointText.SetActive(true);
                    }
                
                if ((player1RoundCount == winningRoundNumber) || (player2RoundCount == winningRoundNumber))
                    {
                        if (gameComplete == false)
                            {
                                // player1.GetComponent<Player1Controls>().enabled = false;
                                // player2.GetComponent<Player2Controls>().enabled = false;
                                PauseControls();
                                GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(firstButtonGameCompletePanel, null);
                                gameCompletePanel.SetActive(true);
                                Debug.Log("Game Finished!!!!!!!!!!!!!");
                                GameReset();
                                

                                if (player1RoundCount == winningRoundNumber)
                                {
                                    Debug.Log("Player1 won");
                                    stewieWinsPanel.SetActive(true);
                                }

                                if (player2RoundCount == winningRoundNumber)
                                {
                                    Debug.Log("Player2 won");
                                    gooeyWinsPanel.SetActive(true);
                                }
                            }
                            
                    }
            }
        }
        public void RoundReset()
        {
            scorePanel.SetActive(false);
            isWon = true;
            player1.transform.position = new Vector2(-11,-1);
            player2.transform.position = new Vector2(11,-1);
            player1Health = 100;
            player2Health = 100;
            Start();
            roundComplete = false;
        }

        //after each match
        public void GameReset()
        {
            scorePanel.SetActive(false);
            isWon = true;
            player1.transform.position = new Vector2(-11,-1);
            player2.transform.position = new Vector2(11,-1);
            player1Health = 100;
            player2Health = 100;
            Start();
            gameComplete = true;
        }
        void PauseControls()
        {
            Player1Controls.movementActive = false;
            Player2Controls.movementActive = false;
        }  
} 
