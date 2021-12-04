using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    private bool isGamingRunning; // defino isgamingrunning como private e booleano
    private int score; // defino score como private e int 
    private int currentLevelIndex; // defino currentlevelindex como private e int 

    public ObstacleGenerator generator; //defino generator como pubic 
    public GameConfiguration config; //defino config como public
    public TextMeshProUGUI scoreLabel; // defino scorelabel como public 

    public GameUI gameStartUI; // defino gamestartui como public
    public GameUI gameOverUI; //defino gameroverui como public 

    public Player player;//defino player como public 
    public LevelConfiguration[] levels; // defino levels como public

    void Start()
    {
        isGamingRunning = false;// jogo para falso

        gameStartUI.gameObject.SetActive(true); // jogo para verdadeiro 

        gameOverUI.gameObject.SetActive(false);// jogo para falso

        gameStartUI.Show(); // inicio o gameStartUI

        config.speed = 0f; // defino a velocidade para 0f

    }

    private void FixedUpdate() // é chamado 60 vezes per sec
    {
        scoreLabel.text = score.ToString("000000.##"); // inicio para 60
        
        if (!isGamingRunning) return; //se meu jogo for  diferente do jogo começando
        score++; // incrimento meu score 
        CheckLevelUpdate();//inicio a função
    }

    private void CheckLevelUpdate() // checando meu level 
    {
        if (currentLevelIndex >= levels.Length - 1 ) return; // se meu level for > ou igual
        if (score < levels[currentLevelIndex + 1].minScore) return; // se meu score for < que level 
        currentLevelIndex++;//adiciono ++ no meu currentlevelindex

        SetCurrentLevelConfiguration();//inicio a função
    }
    private void SetCurrentLevelConfiguration() // definição do level
    {
        LevelConfiguration level = levels[currentLevelIndex]; // indexo meu level 
        config.speed = level.speed; // mudo meu speed para level speed 
        config.minRangeObstacleGenerator = level.minRangeObstacleGenerator; // defino o level min
        config.maxRangeObstacleGenerator = level.maxRangeObstacleGenerator; //defino o level max
    }

    public void GameStart() // jogo iniciado
    {
        currentLevelIndex = 0; // jogado par 0
        SetCurrentLevelConfiguration(); // inicia a função

        isGamingRunning = true; // jogado para verdadeiro 

        generator.GenerateObstacles(); //inicia os obstaculos
        score = 0; // score iniciado a 0 
        gameStartUI.Hide(); // inicia 

        gameStartUI.gameObject.SetActive(false); // jogado para 0

        player.SetActive(); // inicia a função
        
    }

    public void GameOver() // tela de fim 
    {
        isGamingRunning = false;//jogo para

        config.speed = 0f;//velocidae jogada para 0
        generator.StopGenerator(); // inicia o meu generator parado

        gameOverUI.gameObject.SetActive(true);// Ui do jogo é jogado para verdadeiro 

        gameOverUI.Show(); // inicia 
    }

    public void RestartGame() // recomeço o jogo
    {
        gameOverUI.Hide(); // inicio gameOverUI

        gameOverUI.gameObject.SetActive(false); // jogo para falso

        generator.ResetGenerator();// recomeço o jogo
        GameStart();//inicia o jogo
    }

    public void CreditScene() // inicio a cena de credito
    {

        SceneManager.LoadScene("Credits"); // inicia os creditos 

    }

    public void ExitGame() //fim do jogo 
    {

        #if UNITY_EDITOR // desliga o jogo
        UnityEditor.EditorApplication.isPlaying = false; // jogo para 0
        #endif // desliga o jogo
        Application.Quit(); // inicia 

    }

}
