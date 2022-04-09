using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Transform target;

    public float snappingSpeed = 0.125f;
    public Vector3 offset;

    void Start () 
    {
        player = GameObject.Find("Player");
        target = player.transform;
    }

    void LateUpdate ()
    {
        transform.position = target.position + offset;
    } 
}
