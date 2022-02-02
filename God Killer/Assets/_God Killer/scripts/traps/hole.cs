using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hole : MonoBehaviour
{
    public BoxCollider2D bc;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "box")
        {
            bc.enabled = false;
        }
    }
}
