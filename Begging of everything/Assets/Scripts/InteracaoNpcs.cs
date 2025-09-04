using UnityEngine;
using UnityEngine.Rendering;

public class InteracaoNpcs : MonoBehaviour
{
    private bool jogadorPerto = false;
    public GerenciadorDialogo gerenciadorDialogo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gerenciadorDialogo.IniciarDialogo();
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            gerenciadorDialogo.npcCavaleiro = this.gameObject;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
        }
    }
}
