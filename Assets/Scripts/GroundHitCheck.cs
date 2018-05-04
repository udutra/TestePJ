using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHitCheck : MonoBehaviour
{
    bool isGrounded = false; //para verificar se o objeto esta em contato com o solo
    public Transform GroundCheck1; // para determinar os limites/centro do objeto
    public LayerMask ground_layers; //a Layer que sera detectado o contato com o solo

    void FixedUpdate()
    {
        //verifica se o objeto criado sobrepÃµe-se com os 'ground_layers' num raio de 1 unidades
        isGrounded = Physics2D.OverlapCircle(GroundCheck1.position, 1, ground_layers);
        Debug.Log("Entrou em contato com o solo: " + isGrounded);
    }
}
