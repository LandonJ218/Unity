using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable {

    public string npcName;
    public string[] dialogue;

	public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue, npcName);   // if an NPC object has not had dialogue set up, this will cause an error. (passing empty array)
        Debug.Log("Interacting with NPC.");
    }
}
