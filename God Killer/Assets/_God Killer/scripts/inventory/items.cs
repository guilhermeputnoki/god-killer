using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : MonoBehaviour
{
    public GameObject itemName;
    public GameObject itemDescription;
    public GameObject itemEquip;

    public void ShowInformations()
    {
        itemName.SetActive(true);
        itemDescription.SetActive(true);
        itemEquip.SetActive(true);
    }

    public void HideInformations()
    {
        itemName.SetActive(false);
        itemDescription.SetActive(false);
        itemEquip.SetActive(false);
    }
}
