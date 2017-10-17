using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    NavMeshAgent playerAgent;
    GameObject currentTarget = null;
    private bool hasInteracted = true;


    
	// Use this for initialization
	void Start () {
        playerAgent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        if (playerAgent != null && !(playerAgent.pathPending))
        {
            // Key to this check is that stoppingDistance is set to 0 when current destination in not interactable; hence those "clicks" won't call Interact()
            if (!hasInteracted && playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                Interact();
            }
        }
        GetInput();
    }

    void GetInput()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Mouse click detected.");
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

            if ((clickedObject.GetComponent<NPC>() != null) || (clickedObject.GetComponent<Equippable>() != null))   // objects that can be interacted with
            {
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
            GetComponent<InventoryController>().TakeItem(currentTarget.GetComponent<Equippable>());
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
