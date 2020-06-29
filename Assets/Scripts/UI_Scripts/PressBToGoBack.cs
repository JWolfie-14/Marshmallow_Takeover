using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PressBToGoBack : MonoBehaviour
{
    public GameObject currentPanel, mainMenuPanel, firstButtonMainMenu;

    void Update()
    {
        if (Input.GetButtonDown("Cancel_Player1"))
        {
            currentPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
            GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(firstButtonMainMenu, null);
        }
    }
}
