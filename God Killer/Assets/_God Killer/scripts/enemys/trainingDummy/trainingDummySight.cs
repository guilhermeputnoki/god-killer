using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainingDummySight : MonoBehaviour
{
    public bool range;
    public bool rangeUp;
    public bool rangeDown;
    public bool rangeRight;
    public bool rangeLeft;
    public bool up;
    public bool down;
    public bool left;
    public bool right;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && up == true)
        {
            range = true;
            rangeUp = true;
        }

        if(collision.gameObject.tag == "Player" && left == true)
        {
            range = true;
            rangeLeft = true;
        }

        if(collision.gameObject.tag == "Player" && right == true)
        {
            range = true;
            rangeRight = true;
        }

        if(collision.gameObject.tag == "Player" && down == true)
        {
            range = true;
            rangeDown = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            range = false;
        }

        if(collision.gameObject.tag == "Player" && up == true)
        {
            rangeUp = false;
        }

        if(collision.gameObject.tag == "Player" && left == true)
        {
            rangeLeft = false;
        }

        if(collision.gameObject.tag == "Player" && right == true)
        {
            rangeRight = false;
        }

        if(collision.gameObject.tag == "Player" && down == true)
        {
            rangeDown = false;
        }
    }
}
