using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTeleport : MonoBehaviour
{
    private teleporter tp;

    private changeScene cs;

    void Start()
    {
        tp = FindObjectOfType<teleporter>();
        cs = FindObjectOfType<changeScene>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "teleporter1")
        {
            StartCoroutine(Teleport1());         
        }

        if(collision.gameObject.tag == "teleporter2")
        {
            StartCoroutine(Teleport2());   
        }
    }

    IEnumerator Teleport1()
    {
        cs.anim.SetBool("action", true);
        cs.anim.SetBool("on", true);
        yield return new WaitForSeconds(1f);
        transform.position = tp.tp2.transform.position;
        transform.rotation = tp.tp2.transform.rotation;
        yield return new WaitForSeconds(1f); 
        cs.anim.SetBool("on", false);
        cs.anim.SetBool("action", false);
    }

    IEnumerator Teleport2()
    {
        cs.anim.SetBool("action", true);
        cs.anim.SetBool("on", true);
        yield return new WaitForSeconds(1f);
        transform.position = tp.tp1.transform.position;
        transform.rotation = tp.tp1.transform.rotation; 
        yield return new WaitForSeconds(1f); 
        cs.anim.SetBool("on", false);
        cs.anim.SetBool("action", false);
    }
}
