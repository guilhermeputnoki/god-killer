using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MableExplosion : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(TimeOut());
    }

    void Update()
    {
        
    }

    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
