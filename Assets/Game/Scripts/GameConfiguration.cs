using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Game Runner/GameConfiguration", order = 1)] // crio um menu
public class GameConfiguration : ScriptableObject // defino como uma classe publica 
{
    public float speed = 4f; // defino a classe speed como public e float e defino a velocidade de 4f
    public float minRangeObstacleGenerator; // defino minRangeObstacleGenerator como float e public 
    public float maxRangeObstacleGenerator; // defino maxRangeObstacleGenerator como float e public 
}
