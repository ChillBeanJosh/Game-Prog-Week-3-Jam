using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainmainUI : MonoBehaviour
{
     public Button play;


    private void Start()
    {
        play.onClick.AddListener(startGame);
        
    }



        void startGame()
        {
            scenesManager.Instance.LoadNewGame();
        }


}
