using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipamentBar : MonoBehaviour
{
    private inventory inv;
    private playerAnimations playerAnim;

    public GameObject xSelected;
    public GameObject cSelected;
    public GameObject qSelected;

    public bool xSelecting;
    public bool cSelecting;
    public bool qSelecting;

    public GameObject sword;

    void Start()
    {
        inv = FindObjectOfType<inventory>();
        playerAnim = FindObjectOfType<playerAnimations>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && xSelecting == false)
        {
            xSelected.SetActive(true);
            cSelected.SetActive(false);
            qSelected.SetActive(false);
            xSelecting = true;
            cSelecting = false;
            qSelecting = false;
            if(inv.equipedItemX == sword)
            {
                playerAnim.EquipSword = true;
            }
            if(inv.equipedItemC == sword)
            {
                playerAnim.EquipSword = false;
            }
            if(inv.equipedItemQ == sword)
            {
                playerAnim.EquipSword = false;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            xSelected.SetActive(false);
            cSelected.SetActive(false);
            qSelected.SetActive(false);
            xSelecting = false;
            cSelecting = false;
            qSelecting = false;
            if(inv.equipedItemX == sword)
            {
                playerAnim.EquipSword = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.C) && cSelecting == false)
        {
            xSelected.SetActive(false);
            cSelected.SetActive(true);
            qSelected.SetActive(false);
            xSelecting = false;
            cSelecting = true;
            qSelecting = false;
            if(inv.equipedItemC == sword)
            {
                playerAnim.EquipSword = true;
            }
            if(inv.equipedItemX == sword)
            {
                playerAnim.EquipSword = false;
            }
            if(inv.equipedItemQ == sword)
            {
                playerAnim.EquipSword = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            xSelected.SetActive(false);
            cSelected.SetActive(false);
            qSelected.SetActive(false);
            xSelecting = false;
            cSelecting = false;
            qSelecting = false;
            if(inv.equipedItemC == sword)
            {
                playerAnim.EquipSword = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && qSelecting == false)
        {
            xSelected.SetActive(false);
            cSelected.SetActive(false);
            qSelected.SetActive(true);
            xSelecting = false;
            cSelecting = false;
            qSelecting = true;
            if(inv.equipedItemQ == sword)
            {
                playerAnim.EquipSword = true;
            }
            if(inv.equipedItemX == sword)
            {
                playerAnim.EquipSword = false;
            }
            if(inv.equipedItemC == sword)
            {
                playerAnim.EquipSword = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            xSelected.SetActive(false);
            cSelected.SetActive(false);
            qSelected.SetActive(false);
            xSelecting = false;
            cSelecting = false;
            qSelecting = false;
            if(inv.equipedItemQ == sword)
            {
                playerAnim.EquipSword = false;
            }
        }
    }
}
