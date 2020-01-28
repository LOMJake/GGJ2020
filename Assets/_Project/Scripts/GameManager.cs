using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private bool isGameOver = false;
    public float gameOverTimerMax = 2f;

    protected override void Awake()
    {
        base.Awake();
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (isGameOver)
        {
            if (gameOverTimerMax > 0f)
            {
                gameOverTimerMax -= Time.unscaledDeltaTime;
            }
            else
            {
                RestartGame();
                enabled = false;
            }
        }

    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
