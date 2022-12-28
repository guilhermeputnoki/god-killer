using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eletricDoor : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D bc;

    public eletricSwitch elSwitchPink;
    public eletricSwitch elSwitchBlue;
    public eletricSwitch elSwitchGreen;

    public bool pinkDoor;
    public bool blueDoor;
    public bool greenDoor;
    public bool dubleDoorPB;
    public bool tripleDoor;

    void Start()
    {
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(dubleDoorPB && elSwitchPink.active == true && elSwitchBlue.active == true)
        {
            bc.enabled = false;
            anim.enabled = true;
        }

        if(pinkDoor == true && elSwitchPink.active == true)
        {
            bc.enabled = false;
            anim.enabled = true;
        }
    }
}
