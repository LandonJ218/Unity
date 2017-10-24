using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float cameraDistOffset = 50;
    public float minOffset = 10;
    public float maxOffset = 100;
    private Camera mainCamera;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        Vector3 playerInfo = player.transform.transform.position;
        mainCamera.transform.position = new Vector3(playerInfo.x, playerInfo.y + cameraDistOffset, playerInfo.z - cameraDistOffset);
        if (scrollWheel != 0)
        {
            if (scrollWheel > 0)
            {
                if (cameraDistOffset > minOffset)
                {
                    cameraDistOffset -= 10;
                }
            }
            else
            {
                if (cameraDistOffset < maxOffset)
                {
                    cameraDistOffset += 10;
                }
            }
        }
 
    }
}
