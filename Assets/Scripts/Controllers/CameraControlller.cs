using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class CameraControlller : Singleton<CameraControlller>
{
    private Vector3 offset;
    private Transform player;

    private void Start() 
    {
        player = PlayerController.Instance.transform;
        offset = transform.position -player.position;   
    }

    private void LateUpdate() 
    {
        transform.position = new Vector3(0, player.position.y + offset.y, player.position.z + offset.z);
    }
}
