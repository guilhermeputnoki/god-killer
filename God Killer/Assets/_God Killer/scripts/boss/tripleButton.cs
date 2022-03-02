using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tripleButton : MonoBehaviour
{
    public bossFight bf;

    private  Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        bf.buttonPresseds += 1;
        anim.SetBool("presing", true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        bf.buttonPresseds -= 1;
        anim.SetBool("presing", false);
    }
}
