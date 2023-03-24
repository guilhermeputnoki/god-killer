using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsuleBody : MonoBehaviour
{
    private Animator anim;
    public bool destroy;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(destroy == true)
        {
            anim.SetTrigger("broke");
            Destroy(anim, 1f);
            Destroy(this);
        }
    }
}
