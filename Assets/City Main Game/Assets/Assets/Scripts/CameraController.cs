using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

        [Header("Movement Limits")]
    [Space]
    public bool enableMovementLimits;
    public float moveSpeed;

    public float minXRot;
    public float maxXRot;

    private float curXRot;

    public float minZoom;
    public float maxZoom;
    private Vector3 pos;
    public Vector2 heightLimit;
    public Vector2 lenghtLimit;
    public Vector2 widthLimit;
    private Vector2 zoomLimit;

    public float zoomSpeed;
    public float rotateSpeed;

    private float curZoom;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        curZoom = cam.transform.localPosition.y;
        curXRot = -50;
    }

    void Update()
    {
        curZoom += Input.GetAxis("Mouse ScrollWheel") * -zoomSpeed;
        curZoom = Mathf.Clamp(curZoom, minZoom, maxZoom);

        cam.transform.localPosition = Vector3.up * curZoom;

        Vector3 forward = cam.transform.forward;
        forward.y = 0.0f;
        forward.Normalize();
        Vector3 right = cam.transform.right.normalized;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 dir = forward * moveZ + right * moveX;
        dir.Normalize();

        dir *= moveSpeed * Time.deltaTime;

        transform.position += dir;

                if (enableMovementLimits == true)
        {
            //movement limits
            pos = transform.position;
            pos.y = Mathf.Clamp(pos.y, heightLimit.x, heightLimit.y);
            pos.z = Mathf.Clamp(pos.z, lenghtLimit.x, lenghtLimit.y);
            pos.x = Mathf.Clamp(pos.x, widthLimit.x, widthLimit.y);
            transform.position = pos;
        }
        
    }
}