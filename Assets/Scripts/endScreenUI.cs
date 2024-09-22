using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endScreenUI : MonoBehaviour
{
     public Button mainMenu;

    private void Start()
    {
        mainMenu.onClick.AddListener(StartMainMenu);
    }

    void StartMainMenu()
    {
        scenesManager.Instance.LoadMainMenu();
    }
}
