using Unity.VisualScripting;
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
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip somPasso;
    public bool tocandoPasso = false;
    private Animator animator;



    void Start()

    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }



    
        void Update()
        {
            // Movimento
            float horizontal = Input.GetAxisRaw("Horizontal");
            rb.linearVelocity = new Vector2(horizontal * velocidade, rb.linearVelocity.y);

            // Animação
            if (horizontal != 0)
                animator.SetBool("andando", true);
        
            else
                animator.SetBool("andando", false);
        animator.SetBool("Idle", true);

            animator.SetFloat("velocidade", horizontal);

            // Checagem de chão
            estaNoChao = Physics2D.OverlapCircle(checagemChao.position, raioChao, camadaChao);

            // Pulo
            if (Input.GetButtonDown("Jump") && estaNoChao)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
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


   



 

        

    
    




