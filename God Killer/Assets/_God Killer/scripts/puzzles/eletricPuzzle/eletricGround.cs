using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eletricGround : MonoBehaviour
{
    public bool on;
    public eletricSwitch elSwitch;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "box")
        {
            on = !on;
            if(on == true)
            {
                elSwitch.points += 1;
                sprite.enabled = false;
            }
            else
            {
                elSwitch.points -= 1;
                sprite.enabled = true;
            }
            
        }
    }
}
