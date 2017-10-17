using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equippable : InventoryItem{

    public List<BaseStat> Stats = new List<BaseStat>();
    public string Slot { get; set; }

}
