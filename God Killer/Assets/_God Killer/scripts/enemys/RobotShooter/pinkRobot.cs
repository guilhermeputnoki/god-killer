using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinkRobot : MonoBehaviour
{
    public Sight sightUp;
    public Sight sightDown;
    public Sight sightLeft;
    public Sight sightRight;
    public Sight rangeUp;
    public Sight rangeDown;
    public Sight rangeLeft;
    public Sight rangeRight;
    public GameObject bulletUp;
    public GameObject bulletDown;
    public GameObject bulletLeft;
    public GameObject bulletRight;
    public float speed;
    public int life = 5;
    private Transform target;
    private Animator anim;
    private BoxCollider2D bc;
    public bool alive;
    private bool canMove;
    private SpriteRenderer sprite;
    private bool turnOn;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        canMove = true;
        turnOn = true;
    }

    void Update()
    {
        if(turnOn)
        {
            StartCoroutine(TurningOn());
        }
        if(alive == true)
        {
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

            if(rangeUp.range)
            {
                canMove = false;
                StartCoroutine(ShootingUp());
            }  

            if(rangeDown.range)
            {
                canMove = false;
                StartCoroutine(ShootingDown());
            }  

            if(rangeRight.range)
            {
                canMove = false;
                StartCoroutine(ShootingRight());
            }   

            if(rangeLeft.range)
            {
                canMove = false;
                StartCoroutine(ShootingLeft());
            }  

            if(life <= 0)
            {
                alive = false;
                speed = 0;
                canMove = false;
                anim.SetBool("alive", false);
                bc.enabled = false;
                Destroy(gameObject, 1f);
            }
        }
    }

    IEnumerator ShootingUp()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(bulletUp, transform.position,Quaternion.identity);
        yield return new WaitForSeconds(3f);
        canMove = true;
    }

    IEnumerator ShootingDown()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(bulletDown, transform.position,Quaternion.identity);
        yield return new WaitForSeconds(3f);
        canMove = true;
    }

    IEnumerator ShootingLeft()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(bulletLeft, transform.position,Quaternion.identity);
        yield return new WaitForSeconds(3f);
        canMove = true;
    }

    IEnumerator ShootingRight()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(bulletRight, transform.position,Quaternion.identity);
        yield return new WaitForSeconds(3f);
        canMove = true;
    }
    
    IEnumerator TurningOn()
    {
        anim.SetBool("active", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("active", false);
        turnOn = false;
    }
}
