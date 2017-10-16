using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    public static ItemDatabase Instance { get; set; }
    private List<InventoryItem> Items { get; set; }

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        BuildDatabase();

    }

    private void BuildDatabase()
    {
        //todo: Items need to be filled here
        //one dev series had items stored on a JSON file and would read in and deserialize here into Items: https://www.youtube.com/watch?v=S5fRFS9lNpc
    }

    public InventoryItem GetItem(string itemSlug)
    {
        foreach(InventoryItem item in Items)
        {
            if(item.ObjectSlug == itemSlug)
            {
                return item;
            }
        }
        Debug.LogWarning("Couldn't find item: " + itemSlug);
        return null;
    }
}
