using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectItens : MonoBehaviour
{
    private inventory inv;

    [SerializeField]
    private bool trainingSword;

    void Start()
    {
        inv = FindObjectOfType<inventory>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && trainingSword == true)
        {
            inv.basicSword += 1;
            Destroy(gameObject, 1);
        }
    }
}
