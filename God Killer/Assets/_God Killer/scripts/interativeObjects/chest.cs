using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    public playerAnimations PlayerAnim;

    public dialogue Dialogue;

    public GameObject heartPiece;

    public Transform spawn;

    private Animator anim;

    public AudioSource open;
    public AudioSource colectHeart;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(Open());

            Dialogue.Activate();   
        }
    }

    IEnumerator Open()
    {
        anim.enabled = true;
        open.Play();
        yield return new WaitForSeconds(1f);
        Instantiate(heartPiece, spawn.position, spawn.rotation);
        PlayerAnim.takingItem = true;
        PlayerAnim.heartPieceOnHand.SetActive(true);
        colectHeart.Play();
    }
}
