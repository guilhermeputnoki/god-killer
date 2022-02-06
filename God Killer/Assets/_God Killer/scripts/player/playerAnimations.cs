using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimations : MonoBehaviour
{
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
