using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public float timecount = 0.15f;
    private Vector3 offset = new Vector3(0,0, 10);
    
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, Player.position, timecount);
        transform.position = transform.position - offset;
    }
}
