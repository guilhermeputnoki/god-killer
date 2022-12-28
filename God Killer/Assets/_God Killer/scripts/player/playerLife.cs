using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{
    public savePosition save;
    public playerMovement PM;

    public bool transition;

    public int life = 6;

    [SerializeField]
    private GameObject emptyHeart1;
    [SerializeField]
    private GameObject emptyHeart2;
    [SerializeField]
    private GameObject emptyHeart3;
    [SerializeField]
    private GameObject emptyHeart4;
    [SerializeField]
    private GameObject leftHeartPiece1;
    [SerializeField]
    private GameObject rightHeartPiece1;
    [SerializeField]
    private GameObject leftHeartPiece2;
    [SerializeField]
    private GameObject rightHeartPiece2;
    [SerializeField]
    private GameObject leftHeartPiece3;
    [SerializeField]
    private GameObject rightHeartPiece3;
    [SerializeField]
    private GameObject leftHeartPiece4;
    [SerializeField]
    private GameObject rightHeartPiece4;
    [SerializeField]
    private GameObject HealingParticle;

    public GameObject dilogueShild;

    public BoxCollider2D bc;
    public SpriteRenderer sprite;

    [SerializeField]
    private int heartPieceQ;

    private bool heartCompleate;
    public bool bossArena;

    public string sceneName;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();

        heartPieceQ = PlayerPrefs.GetInt("Quantity");

        if(PlayerPrefs.HasKey("lifes"))
        {
            life = PlayerPrefs.GetInt("lifes");
        }

        CheckLife();

        if(heartPieceQ > 0)
        {
            leftHeartPiece4.SetActive(true);
        }

        if(heartPieceQ > 1)
        {
            rightHeartPiece4.SetActive(true);

            heartCompleate = true;

            life += 4;

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

            PlayerPrefs.SetInt("lifes", life);

            StartCoroutine(TakeDamage());
        }

        if(collision.gameObject.tag == "heartPiece")
        {
            heartPieceQ += 1;

            PlayerPrefs.SetInt("Quantity", heartPieceQ);

            if(heartPieceQ > 0)
            {
                leftHeartPiece4.SetActive(true);
            }

            if(heartPieceQ > 1)
            {
                rightHeartPiece4.SetActive(true);

                heartCompleate = true;

                life = 4;

                CheckLife();
            }         
        }

        if(collision.gameObject.tag == "fountain")
        {
            if(life < 6 && !heartCompleate)
            {
                StartCoroutine(Heal());           
            }

            if(life == 6 && !heartCompleate)
            {
                HealingParticle.SetActive(false);
            }

            if(life < 8 && heartCompleate)
            {
                StartCoroutine(Heal());
            }

            if(life == 8 && heartCompleate)
            {
                HealingParticle.SetActive(false);
            }
            
            CheckLife();
        }
    }

    public void Dead()
    {   
        if(bossArena)
        {
            StartCoroutine(DieInBossArena());
        }
        else
        {
            StartCoroutine(Die());
        }    
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
        if(life == 8)
        {
            leftHeartPiece1.SetActive(true);
            rightHeartPiece1.SetActive(true);
            leftHeartPiece2.SetActive(true);
            rightHeartPiece2.SetActive(true);
            leftHeartPiece3.SetActive(true);
            rightHeartPiece3.SetActive(true);
            emptyHeart1.SetActive(false);
            emptyHeart2.SetActive(false);
            emptyHeart3.SetActive(false);
            emptyHeart4.SetActive(false);
            if(heartCompleate)
            {
                rightHeartPiece4.SetActive(true);
                leftHeartPiece4.SetActive(true);
            }
        }

        if(life == 7)
        {
            leftHeartPiece1.SetActive(true);
            rightHeartPiece1.SetActive(true);
            leftHeartPiece2.SetActive(true);
            rightHeartPiece2.SetActive(true);
            leftHeartPiece3.SetActive(true);
            rightHeartPiece3.SetActive(true);
            emptyHeart1.SetActive(false);
            emptyHeart2.SetActive(false);
            emptyHeart3.SetActive(false);
            if(heartCompleate)
            {
                emptyHeart4.SetActive(true);
                rightHeartPiece4.SetActive(false);
                leftHeartPiece4.SetActive(true);
            }
        }

        if(life == 6)
        {
            leftHeartPiece1.SetActive(true);
            rightHeartPiece1.SetActive(true);
            leftHeartPiece2.SetActive(true);
            rightHeartPiece2.SetActive(true);
            leftHeartPiece3.SetActive(true);
            rightHeartPiece3.SetActive(true);
            emptyHeart1.SetActive(false);
            emptyHeart2.SetActive(false);
            emptyHeart3.SetActive(false);
            if(heartCompleate)
            {
                emptyHeart4.SetActive(true);
                rightHeartPiece4.SetActive(false);
                leftHeartPiece4.SetActive(false);
            }
        }

        if(life == 5)
        {
            leftHeartPiece1.SetActive(true);
            rightHeartPiece1.SetActive(true);
            leftHeartPiece2.SetActive(true);
            rightHeartPiece2.SetActive(true);
            leftHeartPiece3.SetActive(true);
            rightHeartPiece3.SetActive(false);
            emptyHeart1.SetActive(false);
            emptyHeart2.SetActive(false);
            emptyHeart3.SetActive(true);
            if(heartCompleate)
            {
                emptyHeart4.SetActive(true);
                rightHeartPiece4.SetActive(false);
                leftHeartPiece4.SetActive(false);
            }
            
        }

        if(life == 4)
        {
            leftHeartPiece1.SetActive(true);
            rightHeartPiece1.SetActive(true);
            leftHeartPiece2.SetActive(true);
            rightHeartPiece2.SetActive(true);
            leftHeartPiece3.SetActive(false);
            rightHeartPiece3.SetActive(false);
            emptyHeart1.SetActive(false);
            emptyHeart2.SetActive(false);
            emptyHeart3.SetActive(true);
            if(heartCompleate)
            {
                emptyHeart4.SetActive(true);
                rightHeartPiece4.SetActive(false);
                leftHeartPiece4.SetActive(false);
            }
            
        }

        if(life == 3)
        {
            leftHeartPiece1.SetActive(true);
            rightHeartPiece1.SetActive(true);
            leftHeartPiece2.SetActive(true);
            rightHeartPiece2.SetActive(false);
            leftHeartPiece3.SetActive(false);
            rightHeartPiece3.SetActive(false);
            emptyHeart1.SetActive(false);
            emptyHeart2.SetActive(true);
            emptyHeart3.SetActive(true);
            if(heartCompleate)
            {
                emptyHeart4.SetActive(true);
                rightHeartPiece4.SetActive(false);
                leftHeartPiece4.SetActive(false);
            }
            
        }

        if(life == 2)
        {
            leftHeartPiece1.SetActive(true);
            rightHeartPiece1.SetActive(true);
            leftHeartPiece2.SetActive(false);
            rightHeartPiece2.SetActive(false);
            leftHeartPiece3.SetActive(false);
            rightHeartPiece3.SetActive(false);
            emptyHeart1.SetActive(false);
            emptyHeart2.SetActive(true);
            emptyHeart3.SetActive(true);
            if(heartCompleate)
            {
                emptyHeart4.SetActive(true);
                rightHeartPiece4.SetActive(false);
                leftHeartPiece4.SetActive(false);
            }
            
        }

        if(life == 1)
        {
            leftHeartPiece1.SetActive(true);
            rightHeartPiece1.SetActive(false);
            leftHeartPiece2.SetActive(false);
            rightHeartPiece2.SetActive(false);
            leftHeartPiece3.SetActive(false);
            rightHeartPiece3.SetActive(false);
            emptyHeart1.SetActive(true);
            emptyHeart2.SetActive(true);
            emptyHeart3.SetActive(true);
            if(heartCompleate)
            {
                emptyHeart4.SetActive(true);
                rightHeartPiece4.SetActive(false);
                leftHeartPiece4.SetActive(false);
            }
            
        }

        if(life <= 0)
        {
            leftHeartPiece1.SetActive(false);
            rightHeartPiece1.SetActive(false);
            leftHeartPiece2.SetActive(false);
            rightHeartPiece2.SetActive(false);
            leftHeartPiece3.SetActive(false);
            rightHeartPiece3.SetActive(false);
            emptyHeart1.SetActive(true);
            emptyHeart2.SetActive(true);
            emptyHeart3.SetActive(true);
            if(heartCompleate)
            {
                emptyHeart4.SetActive(true);
                rightHeartPiece4.SetActive(false);
                leftHeartPiece4.SetActive(false);
            }

            Dead();
        }
    }

    private void MaxMinimun()
    {
        if(life > 6 && !heartCompleate)
        {
            life = 6;
        }
        
        if(life > 8 && heartCompleate)
        {
            life = 8;
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
        PlayerPrefs.SetInt("lifes", life);
    }

    IEnumerator Die()
    {
        PM.speed = 0;
        yield return new WaitForSeconds(2f); 
        transition = true;
        yield return new WaitForSeconds(1f); 
        save.LoadPosition();
        life += 8;
        CheckLife();
        yield return new WaitForSeconds(1f); 
        transition = false;
        life += 8;
        PM.speed = 5;
    }

    IEnumerator DieInBossArena()
    {
        PM.speed = 0;
        yield return new WaitForSeconds(2f); 
        transition = true;
        yield return new WaitForSeconds(1f); 
        SceneManager.LoadScene(sceneName);  
        life += 8;
        CheckLife();
        yield return new WaitForSeconds(1f); 
        transition = false;
        life += 8;
        PM.speed = 5;
    }
}
