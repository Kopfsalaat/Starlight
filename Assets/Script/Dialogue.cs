using System.Collections;
using UnityEngine;
using TMPro;

[System.Serializable] public class Dialogue
{
    [SerializeField] private string Name;

    [SerializeField] private Sprite Avatar;
    [SerializeField, TextArea] private string Dialogues;

    public Dialogue(string name, Sprite avatar, string dialogue)
    {
        Name = name;
        Avatar = avatar;
        Dialogues = dialogue;
    }

    public string GetName()
    {
        return Name;
    }

    public Sprite GetAvatar()
    {
        return Avatar;
    }

    public string GetDialogue()
    {
        return Dialogues;
    }
    
}