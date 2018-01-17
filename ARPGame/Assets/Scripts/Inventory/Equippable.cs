using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equippable : InventoryItem{

    public List<BaseStat> Stats = new List<BaseStat>();

    public List<EquippableModel> Models;
    public string Slot;

    private void Start()
    {
        //Name and stats would be generated procedurally with armor and weapons if development reached that milestone
        ItemName = name;
        BaseStat baseStat = new BaseStat("STR", 5);
        Stats.Add(baseStat);

        int childCount = transform.childCount;
        for(int i = 0; i < childCount; i++)
        {
            if(transform.GetChild(i).GetComponent<EquippableModel>() != null)
            {
                Models.Add(transform.GetChild(i).GetComponent<EquippableModel>());
            }
        }
    }


}
