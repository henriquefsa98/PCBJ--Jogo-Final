using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent onPlayerHitted;

    public Transform startPlayerPosition;
    private Rigidbody2D plyRB;
    private Animator animator;
    private bool canJump;
    
    private bool isEnabled;

    public float jumpFactor = 5f;
    public float forwardFactor = 0.2f;

    public float forwardForce = 0f;

    public AudioSource jumping;

    void Start()
    {
        plyRB = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        canJump = true;
        isEnabled = false;

        float camWidth = Camera.main.orthographicSize * Camera.main.aspect;
        startPlayerPosition.localPosition = new Vector3 (gameObject.transform.localScale.x - camWidth, startPlayerPosition.localPosition.y, startPlayerPosition.localPosition.z);

        gameObject.transform.localPosition = startPlayerPosition.localPosition;

        jumping = GetComponent<AudioSource>();
    }

    public void SetActive()
    {
        isEnabled = true;
        canJump = true;
        animator.Play("player_running");
        plyRB.constraints = RigidbodyConstraints2D.FreezeRotation;

        gameObject.transform.localPosition = startPlayerPosition.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            jumping.Play();
        }
    }

    void Jump()
    {
        if (!isEnabled) return;
        if (canJump)
        {
            canJump = false;

            if (transform.position.x < 0)
            {
                forwardForce = forwardFactor;
            }

            else
            {
                forwardForce = 0f;
            }

            plyRB.velocity = new Vector2 (forwardForce, jumpFactor);
            animator.Play("player_jumping");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isEnabled) return;
        if (collision.gameObject.tag == "Obstacle")
        {
            plyRB.constraints = RigidbodyConstraints2D.FreezeAll;
            onPlayerHitted.Invoke();
            animator.Play("player_hurt");
            isEnabled = false;
            onPlayerHitted.Invoke();
        }

        else
        {
            animator.Play("player_running");
        }

        canJump = true;
        
    }
}
