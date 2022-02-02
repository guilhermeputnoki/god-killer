using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimations : MonoBehaviour
{
        private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
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
