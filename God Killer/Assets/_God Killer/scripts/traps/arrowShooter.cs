using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowShooter : MonoBehaviour
{
    public GameObject arrow;
    public Transform spawnArrow;
    public float deley;
    public AudioSource shoot;

    void Start()
    {
        InvokeRepeating("Shoot", 0, deley);
    }

    private void Shoot()
    {
        shoot.Play();
        Instantiate(arrow, spawnArrow.position, spawnArrow.rotation);
    }
}
