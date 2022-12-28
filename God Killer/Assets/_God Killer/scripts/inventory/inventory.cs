using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    private playerMovement playerMove;

    public GameObject inventoryOn;

    public GameObject selectedItem;
    public GameObject equipedItemX;
    public GameObject equipedItemC;
    public GameObject equipedItemQ;

    public GameObject trainingSword;

    private bool activate;
    public bool equipping;
    public int basicSword;

    void Start()
    {
        activate = false;
        playerMove = FindObjectOfType<playerMovement>();

        basicSword = PlayerPrefs.GetInt("BasicSword");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            activate = !activate; 
        }

        if(activate)
        {
            inventoryOn.SetActive(true);
            playerMove.speed = 0f;
            PlayerPrefs.SetInt("BasicSword", basicSword);
        }
        else
        {
            inventoryOn.SetActive(false);
            playerMove.speed = 5f;
        }
        if (Input.GetKeyDown(KeyCode.X) && equipping == true)
        {
            Transform aux = selectedItem.transform.parent;
            selectedItem.transform.SetParent(equipedItemX.transform.parent);
            equipedItemX.transform.SetParent(aux);
            equipping = false;
            equipedItemX = selectedItem;
        }

        if (Input.GetKeyDown(KeyCode.C) && equipping == true)
        {
            Transform aux = selectedItem.transform.parent;
            selectedItem.transform.SetParent(equipedItemC.transform.parent);
            equipedItemC.transform.SetParent(aux);
            equipping = false;
            equipedItemC = selectedItem;
        }

        if (Input.GetKeyDown(KeyCode.Q) && equipping == true)
        {
            Transform aux = selectedItem.transform.parent;
            selectedItem.transform.SetParent(equipedItemQ.transform.parent);
            equipedItemQ.transform.SetParent(aux);
            equipping = false;
            equipedItemQ = selectedItem;
        }

        if(basicSword > 1)
        {
            basicSword = 1;
        }

        if(basicSword == 1)
        {
            trainingSword.SetActive(true);
        }
        else
        {
            trainingSword.SetActive(false);
        }
    }

    public void EquipItem()
    {
        equipping = true;
    }

    public void SelectItem( GameObject button )
    {
        selectedItem = button;
    }
}
