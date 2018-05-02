using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrumaTxt : MonoBehaviour {

    public GameController gc;

    private void Awake()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Use this for initialization
    void Start () {
        if (this.gameObject.CompareTag("VidaTxt"))
        {
            //GameObject vida = GameObject.FindGameObjectWithTag("VidaTxt");
            //Text TextVida = vida.GetComponent<Text>();
            this.gameObject.GetComponent<Text>().text = "Vida: " + gc.GetVida() + "/3";
        }    
        else if (this.gameObject.CompareTag("ScoreTxt")){
            this.gameObject.GetComponent<Text>().text = "Score: " + gc.GetPontuacao();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
