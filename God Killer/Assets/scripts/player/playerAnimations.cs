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

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        anim.SetFloat("Horizontal", move.x);
        anim.SetFloat("Vertical", move.y);
        anim.SetFloat("Speed", move.magnitude);

        
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Up", true);
            anim.SetBool("Down", false);
            anim.SetBool("Right", false);
            anim.SetBool("Left", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("Up", false);
            anim.SetBool("Down", false);
            anim.SetBool("Right", false);
            anim.SetBool("Left", true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("Up", false);
            anim.SetBool("Down", true);
            anim.SetBool("Right", false);
            anim.SetBool("Left", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Up", false);
            anim.SetBool("Down", false);
            anim.SetBool("Right", true);
            anim.SetBool("Left", false);
        }
    }
}
