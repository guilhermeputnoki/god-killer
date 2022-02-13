using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour
{
    public stoneLight SL;
    public stoneLight2 SL2;
    public stoneLight3 SL3;
    public stoneLight4 SL4;
    public stoneLight5 SL5;

    private Animator anim;

    public int buttonPressed = 0;
    public int buttonUnpressed = 0;

    public bool gateOneButton;
    public bool oneStoneLight;
    public bool fourStoneLight;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        OpenClose();
    }

    private void OpenClose()
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

        if(oneStoneLight == true && SL.on == true)
        {
            anim.SetBool("open3", true);
        }
        else
        {
            anim.SetBool("open3", false);
        }

        if(fourStoneLight && SL2.on == true)
        {
            if(SL3.on == true && SL4.on == true)
            {
                if(SL5.on == true)
                {
                    anim.SetBool("open4", true);
                }
                else
                {
                    anim.SetBool("open4", false);
                }
            }
            
        }
    }
}
