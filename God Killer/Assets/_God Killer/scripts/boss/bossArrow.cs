using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossArrow : MonoBehaviour
{
   [SerializeField]
    private float speed;

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}
