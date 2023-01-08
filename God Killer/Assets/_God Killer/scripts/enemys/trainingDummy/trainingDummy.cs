using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainingDummy : MonoBehaviour
{
    public Sight sightUp;
    public Sight sightDown;
    public Sight sightLeft;
    public Sight sightRight;
    public float speed;
    public int life = 4;
    private Transform target;
    private Animator anim;
    private BoxCollider2D bc;
    public bool alive;
    private SpriteRenderer sprite;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim.enabled = false;
    }

    void Update()
    {
        if(alive == true)
        {
            anim.enabled = true;
            speed = 1f;
            if(sightUp.range)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }   

            if(sightDown.range)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            } 

            if(sightRight.range)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            } 

            if(sightLeft.range)
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
}
