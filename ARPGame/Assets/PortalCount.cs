using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalCount : MonoBehaviour {

    private Text UIPortalCount;
    private int portalCount;

	void Start () {
        UIPortalCount = gameObject.GetComponent<Text>();
        UIEventHandler.OnPortalsSpawned += PortalsSpawned;
        UIEventHandler.OnPortalDestroyed += PortalDestroyed;
    }

    private void PortalsSpawned()
    {
        portalCount = GameObject.Find("Portals").transform.childCount;
        UIPortalCount.text = portalCount.ToString();
    }

    private void PortalDestroyed()
    {
        portalCount--;
        UIPortalCount.text = portalCount.ToString();
    }
}
