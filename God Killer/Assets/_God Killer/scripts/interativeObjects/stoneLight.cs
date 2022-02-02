using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneLight : MonoBehaviour
{
    public Animator pillarAnim;
    public Animator pedestalAnim;

    public bool on;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "pedestal")
        {
            pillarAnim.enabled = true;
            pedestalAnim.enabled = true;

            pedestalAnim.SetBool("off", false);
            pillarAnim.SetBool("off", false);

            on = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "pedestal")
        {
            pedestalAnim.SetBool("off", true);
            pillarAnim.SetBool("off", true);

            on = false;
        }
    }
}
