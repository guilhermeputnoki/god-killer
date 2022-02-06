using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueControl : MonoBehaviour
{
    private playerAnimations playerAnim;
    private playerMovement playerMove;

    public GameObject dialogueObj;
    public Image profile;
    public Text speechText;
    public Text characterNameText;

    public float typingSpeed;
    private string[] sentences;
    private int index;

    public bool manualActive;

    private void Start()
    {
        playerAnim = FindObjectOfType<playerAnimations>();
        playerMove = FindObjectOfType<playerMovement>();
    }

    private void Update()
    {
        if(manualActive)
        {
            NextSentence();
        }
    }

    public void Speech(Sprite prof, string[] txt, string name)
    {
        dialogueObj.SetActive(true);
        profile.sprite = prof;
        sentences = txt;
        characterNameText.text = name;
        StartCoroutine(TypeSentence());
        playerMove.speed = 0;
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
                
            }
            else
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                playerAnim.takingItem = false;
                playerAnim.heartPieceOnHand.SetActive(false);
                playerMove.speed = 5;
            }
        }
    }
}
