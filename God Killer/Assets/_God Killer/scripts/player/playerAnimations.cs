using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimations : MonoBehaviour
{
    public playerLife HP;

    private Animator anim;

    public bool takingItem;

    public GameObject heartPieceOnHand;

    void Start()
    {
        anim = GetComponent<Animator>();
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
}
