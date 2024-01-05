using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator playerAnim;
    public float velocity = 5f; // Velocidade de movimento do personagem
    public float jump = 10f; // Força do pulo
    private Rigidbody2D rb;
    private bool ground; // Verifica se o personagem está no chão
    private SpriteRenderer sr; 
    

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>(); // faz com que o player vire 
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {   
            playerAnim.SetBool("jump", true);
            rb.velocity = Vector2.up * 12;
        }


        // Verifica se o personagem está no chão
        ground = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("ground"));
        

        // Movimentação horizontal
        float movimentHorizontal = Input.GetAxis("Horizontal");
        Vector2 moviment = new Vector2(movimentHorizontal * velocity, rb.velocity.y);
        rb.velocity = moviment;

        // Pulo
        if (ground && Input.GetKeyDown(KeyCode.W))
        {
            
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            
        }

    

        if (movimentHorizontal > 0) // acessando o sprite render do inspector
        {
            playerAnim.SetBool("walk", true);
            sr.flipX = false;
        }


        else if (movimentHorizontal < 0) // acessando o sprite render do inspector
        {
            playerAnim.SetBool("walk", true);
            sr.flipX = true;
        }

        else 
        {
            playerAnim.SetBool("walk", false);
  
        }

        

        
        
    }
}
