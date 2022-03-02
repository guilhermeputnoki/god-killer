using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueControl : MonoBehaviour
{
    public playerLife HP;
    public dialogue Dialogue;
    private playerAnimations playerAnim;
    private playerMovement playerMove;

    public GameObject dialogueObj;
    public Image profile;
    public Image profile2;
    public Text speechText;
    public Text characterNameText;
    public Text characterNameText2;

    public float typingSpeed;
    private string[] sentences;
    private int index;

    public bool manualActive;
    public bool secondPerson;
    public bool StartBossFight;
    public bool bossArena; 

    private void Start()
    {
        playerAnim = FindObjectOfType<playerAnimations>();
        playerMove = FindObjectOfType<playerMovement>();
    }

    public void Update()
    {
        if(secondPerson)
        {
            profile2.enabled = true;
            profile.enabled = false;
            characterNameText2.enabled = true;
            characterNameText.enabled = false;
        }
        else
        {
            profile2.enabled = false;
            profile.enabled = true;
            characterNameText2.enabled = false;
            characterNameText.enabled = true;
        }
    }

    public void Speech(Sprite prof, Sprite prof2, string[] txt, string name, string name2)
    {
        dialogueObj.SetActive(true);
        profile.sprite = prof;
        profile2.sprite = prof2;
        sentences = txt;
        characterNameText.text = name;
        characterNameText2.text = name2;
        StartCoroutine(TypeSentence());
        playerMove.speed = 0;
        if(bossArena)
        {
            HP.bc.enabled = false;
        }
    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
    }

    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length -1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
                if(Dialogue.longDialogue)
                {
                    secondPerson = !secondPerson;
                }
            }
            else
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                playerAnim.takingItem = false;
                playerAnim.heartPieceOnHand.SetActive(false);
                playerMove.speed = 5;
                HP.bc.enabled = true;
                if(Dialogue.bossDialogue)
                {
                    StartBossFight = true;
                }
            }
        }
    }
}
