﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisorPlayerPlataforma : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bloco"))
        {
            collision.gameObject.SetActive(false);
        }
        this.gameObject.SetActive(false);
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bloco"))
        {
            collision.gameObject.SetActive(false);
        }
        this.gameObject.SetActive(false);
    }*/

}
