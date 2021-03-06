using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D bc;
    private SpriteRenderer sprite;
    public GameObject bridge;
    public AudioSource dragging;

    void Start()
    {
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "hole")
        {
            StartCoroutine(Bridge());
        }

        if(collision.gameObject.tag == "Player")
        {
            dragging.Play();
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            dragging.Pause();
        }
    }

    IEnumerator Bridge()
    {
        anim.enabled = true;
        yield return new WaitForSeconds(1f);
        bc.enabled = false;
        sprite.enabled = false;
        bridge.SetActive(true);
    }
}
