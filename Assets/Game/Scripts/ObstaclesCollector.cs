using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesCollector : MonoBehaviour // defino  a classe ObstaclesCollector como public 
{
    private void OnTriggerEnter2D(Collider2D collision) //Defino  OnTriggerEnter2D(Collider2D collision)  como privado onde  OnTriggerEnter2D(Collider2D collision) é Enviado quando outro objeto entra em um colisão de gatilho anexado a este objeto
    {
        if (collision.tag == "Obstacle") // se minha tag de colisao for == ao obstaculo 
        {
            collision.gameObject.SetActive(false); // jogo minha collision para falso
        }
    }
}
