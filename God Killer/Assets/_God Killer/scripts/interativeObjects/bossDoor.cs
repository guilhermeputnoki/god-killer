using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossDoor : MonoBehaviour
{
    public inventory inv;
    private Animator anim;
    public BoxCollider2D bc;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && inv.bossKey == 1)
        {
            anim.enabled = true;
            bc.enabled = false;
            inv.bossKey = 0;
        }
    }
}
