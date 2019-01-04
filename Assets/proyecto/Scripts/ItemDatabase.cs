using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> Items { get; set; }

    void Awake()
    {
        BuildItemDatabase();   
    }

    public Item GetItem(int id)
    {
        return Items.Find(item => item.id == id);
    }

    public Item GetItem(string tittle)
    {
        return Items.Find(item => item.title == tittle);
    }

    void BuildItemDatabase()
    {
        Items = new List<Item>()
        {
            new Item(1,"Diamont Sword","A sword made of diamont",
                new Dictionary<string, int>()
                {
                    { "Power",15},
                    { "Defence",15}
                }),
            new Item(2,"Diamont Ore","A shiny diamond",
                new Dictionary<string, int>()
                {
                    { "Value",2500},
                }),
            new Item(3,"Steel Sword","A sword made of Steel",
                new Dictionary<string, int>()
                {
                    { "Power",8},
                    { "Defence",8}
                }),
        };
    }
}
