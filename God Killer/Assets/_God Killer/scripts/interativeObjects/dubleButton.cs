using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dubleButton : MonoBehaviour
{
    public gate Gate;

    private  Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Gate.buttonPressed += 1;
        anim.SetBool("presing", true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Gate.buttonPressed -= 1;
        anim.SetBool("presing", false);
    }
}
