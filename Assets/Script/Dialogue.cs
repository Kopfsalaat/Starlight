using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private GameObject Guardado;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    private float typingTime= 0.05f;

    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;

    void Update()
    {
        if(isPlayerInRange && Input.GetButtonDown("Fire1"))
        {
            if(!didDialogueStart)
            {
                StartDialogue();
            }
            else if(dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
        }
    }
    public void StartDialogue()
    {
        didDialogueStart = true;
        didDialogueStart = true;
        Guardado.SetActive(false);
        DialoguePanel.SetActive(true);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            DialoguePanel.SetActive(false);
            Guardado.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach(char ch in dialogueLines[lineIndex])
        {
            dialogueText.text +=ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Si toy");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("No toy");
        }
    }
}
