using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

#if UNITY_EDITOR
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.GraphView;
#endif
public class Player : MonoBehaviour
{
#if UNITY_EDITOR
    public int jem ;
    public int health = 100;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Image healthImage;

    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    private SpriteRenderer SpriteRenderer;
    void Start()
    {

#if UNITY_ANDROID || UNITY_IOS
        Debug.Log("This code only exists on Mobile builds!");
        SetupMobileTouchControls();
#elif UNITY_WEBGL
        Debug.Log("This code only exists on Web browser builds!");
        DisableHeavyGraphics();
 
#endif
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void SetupMobileTouchControls()
    {
        throw new NotImplementedException();
    }

    private void DisableHeavyGraphics()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        if (moveInput > 0.01f)
        {
            SpriteRenderer.flipX = false;
        }
        else if (moveInput < -0.01f)
        { SpriteRenderer.flipX = true; }
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }
        SetAnimation(moveInput);
        healthImage.fillAmount = health / 100f;

        if(transform.position.y < -10f)
        {
            Die2();
        }
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    private void SetAnimation(float moveInput)
    {
        if(isGrounded)
        {
            if(moveInput==0)
            {
                animator.Play("Player_Idle");
            }
            else
            {
                               animator.Play("Player_run");
            }
             
        }
        else { if(rb.velocity.y>0)
            {
                animator.Play("Player_Jump");
            }
            else
            {
                animator.Play("Player_Fall");
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Damage"))
        {
            health -= 25;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            StartCoroutine(BlinkRed());
            if (health <= 0)
            {
                Die();
            }
        }
    }
    private IEnumerator BlinkRed()
    {
        SpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        SpriteRenderer.color = Color.white;
    }
    private void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gamescene");
    }
    private void Die2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("lose");
    }
#endif
}
