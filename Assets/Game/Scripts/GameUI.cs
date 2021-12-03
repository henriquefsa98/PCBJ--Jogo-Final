using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public Animator animator;
    public CanvasGroup cv;

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
        

        cv.interactable = true;
        cv.blocksRaycasts = true;
        animator.Play("FadeInUI");
        Debug.Log("Ve se chegou ate aki jao");
    }

    public void Hide()
    {
        animator.Play("FadeOutUI");

        cv.interactable = false;
        cv.blocksRaycasts = false;
    }
}
