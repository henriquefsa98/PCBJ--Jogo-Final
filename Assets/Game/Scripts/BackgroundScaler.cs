using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScaler : MonoBehaviour  
{
    private Vector3 startScale; // defino meu startScale como um vector3 eprivate

    public enum ScaleType
    {
        x, // variavel x 
        y, // variavel y
        all // variavel all
    }

    public ScaleType scaleType = ScaleType.all; // defino scaleType como public e atribu all

    void Start()
    {
        startScale = transform.localScale; // Atribuo startScale  para uma mudação de local

        FitToScreen(); // executo  FitToScreen
    }

    void FitToScreen()
    {
        float height = Camera.main.orthographicSize * 2;   // mudo minha altura 
        float width = height * Screen.width / Screen.height; // mudo  minha largura 

        float newWidth = (scaleType == ScaleType.all || scaleType == ScaleType.x) ? width : startScale.x; // defino uma nova largura 
        float newHeight = (scaleType == ScaleType.all || scaleType == ScaleType.y) ? height : startScale.y; // defino uma nov altura 

        transform.localScale = new Vector3(newWidth, newHeight, startScale.z); // muda minha posição do vector3
    }
}
