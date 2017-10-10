using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : Interactable {

    public override void Interact()
    {
        Debug.Log("Interacting with retrieveable item.");
    }
}
