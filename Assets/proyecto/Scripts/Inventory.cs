using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> PlayerItems { get; set; }
    ItemDatabase itemDatabase;

    private void Awake()
    {
        itemDatabase = FindObjectOfType<ItemDatabase>();
    }

    public void AddItem(int id)
    {
        Item itemToAdd = itemDatabase.GetItem(id);
        PlayerItems.Add(itemToAdd);
    }

    public void AddItem(string tittle)
    {
        Item itemToAdd = itemDatabase.GetItem(tittle);
        PlayerItems.Add(itemToAdd);
    }

    public Item CheckForItem(int id)
    {
        return PlayerItems.Find(i=>i.id==id);
    }

    public void RemoveItem(int id)
    {
        Item itemToRemove = CheckForItem(id);
        if (itemToRemove!=null)
        {
            PlayerItems.Remove(itemToRemove);
        }
        else
        {
            Debug.Log("Doesnt exist");
        }
    }
}
