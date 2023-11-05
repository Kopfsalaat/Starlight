using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Chat : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] public List<Dialogue> dialogueLines;
    [SerializeField] private GameObject actionMark;
    private Dialogue actualDialogue;
    private Image dialogueImage;
    private TextMeshProUGUI dialogueText;
    private TextMeshProUGUI dialogueName;
    private GameObject player;
    private float typingTime= 0.05f;
    private bool isPlayerInRange;
    private bool isDialogueActive;
    private bool didDialogueStart;
    private int lineIndex;

    void Start()
    {
        dialogueImage = Helpers.FindChildWithName(dialoguePanel, "DialogueImage").GetComponent<Image>();
        dialogueText = Helpers.FindChildWithName(dialoguePanel, "DialogueText").GetComponent<TextMeshProUGUI>();
        dialogueName = Helpers.FindChildWithName(dialoguePanel, "DialogueName").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(isPlayerInRange)
        {
            if(Input.GetKeyDown("e"))
            {
                if(!didDialogueStart)
                {
                    StartDialogue();
                }
                else if(dialogueText.text == actualDialogue.GetDialogue())
                {
                    NextDialogueLine();
                }
            }
            if(Input.GetKeyDown("q"))
            {
                if(dialogueText.text != actualDialogue.GetDialogue())
                {
                    StopAllCoroutines();
                    dialogueText.text = actualDialogue.GetDialogue();
                }
            }
        }
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            isDialogueActive = true;
            isPlayerInRange = true;
            if(actionMark != null)
            {
                actionMark.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if(actionMark != null)
            {
                actionMark.SetActive(false);
            }
        }
    }

    public void StartDialogue()
    {
        didDialogueStart = true;
        lineIndex = 0;
        actualDialogue = dialogueLines[lineIndex];
        dialogueName.text = actualDialogue.GetName();
        dialogueImage.sprite = actualDialogue.GetAvatar();
        dialoguePanel.SetActive(true);
        if(actionMark != null)
        {
            actionMark.SetActive(false);   
        }
        player.GetComponent<Player>().DisableMovement();
        player.GetComponent<Player>().StopMovement();
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        if(lineIndex < dialogueLines.Count -1)
        {
            lineIndex++;
            actualDialogue = dialogueLines[lineIndex];
            dialogueName.text = actualDialogue.GetName();
            dialogueImage.sprite = actualDialogue.GetAvatar();
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            isDialogueActive = false;
            dialoguePanel.SetActive(false);
            didDialogueStart = false;
            player.GetComponent<Player>().EnableMovement();
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach(char ch in actualDialogue.GetDialogue().ToCharArray())
        {
            dialogueText.text +=ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    public bool GetIsDialogueActive()
    {
        return isDialogueActive;
    }
}
