﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            GameObject go = GameObject.FindGameObjectWithTag("Player");
            Player p = go.GetComponent<Player>();
            p.Pontuacao();
        }
    }
}
