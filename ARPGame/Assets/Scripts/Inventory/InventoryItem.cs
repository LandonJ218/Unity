using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public string ObjectSlug { get; set; }
    public string ItemName { get; set; }
    public string Description { get; set; }
    public string ActionName { get; set; }
    public bool IsStatModifier { get; set; }

}
