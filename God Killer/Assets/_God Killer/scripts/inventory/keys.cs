using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keys : MonoBehaviour
{
    public inventory inv;

    void Start()
    {
        inv = FindObjectOfType<inventory>();
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inv.bossKey = 1;
            Destroy(gameObject);
        }
    }
}
