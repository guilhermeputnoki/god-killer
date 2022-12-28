using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatTutorial : MonoBehaviour
{
    public BoxCollider2D bc;
    public BoxCollider2D bc1;
    public BoxCollider2D bc2;
    public BoxCollider2D bc3;
    public BoxCollider2D bc4;
    public BoxCollider2D bc5;
    public BoxCollider2D dialogueBc;

    private trainingDummy activate;

    private bool activateDialogue;
    private bool finalDialogue;
    public bool inicialDialog = true;

    void Start()
    {
        activate = FindObjectOfType<trainingDummy>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(Iniciate());
        }

        if(collision.gameObject.tag == "Player" && inicialDialog == false)
        {
            StartCoroutine(ActivateDialogue());
        }

        if(collision.gameObject.tag == "Player" && activateDialogue == true)
        {
            bc2.enabled = false;
            activate.alive = true;
        }

        if(collision.gameObject.tag == "Player" && activate.life <= 0f)
        {           
            if(inicialDialog == false)
            {
                bc5.enabled = true;
                StartCoroutine(ActivateDialogue2());
            }   
        }

         if(collision.gameObject.tag == "Player" && finalDialogue == true)
        {
            dialogueBc.enabled = false;
            bc4.enabled = false;
        }
    }

    public IEnumerator ActivateDialogue()
    {
        bc1.enabled = false;
        bc4.enabled = true;
        bc2.enabled = true;
        yield return new WaitForSeconds(1f);
        bc3.enabled = true;
        activateDialogue = true;
    }

    public IEnumerator ActivateDialogue2()
    {
        dialogueBc.enabled = true;
        yield return new WaitForSeconds(0.01f);
        bc5.enabled = false;
        finalDialogue = true;
    }

    public IEnumerator Iniciate()
    {
        bc1.enabled = true;
        yield return new WaitForSeconds(1f);
        bc.enabled = false;
        inicialDialog = false;
    }
}
