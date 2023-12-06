using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public int Velocidade = 10;
    public Vector2 Direcao;
    
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Direcao = new Vector2(x,0);
    }

    private void FixedUpdate()
    {
        rb.velocity = Direcao.normalized * Velocidade;
    }
}
