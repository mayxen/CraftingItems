using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerDownHandler
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

    public void OnPointerDown(PointerEventData eventData)
    {
        if(this.item != null)
        {
            if(selectedItem.item != null)
            {
                Item clone = new Item(selectedItem.item);
                selectedItem.UpdateItem(this.item);
                UpdateItem(clone);
            }
            else
            {
                selectedItem.UpdateItem(this.item);
                UpdateItem(null);
            }
        }
        else if(selectedItem.item != null)
        {
            
            UpdateItem(selectedItem.item);
            selectedItem.UpdateItem(null);
        }
    }
}
