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
        Direcao = new Vector2(Direcao.x, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.contacts.Length == 1 ) {
            Direcao = Vector2.Reflect(Direcao, collision.contacts[0].normal);
        }

        else
        {
            Vector2 normalMedia = Vector2.zero;
            foreach (var ponto in collision.contacts)
            {
                Direcao = (Direcao + ponto.normal) / 2;
            }
        }
        
        if (collision.gameObject.CompareTag("Block")){
            Destroy (collision.gameObject);
        }
        
        if (collision.gameObject.CompareTag("Ref"))
        {
            collision.gameObject.GetComponent<BlocoReforcado>().TomouHit();
            
        }
        
        if (collision.gameObject.CompareTag("GameOver")){
            GameManager.instance.GameOver();
            Destroy (this.gameObject);
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Direcao.normalized * Velocidade;
    }
}
