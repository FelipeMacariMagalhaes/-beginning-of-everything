using UnityEngine;
using TMPro;

public class GerenciadorDialogo : MonoBehaviour
{
    
    public TextMeshProUGUI textoNPC;
    public string[] falasNPC;
    public GameObject npcCavaleiro; 
    private int indiceFala = 0;
    public bool dialogoAtivo = false;
    



    void Start()
    {

    }

    void Update()
    {
        if (dialogoAtivo  && Input.GetKeyDown(KeyCode.Space))
        {
            AvancarFala();
        }
    }

    public void IniciarDialogo()
    {
        if (falasNPC.Length == 0 ) return;

        indiceFala = 0;
        
        AtualizarFalas();
        dialogoAtivo = true;


    }

    void AvancarFala()
    {
        indiceFala++;

        if (indiceFala < falasNPC.Length )
        {
            AtualizarFalas();

            if (indiceFala == falasNPC.Length - 1)
            {
                
            }
        }
        else
        {

            FecharDialogo();
        }
    }

    void AtualizarFalas()
    {
        textoNPC.text = falasNPC[indiceFala];
        


    }

    
    public void FecharDialogo()
    {
        dialogoAtivo = false;

        if (npcCavaleiro != null)
        {
            npcCavaleiro.SetActive(false); // Ou: Destroy(npcBruxa);
        }
    }
}
