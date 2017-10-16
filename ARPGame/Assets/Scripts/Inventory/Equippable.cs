using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equippable : InventoryItem{

    public List<BaseStat> Stats { get; set; }
    public string Slot { get; set; }

}
