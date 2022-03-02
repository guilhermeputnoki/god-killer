using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicStartarter : MonoBehaviour
{
    public AudioSource music;

    public BoxCollider2D bc;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            music.Play();
            bc.enabled = false;
        }  
    }
}
