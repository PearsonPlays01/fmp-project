using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    GameObject playerTarget;
    Vector3 offset;

    public float leftLimit, rightlimit, topLimit, bottomLimit;

    void Start()
    {
        playerTarget = GameObject.FindWithTag("Player"); 
        offset = transform.position - playerTarget.transform.position;
    } 

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerTarget.transform.position + offset, 0.01f);

        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, leftLimit, rightlimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
        );
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightlimit, topLimit));
        Gizmos.DrawLine(new Vector2(rightlimit, topLimit), new Vector2(rightlimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightlimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));
    }
}
