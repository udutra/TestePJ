using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(this.gameObject);
            GameObject go = GameObject.FindGameObjectWithTag("Tiro");
            Rigidbody2D t = go.GetComponent<Rigidbody2D>();
            t.velocity = new Vector2(1,0);
        }
    }
}
