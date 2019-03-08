using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSlots : MonoBehaviour
{
    [SerializeField]
    CraftRecipeDatabase recipeDatabase;
    private List<UIItem> uiItems = new List<UIItem>();
    [SerializeField]
    UIItem craftResultSlot;

    public void UpdateRecipe()
    {
        int[] itemTable = new int[uiItems.Count];
        for (int i = 0; i < uiItems.Count; i++)
        {
            itemTable[i] = uiItems[i].item != null ? uiItems[i].item.id : 0;
        }
        Item itemToCraft = recipeDatabase.CheckRecipe(itemTable);
        UpdateCraftingResultSlot(itemToCraft);
    }

    void UpdateCraftingResultSlot(Item itemToCraft)
    {
        craftResultSlot.UpdateItem(itemToCraft);
    }


    private void Start()
    {
        uiItems = GetComponent<SlotPanel>().uiItems;
        uiItems.ForEach(i => i.craftingSlot = true);
    }
}
