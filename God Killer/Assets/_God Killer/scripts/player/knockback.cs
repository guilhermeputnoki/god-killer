using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("damage1"))
        {
            Rigidbody2D damage1 = collision.GetComponent<Rigidbody2D>();
            if(damage1 != null)
            {
                damage1.isKinematic = false;
                Vector2 difference = damage1.transform.position - transform.position;
                difference = difference.normalized * thrust;
                damage1.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(damage1));
            }
        }
    }

    public IEnumerator KnockCo(Rigidbody2D damage1)
    {
        if(damage1 != null)
        {
            yield return new WaitForSeconds(knockTime);
            damage1.velocity = Vector2.zero;
            damage1.isKinematic = true;
        }
    }
}
