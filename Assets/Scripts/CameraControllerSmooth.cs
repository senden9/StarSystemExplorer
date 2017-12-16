using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerSmooth : MonoBehaviour
{

    public float cameraDistOffset = 10;
    private Camera mainCamera;
    private GameObject player;
    private Vector3 targetPos;
    public float moveSpeed;

    // Use this for initialization
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 playerInfo = player.transform.transform.position;
            targetPos = new Vector3(playerInfo.x, playerInfo.y, playerInfo.z - cameraDistOffset);
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
        else
        {
            player = GameObject.Find("Player");
            if (player == null)
                player = GameObject.Find("Player(Clone)");
        }
    }
}
