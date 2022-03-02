using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerOrbUp : MonoBehaviour
{
    public GameObject explosion;
    public float deley;
    public AudioSource shoot;

    private Transform player;

    void Start()
    {
        InvokeRepeating("Shoot", 0, deley);

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        
    }

    private void Shoot()
    {
        shoot.Play();
        Instantiate(explosion, player.position, player.rotation);
        Destroy(gameObject, 2);
    }
}
