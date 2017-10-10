using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IArmor
{
    List<BaseStat> Stats { get; set; }
    string ArmorSlot { get; set; }
}
