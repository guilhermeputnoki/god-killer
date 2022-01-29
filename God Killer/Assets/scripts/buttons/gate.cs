using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour
{
    private Animator anim;

    public int buttonPressed = 0;
    public int buttonUnpressed = 0;

    public bool gateOneButton;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(buttonPressed == 4)
        {
            anim.SetBool("open", true);
        }
        else
        {
            anim.SetBool("open", false);
        }

        if(buttonUnpressed < 0 && gateOneButton)
        {
            anim.SetBool("open2", false);
        }
        else
        {
            anim.SetBool("open2", true);
        }
    }
}
