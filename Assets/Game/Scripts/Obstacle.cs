using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D objRB; // defino minha classe objRB para privado

    public GameConfiguration config; // defino meu config para public

    void Start()
    {
        objRB = gameObject.GetComponent<Rigidbody2D>(); // meu objrb passa a ser um Rigidbody2D
    }

    
    void Update()
    {
        objRB.velocity = new Vector2(-config.speed, 0f); // defino a velocidade do objRB
    }
}
