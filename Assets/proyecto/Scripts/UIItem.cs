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
    public bool craftingSlot = false;
    private CraftingSlots craftingSlots;
    public bool craftingResultSlot = false;

    private void Awake()
    {
        craftingSlots = FindObjectOfType<CraftingSlots>();
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
        if (craftingSlot)
        {
            craftingSlots.UpdateRecipe();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(this.item != null)
        {
            UICraftResult craftResult = GetComponent<UICraftResult>();
            if (craftResult != null && this.item != null && selectedItem.item == null)
            {
                craftResult.PickItem();
                selectedItem.UpdateItem(this.item);
                craftResult.ClearSlots();
            }
            else if (!craftingResultSlot)
            {
                if (selectedItem.item != null)
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
        }
        else if(selectedItem.item != null && !craftingResultSlot)
        {
            
            UpdateItem(selectedItem.item);
            selectedItem.UpdateItem(null);
        }
    }
}
