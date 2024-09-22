using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class timerManager : MonoBehaviour
{
  public TextMeshProUGUI timerText;

  public float startingTimer;
  public float currentTimer;
  public bool timerActive;

  private static float highestScore;

  private inputReader game;

  private void Start()
  {
        timerActive = true;
        currentTimer = startingTimer;
        UpdateTimer();

        highestScore = PlayerPrefs.GetFloat("HighestScore", 0f);
        game = FindObjectOfType<inputReader>();
  }

  private void Update()
  {
        if (timerActive)
        {
            currentTimer -= Time.deltaTime;
            UpdateTimer();

            if (currentTimer <= 0)
            {
                currentTimer = 0;
                timerActive = false;
            
                UpdateHighestScore();
            }
        }
  }

  void UpdateTimer()
  {
        TimeSpan time = TimeSpan.FromSeconds(currentTimer);
        timerText.text = time.ToString(@"mm\:ss");
  }

  void UpdateHighestScore()
  {
        float currentScore = game.score;

        if (currentScore > highestScore)
        {
            highestScore = currentScore;
            PlayerPrefs.SetFloat("HighestScore", highestScore);
        }
  }






  








}
