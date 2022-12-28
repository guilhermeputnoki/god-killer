using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eletricGolem : MonoBehaviour
{
    
    public Sight sightUp;
    public Sight sightDown;
    public Sight sightLeft;
    public Sight sightRight;
    public Sight rangeUp;
    public Sight rangeDown;
    public Sight rangeLeft;
    public Sight rangeRight;
    public GameObject damageUp;
    public GameObject damageDown;
    public GameObject damageLeft;
    public GameObject damageRight;
    public float speed;
    public int life = 15;
    public eletricSwitch elSwitch;

    private Transform target;
    private Animator anim;
    private BoxCollider2D bc;
    public bool alive;
    private bool canMove;
    private SpriteRenderer sprite;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        canMove = true;
    }

    void Update()
    {
        if(elSwitch.active == true)
        {
            alive = true;
        }
        if(alive == true)
        {
            anim.SetBool("alive", true);
            speed = 1f;
            if(sightUp.range && canMove)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }   

            if(sightDown.range && canMove)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            } 

            if(sightRight.range && canMove)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            } 

            if(sightLeft.range && canMove)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }  

            if(sightUp.rangeUp)
            {
                anim.SetBool("up", true);
            }  
            else
            {
                anim.SetBool("up", false);
            }  

            if(sightDown.rangeDown)
            {
                anim.SetBool("down", true);
            }  
            else
            {
                anim.SetBool("down", false);
            }  

            if(sightRight.rangeRight)
            {
                anim.SetBool("right", true);
            }  
            else
            {
                anim.SetBool("right", false);
            }  

            if(sightLeft.rangeLeft)
            {
                anim.SetBool("left", true);
            }  
            else
            {
                anim.SetBool("left", false);
            } 

            if(rangeUp.rangeUp)
            {
                StartCoroutine(AttackUp());
            }  

            if(rangeDown.rangeDown)
            {
                StartCoroutine(AttackDown());
            }  

            if(rangeRight.rangeRight)
            {
                StartCoroutine(AttackRight());
            }   

            if(rangeLeft.rangeLeft)
            {
                StartCoroutine(AttackLeft());
            }  

            if(life <= 0)
            {
                alive = false;
                speed = 0;
                anim.SetBool("alive", false);
                bc.enabled = false;
                Destroy(gameObject, 1f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "playerDamage" && alive == true)
        {
            life -= 1;
            StartCoroutine(TakeDamage());
        }
    }

    IEnumerator TakeDamage()
    {
        sprite.color = new Color(1f, 0, 0, 1f); 
        yield return new WaitForSeconds(0.3f);
        sprite.color = new Color(1f, 1f, 1f, 1f);
        
        for(int i = 0; i < 4; i++)
        {
            sprite.enabled  = false;
            yield return new WaitForSeconds(0.15f);
            sprite.enabled  = true;
            yield return new WaitForSeconds(0.15f);
        }
    }
    IEnumerator AttackUp()
    {
        anim.SetBool("up", true);
        anim.SetBool("attacking", true);
        canMove = false;
        yield return new WaitForSeconds(1.3f);
        damageUp.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        damageUp.SetActive(false);
        anim.SetBool("attacking", false);
        yield return new WaitForSeconds(1f);
        canMove = true;
    }

    IEnumerator AttackDown()
    {
        anim.SetBool("down", true);
        anim.SetBool("attacking", true);
        canMove = false;
        yield return new WaitForSeconds(1.3f);
        damageDown.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        damageDown.SetActive(false);
        anim.SetBool("attacking", false);
        yield return new WaitForSeconds(1f);
        canMove = true;
    }

    IEnumerator AttackRight()
    {
        anim.SetBool("right", true);
        anim.SetBool("attacking", true);
        canMove = false;
        yield return new WaitForSeconds(1.3f);
        damageRight.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        damageRight.SetActive(false);
        anim.SetBool("attacking", false);
        yield return new WaitForSeconds(1f);
        canMove = true;
    }

    IEnumerator AttackLeft()
    {
        anim.SetBool("left", true);
        anim.SetBool("attacking", true);
        canMove = false;
        yield return new WaitForSeconds(1.3f);
        damageLeft.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        damageLeft.SetActive(false);
        anim.SetBool("attacking", false);
        yield return new WaitForSeconds(1f);
        canMove = true;
    }
}
