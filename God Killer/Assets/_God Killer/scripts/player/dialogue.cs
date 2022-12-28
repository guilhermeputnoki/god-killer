using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue : MonoBehaviour
{
    public Sprite profile;
    public Sprite profile2;
    public string[] speechTxt;
    public string characterName;
    public string characterName2;
    public bool longDialogue;
    public bool bossDialogue;
    public bool bossFinalDialogue;

    public dialogueControl dc;

    public void Activate()
    {
        dc.Speech(profile, profile2, speechTxt, characterName, characterName2);
    }

    
}
