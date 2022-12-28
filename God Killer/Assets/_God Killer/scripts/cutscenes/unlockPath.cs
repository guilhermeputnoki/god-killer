using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockPath : MonoBehaviour
{
    private inventory inv;
    public Transform local;
    private Animator anim;
    public float speed;
    private bool startWalk;
    public GameObject diag;

    void Start()
    {
        inv = FindObjectOfType<inventory>();

        anim = GetComponent<Animator>();

        
    }

    void FixedUpdate()
    {
        if(startWalk == true)
        {
            anim.SetBool("walk", true);
            transform.position = Vector2.MoveTowards(transform.position, local.position, speed * Time.deltaTime);

            if(transform.position == local.transform.position)
            {
                anim.SetBool("walk", false);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && inv.basicSword == 1)
        {
            startWalk =true;
            diag.SetActive(false);
        }
    }
}
