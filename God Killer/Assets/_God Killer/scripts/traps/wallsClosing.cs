using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallsClosing : MonoBehaviour
{
    private Animator anim;
    public BoxCollider2D bc;

    void Start()
    {
       anim = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.enabled = true;
            Destroy(bc, 1f);
        }
    }
}
