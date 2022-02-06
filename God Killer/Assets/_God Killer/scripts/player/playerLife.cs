using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLife : MonoBehaviour
{
    public int life = 3;

    [SerializeField]
    private GameObject heart1;
    [SerializeField]
    private GameObject heart2;
    [SerializeField]
    private GameObject heart3;
    [SerializeField]
    private GameObject emptyHeart1;
    [SerializeField]
    private GameObject emptyHeart2;
    [SerializeField]
    private GameObject emptyHeart3;
    [SerializeField]
    private GameObject emptyHeart4;
    [SerializeField]
    private GameObject leftHeartPiece;
    [SerializeField]
    private GameObject rightHeartPiece;
    [SerializeField]
    private GameObject HealingParticle;

    private BoxCollider2D bc;
    public SpriteRenderer sprite;

    [SerializeField]
    private int heartPieceQ;

    private bool heartCompleate;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();

        heartPieceQ = PlayerPrefs.GetInt("Quantity");

        if(heartPieceQ > 0)
            {
                leftHeartPiece.SetActive(true);
            }

            if(heartPieceQ > 1)
            {
                rightHeartPiece.SetActive(true);

                heartCompleate = true;

                life = 4;

                CheckLife();
            }  
    }

    void Update()
    {
        MaxMinimun();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "damage1")
        {
            life -= 1;

            CheckLife();

            StartCoroutine(TakeDamage());
        }

        if(collision.gameObject.tag == "heartPiece")
        {
            heartPieceQ += 1;

            PlayerPrefs.SetInt("Quantity", heartPieceQ);

            if(heartPieceQ > 0)
            {
                leftHeartPiece.SetActive(true);
            }

            if(heartPieceQ > 1)
            {
                rightHeartPiece.SetActive(true);

                heartCompleate = true;

                life = 4;
            }         
        }

        if(collision.gameObject.tag == "fountain")
        {
            if(life < 3 && !heartCompleate)
            {
                StartCoroutine(Heal());           
            }

            if(life == 3 && !heartCompleate)
            {
                HealingParticle.SetActive(false);
            }

            if(life < 4 && heartCompleate)
            {
                StartCoroutine(Heal());
            }

            if(life == 4 && heartCompleate)
            {
                HealingParticle.SetActive(false);
            }
            
            CheckLife();
        }
    }

    public void Dead()
    {
        Destroy(gameObject , 1);
    }

    IEnumerator TakeDamage()
    {
        bc.enabled = false;
        sprite.color = new Color(1f, 0, 0, 1f); 
        yield return new WaitForSeconds(0.3f);
        sprite.color = new Color(1f, 1f, 1f, 1f);
        
        for(int i = 0; i < 7; i++)
        {
            sprite.enabled  = false;
            yield return new WaitForSeconds(0.15f);
            sprite.enabled  = true;
            yield return new WaitForSeconds(0.15f);
        }

        bc.enabled = true;
    }

    private void CheckLife()
    {
        if(life == 4)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            emptyHeart1.SetActive(false);
            emptyHeart2.SetActive(false);
            emptyHeart3.SetActive(false);
            emptyHeart4.SetActive(false);
            if(heartCompleate)
            {
                rightHeartPiece.SetActive(true);
                leftHeartPiece.SetActive(true);
            }
        }

        if(life == 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            emptyHeart1.SetActive(false);
            emptyHeart2.SetActive(false);
            emptyHeart3.SetActive(false);
            if(heartCompleate)
            {
                emptyHeart4.SetActive(true);
                rightHeartPiece.SetActive(false);
                leftHeartPiece.SetActive(false);
            }
        }

        if(life == 2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
            emptyHeart1.SetActive(false);
            emptyHeart2.SetActive(false);
            emptyHeart3.SetActive(true);
            if(heartCompleate)
            {
                emptyHeart4.SetActive(true);
                rightHeartPiece.SetActive(false);
                leftHeartPiece.SetActive(false);
            }
            
        }

        if(life == 1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
            emptyHeart1.SetActive(false);
            emptyHeart2.SetActive(true);
            emptyHeart3.SetActive(true);
            if(heartCompleate)
            {
                emptyHeart4.SetActive(true);
                rightHeartPiece.SetActive(false);
                leftHeartPiece.SetActive(false);
            }
        }

        if(life <= 0)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
            emptyHeart1.SetActive(true);
            emptyHeart2.SetActive(true);
            emptyHeart3.SetActive(true);
            if(heartCompleate)
            {
                emptyHeart4.SetActive(true);
                rightHeartPiece.SetActive(false);
                leftHeartPiece.SetActive(false);
            }

            Dead();
        }
    }

    private void MaxMinimun()
    {
        if(life > 3 && !heartCompleate)
        {
            life = 3;
        }
        
        if(life > 4 && heartCompleate)
        {
            life = 4;
        }
    }

    IEnumerator Heal()
    {
        HealingParticle.SetActive(true);
        yield return new WaitForSeconds(1f);
        life += 1;
        CheckLife();
        yield return new WaitForSeconds(1f);
        life += 1;
        CheckLife();
        yield return new WaitForSeconds(1f);
        life += 1;
        CheckLife();
        HealingParticle.SetActive(false);
    }
}
