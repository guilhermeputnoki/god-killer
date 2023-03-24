using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    private playerAnimations PlayerAnim;

    public dialogue Dialogue;

    public GameObject heartPiece;

    public Transform spawn;

    private Animator anim;

    public AudioSource open;
    public AudioSource colect;

    public bool colectBossKey;
    public bool colectHeart;

    void Start()
    {
        anim = GetComponent<Animator>();
        PlayerAnim = FindObjectOfType<playerAnimations>();
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
        if(colectHeart == true)
        {
            PlayerAnim.heartPieceOnHand.SetActive(true);
        }
        if(colectBossKey == true)
        {
            PlayerAnim.bossKeyOnHand.SetActive(true);
        }
        colect.Play();
    }
}
