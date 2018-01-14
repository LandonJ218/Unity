using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    NavMeshAgent playerAgent;
    InventoryController inventoryController;

    GameObject currentTarget = null;
    private bool hasInteracted = true;

    
	// Use this for initialization
	void Start () {
        playerAgent = GetComponent<NavMeshAgent>();
        inventoryController = transform.Find("Inventory").GetComponent<InventoryController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (playerAgent != null && !(playerAgent.pathPending))
        {
            // Key to this check is that stoppingDistance is set to 0 when current destination in not interactable; hence those "clicks" won't call Interact()
            if (Vector3.Distance(playerAgent.destination, playerAgent.transform.position) <= playerAgent.stoppingDistance)
            {
                if(!hasInteracted)
                {
                    Interact();
                }
                if(!playerAgent.hasPath || playerAgent.velocity.sqrMagnitude == 0f)
                {
                    PlayerAnimationEventHandler.PlayerIdle();
                }
            }
        }
        GetInput();
    }

    void GetInput()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Mouse click detected.");
            PlayerAnimationEventHandler.PlayerRunning();
            GetInteractionClick();
        }
        if (Input.GetAxis("Fire1") > 0f)
        {
            GetInteractionClickAndHold();
        }
        
    }

    void GetInteractionClick()
    {
        Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit clickInfo;
        if(Physics.Raycast(clickRay, out clickInfo, Mathf.Infinity))
        {
            GameObject clickedObject = clickInfo.collider.gameObject;

            if ((clickedObject.GetComponent<NPC>() != null) || (clickedObject.GetComponent<InventoryItem>() != null) && (clickedObject.transform.root != gameObject.transform.root))   // objects that can be interacted with
            {
                // ToDo:  need to check if an item clicked is a child to other object
                currentTarget = clickedObject;
                MoveToInteraction();   // Move to / in range of the object before interacting
            }
            else
            {
                currentTarget = null;
                playerAgent.stoppingDistance = 0f;
                playerAgent.destination = clickInfo.point;
            }
        }
    }

    void GetInteractionClickAndHold()
    {
        Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit clickInfo;
        if (currentTarget == null)
        {
            if (Physics.Raycast(clickRay, out clickInfo, Mathf.Infinity))
            {            
                playerAgent.destination = clickInfo.point;             
            }
        }
        else
        {
            playerAgent.destination = currentTarget.gameObject.transform.position;
        }
            
    }

    public void Interact()
    {
        if(currentTarget.GetComponent<InventoryItem>() != null)
        {  
            inventoryController.TakeItem(currentTarget.GetComponent<InventoryItem>());   
        }
        if(currentTarget.GetComponent<NPC>() != null)
        {
            DialogueSystem.Instance.AddNewDialogue(currentTarget.GetComponent<NPC>().dialogue, currentTarget.name);
        }
        hasInteracted = true;
    }

    public void MoveToInteraction()
    {
        hasInteracted = false;
        playerAgent.stoppingDistance = 7f;
        playerAgent.destination = currentTarget.transform.position;
    }

    void EnsureLookDirection()
    {
        playerAgent.updateRotation = false;
        Vector3 lookDirection = new Vector3(transform.position.x, playerAgent.transform.position.y, transform.position.z);
        playerAgent.transform.LookAt(lookDirection);
        playerAgent.updateRotation = true;
    }

}
