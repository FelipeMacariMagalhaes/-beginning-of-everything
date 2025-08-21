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



    void Start()

    {

        rb = GetComponent<Rigidbody2D>();

    }



    void Update()

    {
      estaNoChao = Physics2D.OverlapCircle(checagemChao.position, raioChao, camadaChao);

        // Movimento horizontal 

        float horizontal = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(horizontal * velocidade, rb.linearVelocity.y);



        // Pular 

        if (Input.GetButtonDown("Jump") && estaNoChao)

        {

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);

        }
        if (estaNoChao && horizontal != 0 && !tocandoPasso)
        {
            StartCoroutine(TocarSomPasso());
            System.Collections.IEnumerator TocarSomPasso()
            {
                tocandoPasso = true;
                audioSource.PlayOneShot(somPasso);
                yield return new WaitForSeconds(somPasso.length);
                tocandoPasso = false;
            }

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


   



 

        

    
    




