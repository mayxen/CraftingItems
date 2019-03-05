using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public Item item;
    Image icon;
    UIItem selectedItem;

    private void Awake()
    {
        icon = GetComponent<Image>();
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
        UpdateItem(null);
    }

    public void UpdateItem(Item item)
    {
        this.item = item;
        if (this.item != null)
        {
            icon.color = Color.white;
            icon.sprite = item.icon;
        }
        else
        {
            icon.color = Color.clear;
        }
    }
}
