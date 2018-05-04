using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController Instance;
    public int pontuacao, vida;
    public Text scoreTxt, vidaTxt;

    void Awake()
    {
        this.InstantiateController();
        
    }

    private void InstantiateController()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            vida = 3;
            pontuacao = 0;
            
        }
        else if (this != Instance)
        {
            Destroy(this.gameObject);
        }

        

    }

    // Use this for initialization
    void Start()
    {
        vidaTxt = GameObject.FindGameObjectWithTag("VidaTxt").GetComponent<Text>();
        scoreTxt = GameObject.FindGameObjectWithTag("ScoreTxt").GetComponent<Text>();
        //EscreveTela();
    }

    public void EscreveTela()
    {
        scoreTxt.text = "Score: " + pontuacao;
        vidaTxt.text = "Vida: " + vida + "/3";
    }

    // Update is called once per frame
    void Update()
    {
        vidaTxt = GameObject.FindGameObjectWithTag("VidaTxt").GetComponent<Text>();
        scoreTxt = GameObject.FindGameObjectWithTag("ScoreTxt").GetComponent<Text>();
        EscreveTela();
    }

    public void Pontuacao()
    {
        pontuacao = pontuacao + 10;
        scoreTxt.text = "Score: " + pontuacao;
    }

    public void ReiniciaFase()
    {
        vida = vida - 1;
        if (vida > 0)
        {
            vidaTxt.text = "Vida: " + vida + "/3";
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
        else
        {
            pontuacao = 0;
            vida = 3;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Fim de Jogo");
        }
    }

    public int GetVida()
    {
        return vida;
    }

    public int GetPontuacao()
    {
        return pontuacao;
    }
}
