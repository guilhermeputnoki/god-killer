using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eletricSwitch : MonoBehaviour
{
    public bool active;
    public int points;
    public int enoughPower;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if(points == enoughPower)
        {
            active = true;
            sprite.enabled = false;
        }
    }
}
