using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalCounter : MonoBehaviour {

    GameObject portalContainer;

	void Start () {
        portalContainer = GameObject.Find("Portals");
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Text>().text = portalContainer.transform.childCount.ToString();
	}
}
