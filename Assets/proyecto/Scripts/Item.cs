using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int id;
    public string title;
    public string description;
    public Sprite icon;
    public Dictionary<string,int> stats = new Dictionary<string, int>();

    public Item(int id, string title, string description, Dictionary<string, int> stats)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.stats = stats;
        this.icon = Resources.Load<Sprite>("Item/"+title);
    }

    /**
     * Esto copia un item
     * 
     */
    public void CopyItem(Item item)
    {
        this.id = item.id;
        this.title = item.title;
        this.description = item.description;
        this.icon = item.icon;
        this.stats = item.stats;
    }
}
