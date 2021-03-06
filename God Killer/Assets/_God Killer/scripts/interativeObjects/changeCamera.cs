using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class changeCamera : MonoBehaviour
{
    public bool mainCamera = true;
    public bool bossFight;

    [SerializeField]
    private CinemachineVirtualCamera vcam1;

    [SerializeField]
    private CinemachineVirtualCamera vcam2;

    public BoxCollider2D bc;

    private void ChangePriority()
    {
        if(mainCamera)
        {
            vcam1.Priority = 0;
            vcam2.Priority = 1;
        }
        else
        {
            vcam1.Priority = 1;
            vcam2.Priority = 0;
        }

        mainCamera = !mainCamera;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ChangePriority();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(!bossFight)
            {
                ChangePriority();
            }
            else
            {
                bc.enabled = false;
            }   
        }
    }
}
