using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColisorChao"))
        {
            Debug.Log("Entrou no fim do jogo!");
            GameObject go = GameObject.FindGameObjectWithTag("Player");
            Player p = go.GetComponent<Player>();
            p.ReiniciaFase();
        }
    }
}
