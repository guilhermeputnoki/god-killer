using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EletricCapsuleGlass : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D bc;
    public int lifeCapsule = 3;

    public eletricSwitch elSwitch;
    public capsuleBody capsuleBd;
    public GameObject eletricChain;

    void Start()
    {
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();

        elSwitch.points +=1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "playerDamage")
        {
            lifeCapsule--;
        }

        if(lifeCapsule == 0)
        {
            anim.SetTrigger("destroy");
            capsuleBd.destroy = true;
            Destroy(eletricChain);
            Destroy(bc);
            elSwitch.points -=1;
            Destroy(anim, 1f);
            Destroy(this);
        }
        else if(lifeCapsule == 2)
        {
            anim.SetTrigger("broken1");
        }
        else if(lifeCapsule == 1)
        {
            anim.SetTrigger("broken2");
        }
    }
}
