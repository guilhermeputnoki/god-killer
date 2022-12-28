using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimations : MonoBehaviour
{
    private equipamentBar equipBar;

    public playerLife HP;

    private dialogueControl dialogue;

    private Animator anim;

    private playerAttackingSword playerSwordAtt;

    public bool takingItem;

    public GameObject heartPieceOnHand;
    

    public bool EquipSword;

    void Start()
    {
        anim = GetComponent<Animator>();
        equipBar = FindObjectOfType<equipamentBar>();
        dialogue = FindObjectOfType<dialogueControl>();
    }

    void Update()
    {
        if(takingItem)
        {
            anim.SetBool("takingItem", true);
        }
        else
        {
            anim.SetBool("takingItem", false);
        }

        if(HP.life <= 0)
        {
            anim.SetBool("dead", true);
        }
        else
        {
            anim.SetBool("dead", false);
        }

        if(EquipSword == true)
        {
            anim.SetBool("sword", true);
            if(Input.GetKeyDown(KeyCode.Mouse0) && dialogue.dontAttack == false)
            {
                StartCoroutine(AttackSword());
            }
        }
        else
        {
            anim.SetBool("sword", false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "box")
        {
            anim.SetBool("pushing", true);
        }  
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "box")
        {
            anim.SetBool("pushing", false);
        }       
    }

    IEnumerator AttackSword()
    {
        anim.SetBool("useItem", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("useItem", false);
    }
}
