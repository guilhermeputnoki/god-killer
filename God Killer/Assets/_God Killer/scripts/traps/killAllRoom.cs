using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killAllRoom : MonoBehaviour
{
    public int enougthKills;
    public int currentKills;

    public bool activateEnemys;

    public gate gt;
    private BoxCollider2D bc;

    void Start()
    {
        GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(currentKills == enougthKills)
        {
            gt.killGate = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            activateEnemys = true;
            Destroy(bc);
        }
    }
}
