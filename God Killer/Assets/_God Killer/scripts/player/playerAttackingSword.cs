using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttackingSword : MonoBehaviour
{
    private playerAnimations playerAnim;

    private playerMovement playerMove;

    private dialogueControl dialogue;

    public bool AttackingUp;
    public bool AttackingDown;
    public bool AttackingRight;
    public bool AttackingLeft;
    public BoxCollider2D up;
    public BoxCollider2D down;
    public BoxCollider2D right;
    public BoxCollider2D left;

    void Start()
    {
        playerAnim = FindObjectOfType<playerAnimations>();
        playerMove = FindObjectOfType<playerMovement>();
        dialogue = FindObjectOfType<dialogueControl>();
    }

    void Update()
    {
        if(playerAnim.EquipSword == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                AttackingUp = true;
                AttackingDown = false;
                AttackingRight = false;
                AttackingLeft = false;
            }

            if (Input.GetKey(KeyCode.S))
            {
                AttackingUp = false;
                AttackingDown = true;
                AttackingRight = false;
                AttackingLeft = false;
            }

            if (Input.GetKey(KeyCode.D))
            {
                AttackingUp = false;
                AttackingDown = false;
                AttackingRight = true;
                AttackingLeft = false;
            }

            if (Input.GetKey(KeyCode.A))
            {
                AttackingUp = false;
                AttackingDown = false;
                AttackingRight = false;
                AttackingLeft = true;
            }
            if(dialogue.dontAttack == false)
            {
                if (AttackingUp == true && Input.GetKey(KeyCode.Mouse0))
                {
                    StartCoroutine(ColliderUp());
                }

                if (AttackingDown == true && Input.GetKey(KeyCode.Mouse0))
                {
                    StartCoroutine(ColliderDown());
                }

                if (AttackingRight == true && Input.GetKey(KeyCode.Mouse0))
                {
                    StartCoroutine(ColliderRight());
                }

                if (AttackingLeft == true && Input.GetKey(KeyCode.Mouse0))
                {
                    StartCoroutine(ColliderLeft());
                }
            }
        }
        
    }

    IEnumerator ColliderUp()
    {
        playerMove.speed = 0f;
        up.enabled = true;
        yield return new WaitForSeconds(1f);
        up.enabled = false;
        playerMove.speed = 5f;
    }

    IEnumerator ColliderDown()
    {
        playerMove.speed = 0f;
        down.enabled = true;
        yield return new WaitForSeconds(1f);
        down.enabled = false;
        playerMove.speed = 5f;
    }

    IEnumerator ColliderRight()
    {
        playerMove.speed = 0f;
        right.enabled = true;
        yield return new WaitForSeconds(1f);
        right.enabled = false;
        playerMove.speed = 5f;
    }

    IEnumerator ColliderLeft()
    {
        playerMove.speed = 0f;
        left.enabled = true;
        yield return new WaitForSeconds(1f);
        left.enabled = false;
        playerMove.speed = 5f;
    }
}
