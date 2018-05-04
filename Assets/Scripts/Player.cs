using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private Rigidbody2D rb;
    //private Transform transf;
    public GameObject colisorP;
    //public GameObject plataformaAtual;
    public Vector2 posInicial;

    private bool jumping, executar;
    public Inventory inventory, inventoryGeral;
    //public float speed = 3f;
    public float jumpforce = 200f;
    //public float movX, movY;
    public bool facingRight = true;
    public Button btPlay;
    private float time;
    public float valpos;
    private int pos;

    private bool pulando;
    private Animator playerAnimator;
    public float val;
    private float valPulo;

    //private int pontuacao, vida;

    //public Text scoreTxt, vidaTxt;

    public GameController gc;

    void Awake() {
        //transf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        //deletarPlataforma = false;
        //colisorP = GameObject.FindGameObjectWithTag("ColisorPlataforma");
        //pontuacao = 0;
        //vida = 3;
    }

    private void Start()
    {
        executar = false;
        pos = 0;
        //velocidade = 0.72f;
        time = 1f;
        valPulo = 120.822f;
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        //gc.EscreveTela();
    }

    void FixedUpdate()
    {

        VerificaBotao();

        if (colisorP.activeSelf == false)
        {
            if (time > 0.0f)
            {
                time -= Time.deltaTime;
            }
            else
            {
                if (executar)
                {
                    //Invoke("ExecutarP", 1);
                    ExecutarP();
                    pos++;
                    if (pos >= inventory.comands.Length)
                    {
                        pos = 0;
                        executar = false;
                        LimparTela();
                    }
                }
                time = 1;
            }
        }
    }

    

    private void VerificaBotao()
    {
        if (VerificaCompleto())
        {
            btPlay.gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            btPlay.gameObject.GetComponent<Button>().interactable = false;
        }
    }

    /*public void Mover()
    {

        movX = Input.GetAxis("Horizontal");

        if (movX > 0 && !facingRight) // Movimentando para direita e meu objeto não estiver olhando para a direita
        {
            //Olhe para a direita
            //Flip();
        }
        else if (movX < 0 && facingRight) // Movimentando para esquerda e meu objeto estiver olhando para a direita
        {
            //Olhe para a esquerda
            //Flip();
        }

       

        rb.velocity = new Vector2(movX * speed, rb.velocity.y);
        
        
        /*if (movX != 0)
        {
            playerAnimator.SetBool("Walk", true);
        }
        else
        {
            playerAnimator.SetBool("Walk", false);
        }
    }
    public void Mover(float x)
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
    }*/




    public void ExecutarP()
    {
       
            Debug.Log("Entrou no executar");
            Debug.Log("pos: " + pos);
            switch (inventory.comands[pos].name)
            {
                case "Direita":
                    Debug.Log("Entrou no Direita");
                    ////transf.Translate(Vector2.right * velocidade);
                    //transf.position = Vector2.Lerp(transf.position, transf.position + new Vector3(0.72f,0,0), val);
                    //playerAnimator.SetBool("Caminhando", true);
                    rb.AddForce(new Vector2(valPulo, 0));
                    break;
                case "Pular":
                    Debug.Log("Entrou no Pular!");
                    rb.AddForce(new Vector2(45*2, jumpforce));
                    break;
                case "Quebrar":
                    Debug.Log("Entrou no Quebrar!");
                    //Debug.Log("deletarPlataforma" + deletarPlataforma);
                    colisorP.SetActive(true);
                    //colisorP.SetActive(false);



                    break;
                case "Esquerda":
                    Debug.Log("Entrou no Esquerda!");
                    //transf.position = Vector2.Lerp(transf.position, transf.position - new Vector3(0.72f, 0, 0), val);
                    rb.AddForce(new Vector2(-valpos, 0));
                    break;
                default:
                    Debug.Log("Break!");
                    break;

            }
            playerAnimator.SetBool("Caminhando", false);
        
    }

    public void Executar()
    {
        executar = true;
    }

    public bool VerificaCompleto()
    {
        for (int i = 0; i < inventory.slots.childCount; i++)
        {
            GameObject item = inventory.slots.GetChild(i).GetComponent<Slot>().Item;
            if (item == null)
            {
                return false;
            }
        }
        return true;
    }

    public void Pontuacao()
    {

        gc.Pontuacao();
        
    }

    public void ReiniciaFase()
    {
        gc.ReiniciaFase();
    }

    public void MortePlayer()
    {
        Debug.Log("Entrou na morte do PLayer");
        gc.ReiniciaFase();
    }

    /*private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bloco"))
        {
            noChao = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bloco"))
        {
            noChao = true;
        }
        
    }*/

    public void LimparTela()
    {
        /*for(int i = 0; i < inventory.comands.Length; i++)
        {
            
        }*/
    }

}



/*private void Flip()
 {
     facingRight = !facingRight;
     Vector3 scale = transf.localScale;
     scale.x *= -1;

     transf.localScale = scale;
 }*/
