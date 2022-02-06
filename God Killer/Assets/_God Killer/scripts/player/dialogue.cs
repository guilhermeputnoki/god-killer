using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxt;
    public string characterName;

    private dialogueControl dc;

    private void Start()
    {
        dc = FindObjectOfType<dialogueControl>();
    }

    public void Activate()
    {
        dc.Speech(profile, speechTxt, characterName);
    }
}
