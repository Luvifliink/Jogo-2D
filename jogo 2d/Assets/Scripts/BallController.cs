using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{

    private Rigidbody2D rb;
    public Vector2 Direcao;
    public int Velocidade = 7;
    
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
        Direcao = Random.insideUnitCircle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Direcao = Vector2.Reflect(Direcao, collision.contacts[0].normal)
        if (collision.gameObject.CompareTag("Block")){
            Destroy (collision.gameObject);
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Direcao.normalized * Velocidade;
    }
}
