using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redMushroom : MonoBehaviour
{
    public Sight sightUp;
    public Sight sightDown;
    public Sight sightLeft;
    public Sight sightRight;
    public Sight attackUp;
    public Sight attackDown;
    public Sight attackLeft;
    public Sight attackRight;
    public float speed;
    public float attackSpeed;
    public int life = 6;
    private Transform target;
    private Animator anim;
    private BoxCollider2D bc;
    public bool alive;
    private SpriteRenderer sprite;
    private Vector2 attackTarget;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        attackTarget = new Vector2(target.transform.position.x, target.transform.position.y);
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        alive = true;
    }

    void Update()
    {
        if(alive == true)
        {
            speed = 1f;
            if(sightUp.range)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                anim.SetBool("up", true);
                if(attackUp.range)
                {
                    anim.SetBool("attack", true);
                    StartCoroutine(SpeedControl());
                    Attack();
                }  
                else
                {
                    anim.SetBool("attack", false);
                }  
            }  
            else
            {
                anim.SetBool("up", false);
            }   

            if(sightDown.range)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                anim.SetBool("down", true);
                if(attackDown.range)
                {
                    anim.SetBool("attack", true);
                    StartCoroutine(SpeedControl());
                    Attack();
                } 
                else
                {
                    anim.SetBool("attack", false);
                } 
            } 
            else
            {
                anim.SetBool("down", false);
            }  

            if(sightRight.range)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                anim.SetBool("right", true);
                if(attackRight.range)
                {
                    anim.SetBool("attack", true);
                    StartCoroutine(SpeedControl());
                    Attack();
                }
                else
                {
                    anim.SetBool("attack", false);
                }
            }
            else
            {
                anim.SetBool("right", false);
            }

            if(sightLeft.range)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                anim.SetBool("left", true);
                if(attackLeft.range)
                {
                    anim.SetBool("attack", true);
                    StartCoroutine(SpeedControl());
                    Attack();
                } 
                else
                {
                    anim.SetBool("attack", false);
                } 
            } 
            else
            {
                anim.SetBool("left", false);
            }

            if(life <= 0)
            {
                alive = false;
                speed = 0;
                anim.SetBool("dead", true);
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

    IEnumerator SpeedControl()
    {
        speed = 0;
        yield return new WaitForSeconds(1f);
        speed = 1;
    }

    public void Attack()
    {
        transform.position = Vector2.MoveTowards(transform.position, attackTarget, attackSpeed * Time.deltaTime);
        if(transform.position.x == attackTarget.x && transform.position.y == attackTarget.y)
        {
            StartCoroutine(SpeedControl());
        }
    }
}
