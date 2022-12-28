using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class changeCamera : MonoBehaviour
{
    public bool mainCamera = true;
    public bool bossFight;
    public bool needConsition;
    public eletricSwitch condition;

    [SerializeField]
    private CinemachineVirtualCamera vcam1;

    [SerializeField]
    private CinemachineVirtualCamera vcam2;

    public BoxCollider2D bc;

    private void ChangePriority()
    {
        if(needConsition == true)
        {
            if(condition.active == false)
            {
                bc.enabled = false;
            }   
            if(condition.active == true)
            {
                bc.enabled = true;
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
                StartCoroutine(TurnOf());
            }  
        }
        else
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

    IEnumerator TurnOf()
    {
        yield return new WaitForSeconds(1f);
        bc.enabled = false;
        yield return new WaitForSeconds(1f);
    }
}
