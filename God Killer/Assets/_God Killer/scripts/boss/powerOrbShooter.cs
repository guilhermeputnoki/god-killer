using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerOrbShooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnBullet;
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
        Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
        Destroy(gameObject, 2);
    }
}
