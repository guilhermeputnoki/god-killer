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

    private BoxCollider2D bc;
    public SpriteRenderer sprite;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "damage1")
        {
            life -= 1;

            DecreaseLife();

            StartCoroutine(TakeDamage());
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

    private void DecreaseLife()
    {
        if(life == 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            emptyHeart1.SetActive(false);
            emptyHeart2.SetActive(false);
            emptyHeart3.SetActive(false);
        }

        if(life == 2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
            emptyHeart1.SetActive(false);
            emptyHeart2.SetActive(false);
            emptyHeart3.SetActive(true);
            
        }

        if(life == 1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
            emptyHeart1.SetActive(false);
            emptyHeart2.SetActive(true);
            emptyHeart3.SetActive(true);
        }

        if(life <= 0)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
            emptyHeart1.SetActive(true);
            emptyHeart2.SetActive(true);
            emptyHeart3.SetActive(true);

            Dead();
        }
    }
}
