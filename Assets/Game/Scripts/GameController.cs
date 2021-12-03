using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool isGamingRunning;

    public ObstacleGenerator generator;
    public GameConfiguration config;

    void Start()
    {
        isGamingRunning = false;

        GameStart();
    }

    void GameStart()
    {
        isGamingRunning = true;

        config.speed = 4f;
        generator.GenerateObstacles();
    }

    public void GameOver()
    {
        isGamingRunning = false;

        config.speed = 0f;
        generator.StopGenerator();
    }
}
