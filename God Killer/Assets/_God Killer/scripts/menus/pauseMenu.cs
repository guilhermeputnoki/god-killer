using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public GameObject menu;

    private bool activate;

    void Start()
    {
        activate = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            activate = !activate; 
        }

        if(activate)
        {
            menu.SetActive(true);
        }
        else
        {
            menu.SetActive(false);
        }
    }

    public void Resume()
    {
        activate = !activate;
    }
}
