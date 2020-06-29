using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BackUIController : MonoBehaviour
{
    public GameObject mainMenu, currentPanel, firstButtonMainMenu;
    public void Back()
    {
        currentPanel.SetActive(false);
        mainMenu.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(firstButtonMainMenu, null);
        MainMenuController.mainMenuTime = 0;
    }
}
