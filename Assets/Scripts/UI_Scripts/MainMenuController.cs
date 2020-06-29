using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject howToPlayPanel;
    public GameObject firstButtonHowToPlayPanel;
    public GameObject controlsPanel;
    public GameObject firstButtonControlsPanel;
    public GameObject abilityPanel;
    public GameObject firstButtonAbilityPanel;
    public GameObject mapSelectionPanel;
    public GameObject firstButtonMapSelectionPanel;

    public GameObject controllerSprite, keyboardAndMouseSprite;
    public static float mainMenuTime;
    
    void Start()//so annoying :o 
        {
            mainMenuTime = 0;
        }
    
    void Update() 
        {
            //at the start of the scene, it starts a timer...
            mainMenuTime += 1 * Time.deltaTime;
            Debug.Log("Timer Main menu: " + mainMenuTime);
        }
    
    
    public void PlayIceCreamPeaks() 
        {
            SceneManager.LoadScene(1);
            //these variable 'resets are here as Ive used public static which doesnt rest if i change scenes. I never realised this at the time and its quite a big part of the code so...
            GameManagement.gameComplete = false;
            GameManagement.player1RoundCount = 0;
            GameManagement.player2RoundCount = 0;
            GameManagement.roundComplete = false;
        }
    
    public void MapSelection()
        {
            if (mainMenuTime >= 0.5f) // see if i change this to say 1 this issue should be solved right? just seen it there. It doesnt work because if you open open the scene again it just continues from where it left off.
            {
                mainMenuPanel.SetActive(false);
                mapSelectionPanel.SetActive(true);
                GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(firstButtonMapSelectionPanel, null);
                mainMenuTime = 0;
            }
        }
    
    public void HowtoPlay()
        {
            mainMenuPanel.SetActive(false);
            howToPlayPanel.SetActive(true);
            GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(firstButtonHowToPlayPanel, null);

        }
    
    public void Abilities()
        {
            mainMenuPanel.SetActive(false);
            abilityPanel.SetActive(true);
            GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(firstButtonAbilityPanel, null);

        }
    
    public void Controls()
        {
            mainMenuPanel.SetActive(false);
            controlsPanel.SetActive(true);
            GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(firstButtonControlsPanel, null);

        }
    public void QuitGame()
        {
            Debug.Log("Game Quitting....");
            Application.Quit();
        }

    public void Controller()
        {
            controllerSprite.SetActive(true);
            keyboardAndMouseSprite.SetActive(false);
        }
    
    public void KeyboardAndMouse()
        {
            controllerSprite.SetActive(false);
            keyboardAndMouseSprite.SetActive(true);
        }
    public void LinktoWebsite()
        {
            Application.OpenURL("https://marshmallowtakeovergame.wordpress.com/");
        }

    public void LinktoGoogleFormsFeedback()
        {
            Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSfxK3HG2QUiMaWQYRyDRar-G2hkgroN8H4K0qeVhOrVq_peYg/viewform?usp=sf_link");
        }
}
