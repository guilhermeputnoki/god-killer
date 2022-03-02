using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossFight : MonoBehaviour
{
    public dialogueControl DC;
    public dialogue StartDialogue;
    public changeScene EndTransition;

    private BoxCollider2D bc;
    
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;
    public GameObject button8;
    public GameObject button9;

    public GameObject Arrow1;
    public GameObject Arrow2;
    public GameObject Arrow3;

    public bool secondLevel;
    public bool thirdLevel;

    public int buttonPresseds;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(DC.StartBossFight)
        {
            StartCoroutine(Starting());
        }

        if(buttonPresseds == 6 && !thirdLevel)
        {
            StartCoroutine(ChangeButtons1());
        }

        if(buttonPresseds == 7 && secondLevel)
        {
            StartCoroutine(ChangeButtons2());
        }

        if(buttonPresseds == 6 && thirdLevel)
        {
            StartCoroutine(ChangeButtons3());
        }
    }

    public IEnumerator Starting()
    {
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        yield return new WaitForSeconds(0.001f);
        DC.StartBossFight = false;
        StartDialogue.bossDialogue = false;
    }

    public IEnumerator ChangeButtons1()
    {
        Arrow1.SetActive(true);
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(true);
        button5.SetActive(true);
        button6.SetActive(true);
        yield return new WaitForSeconds(2f);
        secondLevel = true;
        buttonPresseds = 1;
    }

    public IEnumerator ChangeButtons2()
    {
        Arrow2.SetActive(true);
        button4.SetActive(false);
        button5.SetActive(false);
        button6.SetActive(false);
        button7.SetActive(true);
        button8.SetActive(true);
        button9.SetActive(true);
        yield return new WaitForSeconds(2f);
        thirdLevel = true;
        buttonPresseds = 0;
    }

    public IEnumerator ChangeButtons3()
    {
        Arrow3.SetActive(true);
        yield return new WaitForSeconds(0.001f);
        button4.SetActive(false);
        button5.SetActive(false);
        button6.SetActive(false);
        button7.SetActive(true);
        button8.SetActive(true);
        button9.SetActive(true);
        yield return new WaitForSeconds(10f);
        bc.enabled = true;
    }

    public IEnumerator End()
    {
        EndTransition.anim.SetBool("theEnd", true);
        yield return new WaitForSeconds(2f);
        EndTransition.StartTransition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(End());
        }
    }
}

