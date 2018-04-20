using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rb;
    private Transform transf;
    private bool jumping;
    public float speed = 3f;
    public float jumpforce = 200f;
    public float movX, movY;
    public bool facingRight = true;



    void Awake() {
        transf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    public void Move()
    {

        movX = Input.GetAxis("Horizontal");

        if (movX > 0 && !facingRight) // Movimentando para direita e meu objeto não estiver olhando para a direita
        {
            //Olhe para a direita
            Flip();
        }
        else if (movX < 0 && facingRight) // Movimentando para esquerda e meu objeto estiver olhando para a direita
        {
            //Olhe para a esquerda
            Flip();
        }

       

        rb.velocity = new Vector2(movX * speed, rb.velocity.y);
        
        
        /*if (movX != 0)
        {
            playerAnimator.SetBool("Walk", true);
        }
        else
        {
            playerAnimator.SetBool("Walk", false);
        }*/
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transf.localScale;
        scale.x *= -1;

        transf.localScale = scale;
    }

    public void Jump()
    {
        var AbsVelY = Mathf.Abs(rb.velocity.y);

        jumping = AbsVelY >= 0.05;

        if (Input.GetKeyDown("up") && !jumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpforce));
            //playerAnimator.SetBool("Jump", true);
        }
        else if (!jumping)
        {
            //playerAnimator.SetBool("Jump", false);
        }
    }

    public void Move(float x)
    {

        movX = x;

        if (movX > 0) // Movimentando para direita e meu objeto não estiver olhando para a direita
        {
            rb.velocity = new Vector2(movX * speed, rb.velocity.y);
        }
        else if (movX < 0 && facingRight) // Movimentando para esquerda e meu objeto estiver olhando para a direita
        {
            rb.velocity = new Vector2(movX * speed, rb.velocity.y);
        }

        //rb.velocity = new Vector2(movX * speed, rb.velocity.y);
    }
}
