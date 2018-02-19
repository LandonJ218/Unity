using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalCount : MonoBehaviour {

    private Text UIPortalCount;

	void Start ()
    {
        UIPortalCount = gameObject.GetComponent<Text>();
        UIEventHandler.OnPortalSpawned += PortalSpawned;
        UIEventHandler.OnPortalDestroyed += PortalDestroyed;
        UIEventHandler.OnAllPortalsDestroyed += LastPortalDestroyed;
        UIEventHandler.OnEnemyKilled += EnemyKilled;
    }

    private void PortalSpawned()
    {
        UIPortalCount.text = GameController.GetPortalCount().ToString();
    }

    private void PortalDestroyed()
    {
        if(GameController.GetPortalCount() > 0)
        {
            UIPortalCount.text = GameController.GetPortalCount().ToString();
        }
    }

    private void LastPortalDestroyed()
    {
        UIPortalCount.text = ("All portals have been destroyed! Eliminate the remaining " + GameController.GetEnemyCount() + " enemies from this world!");
        UIPortalCount.fontSize = 24;
        UIPortalCount.color = new Color32(0xFF, 0x85, 0x85, 0xFF);
    }

    private void EnemyKilled()
    {
        UIPortalCount.text = ("All portals have been destroyed! Eliminate the remaining " + GameController.GetEnemyCount() + " enemies from this world!");
    }
}
