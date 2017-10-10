using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {
    NavMeshAgent playerAgent;
    GameObject currentTarget = null;

	// Use this for initialization
	void Start () {
        playerAgent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
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

            if (clickedObject.GetComponent<Interactable>() != null)   //objects that can be interacted with
            {
                if (!(clickedObject.tag == "Inanimate"))   // Don't target certain interactable objects
                {
                    currentTarget = clickedObject;
                }
                clickedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);   // Move to / in range of the object before interacting
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
}
