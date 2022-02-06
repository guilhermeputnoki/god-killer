using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCollision : MonoBehaviour
{
    public dialogue Dialogue;

    private BoxCollider2D bc;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            bc.enabled = false;
            Dialogue.Activate();
        }
    }
}
