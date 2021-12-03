using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    private bool isGamingRunning;
    private int score;
    private int currentLevelIndex;

    public ObstacleGenerator generator;
    public GameConfiguration config;
    public TextMeshProUGUI scoreLabel;

    public GameUI gameStartUI;
    public GameUI gameOverUI;

    public Player player;

    public LevelConfiguration[] levels;

    void Start()
    {
        isGamingRunning = false;

        gameStartUI.gameObject.SetActive(true);

        gameOverUI.gameObject.SetActive(false);

        gameStartUI.Show();

        config.speed = 0f;

    }

    private void FixedUpdate() // é chamado 60 vezes per sec
    {
        scoreLabel.text = score.ToString("000000.##");
        
        if (!isGamingRunning) return;
        score++;
        CheckLevelUpdate();
    }

    private void CheckLevelUpdate()
    {
        if (currentLevelIndex >= levels.Length - 1 ) return;
        if (score < levels[currentLevelIndex + 1].minScore) return;
        currentLevelIndex++;

        SetCurrentLevelConfiguration();
    }
    private void SetCurrentLevelConfiguration()
    {
        LevelConfiguration level = levels[currentLevelIndex];
        config.speed = level.speed;
        config.minRangeObstacleGenerator = level.minRangeObstacleGenerator;
        config.maxRangeObstacleGenerator = level.maxRangeObstacleGenerator;
    }

    public void GameStart()
    {
        currentLevelIndex = 0;
        SetCurrentLevelConfiguration();

        isGamingRunning = true;

        generator.GenerateObstacles();
        score = 0;
        gameStartUI.Hide();

        gameStartUI.gameObject.SetActive(false);

        player.SetActive();
        
    }

    public void GameOver()
    {
        isGamingRunning = false;

        config.speed = 0f;
        generator.StopGenerator();

        gameOverUI.gameObject.SetActive(true);

        gameOverUI.Show();
    }

    public void RestartGame()
    {
        gameOverUI.Hide();

        gameOverUI.gameObject.SetActive(false);

        generator.ResetGenerator();
        GameStart();
    }
}
