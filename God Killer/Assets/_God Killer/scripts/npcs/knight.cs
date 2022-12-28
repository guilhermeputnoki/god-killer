using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sprite;

    public float speed = 1f;
    public bool walkingHorizontal;

    public Transform[] pointsToMove;
    public int startPoint;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        transform.position = pointsToMove[startPoint].transform.position;
    }

    void Update()
    {
        if(walkingHorizontal == true)
        {
            if(startPoint == 0)
            {
                anim.SetBool("right", false);
                anim.SetBool("left", true);
                anim.SetBool("up", false);
                anim.SetBool("down", false);
            }
            else
            {
                anim.SetBool("right", true);
                anim.SetBool("left", false);
                anim.SetBool("up", false);
                anim.SetBool("down", false);
            }
        }
        else
        {
            if(startPoint == 0)
            {
                anim.SetBool("right", false);
                anim.SetBool("left", false);
                anim.SetBool("up", true);
                anim.SetBool("down", false);
            }
            else
            {
                anim.SetBool("right", false);
                anim.SetBool("left", false);
                anim.SetBool("up", false);
                anim.SetBool("down", true);
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointsToMove[startPoint].transform.position, speed * Time.deltaTime);

        if(transform.position == pointsToMove[startPoint].transform.position)
        {
            startPoint += 1;
        }

        if(startPoint == pointsToMove.Length)
        {
            startPoint = 0;
        }
    }
}
