using UnityEngine;

public class Scripts : MonoBehaviour
{
    [Header("Movimento")]

    public float velocidade = 5f;



    [Header("Pulo")]

    public float forcaPulo = 12f;

    public Transform checagemChao;

    public float raioChao = 0.2f;

    public LayerMask camadaChao;



    private Rigidbody2D rb;

    private bool estaNoChao;



    void Start()

    {

        rb = GetComponent<Rigidbody2D>();

    }



    void Update()

    {

        // Verifica se está no chão usando OverlapCircle 

        estaNoChao = Physics2D.OverlapCircle(checagemChao.position, raioChao, camadaChao);



        // Movimento horizontal 

        float horizontal = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horizontal * velocidade, rb.velocity.y);



        // Pular 

        if (Input.GetButtonDown("Jump") && estaNoChao)

        {

            rb.velocity = new Vector2(rb.velocity.x, forcaPulo);

        }

    }



    void OnDrawGizmosSelected()

    {

        // Desenha o círculo da checagem de chão no editor 

        if (checagemChao != null)

        {

            Gizmos.color = Color.green;

            Gizmos.DrawWireSphere(checagemChao.position, raioChao);

        }

    }

}


