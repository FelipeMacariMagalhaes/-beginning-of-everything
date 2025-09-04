using UnityEngine;
using TMPro;

public class GerenciadorDialogo : MonoBehaviour
{

    public GameObject dialogueUI; // Painel de diálogo
    public TextMeshProUGUI dialogueText;     // Texto da fala do NPC
    [TextArea(2, 5)]
    public string[] dialogueLines; // Falas do NPC

    private bool isPlayerNear = true;
    private int currentLine = 0;
    private bool isDialogueActive = false;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (!isDialogueActive)
            {
                StartDialogue();
            }
            else
            {
                NextLine();
            }
        }
    }

    void StartDialogue()
    {
        isDialogueActive = true;
        currentLine = 0;
        dialogueUI.SetActive(true);
        dialogueText.text = dialogueLines[currentLine];
    }

    void NextLine()
    {
        currentLine++;
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        dialogueUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = false;
            EndDialogue(); // Fecha o diálogo se sair de perto
        }
    }
}