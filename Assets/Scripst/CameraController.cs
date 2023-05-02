using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{

    public Camera Camera;
    public Transform player;


    [Header("Camera Settings")]
    //[SerializeField] Transform target;
   // [SerializeField] float delay = 1;
    [SerializeField] float distance = 3;
    [SerializeField] float smoothTime = 0.25f;
    

    // Update is called once per frame
    void Start()
    {
        // transform.position = player.transform.position + new Vector3(5, 3, 0);

    }
    Vector3 currentVelocity;
    private void LateUpdate()
    {
        Vector3 target = player.position + (transform.position - player.position.normalized * distance);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref currentVelocity, smoothTime);
        transform.LookAt(player);
    }
}
