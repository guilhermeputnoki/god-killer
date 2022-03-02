using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerOrbDown : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;
    public float deley;
    public AudioSource shoot;

    void Start()
    {
        InvokeRepeating("Shoot", 0, deley);
    }

    void Update()
    {
        
    }

    private void Shoot()
    {
        shoot.Play();
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        Destroy(gameObject, 1);
    }   
}
