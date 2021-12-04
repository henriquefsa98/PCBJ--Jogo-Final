using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public Animator animator; // defino a classe animator como public
    public CanvasGroup cv; // defino a classe cv como public

    private void /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    Start()
    {
        //animator = GetComponent<Animator>();
        //cv = GetComponent<CanvasGroup>();

        //cv.interactable = false;
        //cv.blocksRaycasts = false;
    }
    public void Show()
    {
        cv.interactable = true; // jogo para verdadeiro
        cv.blocksRaycasts = true; // jogo para verdadeiro
        animator.Play("FadeInUI"); // animação do jogador iniciada 
    }

    public void Hide()
    {
        animator.Play("FadeOutUI"); // animação do jogador desapareceu

        cv.interactable = false; // jogo para falso
        cv.blocksRaycasts = false; // jogo para falso
    }
}
