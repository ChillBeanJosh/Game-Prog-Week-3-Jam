using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class timerManager : MonoBehaviour
{
  public TextMeshProUGUI timerText;
  public TextMeshProUGUI scoreText;
  public TextMeshProUGUI highscoreText;

  public float startingTimer;
  public float currentTimer;
  public bool timerActive;

  private static float highestScore;

  public inputReader game;

  private void Start()
  {
        timerActive = true;
        currentTimer = startingTimer;
        UpdateTimer();

        highestScore = PlayerPrefs.GetFloat("HighestScore", 0f);
        UpdateHighScore();

        game = FindObjectOfType<inputReader>();
  }

  private void Update()
  {
        if (timerActive)
        {
            currentTimer -= Time.deltaTime;

            UpdateTimer();
            UpdateScore();

            if (currentTimer <= 0)
            {
                currentTimer = 0;
                timerActive = false;

                UpdateHighestScore();
                scenesManager.Instance.LoadScene(scenesManager.Scene.EndMenu);
            }
        }
  }

  void UpdateTimer()
  {
        TimeSpan time = TimeSpan.FromSeconds(currentTimer);
        timerText.text = time.ToString(@"mm\:ss");
  }

  void UpdateScore()
  {
        float currentScore = game.score;
        scoreText.text = "Score: " + currentScore.ToString();
  }

  void UpdateHighScore()
  {
        highscoreText.text = "HighScore: " + highestScore.ToString();
  }

  void UpdateHighestScore()
  {
        float currentScore = game.score;

        if (currentScore > highestScore)
        {
            highestScore = currentScore;
            PlayerPrefs.SetFloat("HighestScore", highestScore);
            UpdateHighScore();
        }
  }

}
