using UnityEngine;

public class Scripts : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 5f;
    public float forcaPulo = 12f;
    public Transform checagemChao;
    public float raioChao = 0.2f;
    public LayerMask camadaChao;

    private Rigidbody2D rb;
    private bool estaNoChao;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip somPasso;
    private bool tocandoPasso = false;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Entrada do eixo horizontal
        float horizontal = Input.GetAxisRaw("Horizontal");

        // Aplica movimento usando linearVelocity (Unity nova)
        rb.linearVelocity = new Vector2(horizontal * velocidade, rb.linearVelocity.y);

        // Atualiza animação
        animator.SetFloat("speed", Mathf.Abs(horizontal));

        // Espelha sprite
        if (horizontal < 0)
            spriteRenderer.flipX = true;
        else if (horizontal > 0)
            spriteRenderer.flipX = false;

        // Verifica se está no chão
        estaNoChao = Physics2D.OverlapCircle(checagemChao.position, raioChao, camadaChao);
    }

    void OnDrawGizmosSelected()
    {
        if (checagemChao != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(checagemChao.position, raioChao);
        }
    }
}














