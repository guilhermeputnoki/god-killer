using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadPlayerPosition : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.GetComponent<savePosition>().SavePosition(); 
        }
    }
}
