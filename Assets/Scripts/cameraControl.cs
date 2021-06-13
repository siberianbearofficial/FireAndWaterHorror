using UnityEngine;
using System.Collections;
using System;
 
public class cameraControl : MonoBehaviour
{

    [SerializeField] Transform follow;
    [SerializeField] float damping = 0.3f;
    [SerializeField] float lookAheadFactor = 3;
    [SerializeField] float lookAheadReturnSpeed = 0.5f;
    [SerializeField] float lookAheadMoveThreshold = 0.1f;

    private float offsetZ;
    private Vector3 lastTargetPosition;
    private Vector3 currentVelocity;
    private Vector3 lookAheadPos;


    // Use this for initialization
    void Start()
    {
        lastTargetPosition = follow.position;
        offsetZ = transform.position.z - follow.position.z;
    }

    void Update()
    {
        float xMoveDelta = follow.position.x - lastTargetPosition.x;
        bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

        if (updateLookAheadTarget)
        {
            lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
        }
        else
        {
            lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
        }

        Vector3 aheadTargetPos = follow.position + lookAheadPos + Vector3.forward * offsetZ;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);


        transform.position = newPos;
        lastTargetPosition = follow.position;
        if (transform.position.x < 0f)
        {
            transform.position.Set(0f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 58.5f)
        {
            transform.position.Set(58.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.y > 16.5f)
        {
            transform.position.Set(transform.position.x, 16.5f, transform.position.z);
        }
        if (transform.position.y < -6.8f)
        {
            transform.position.Set(transform.position.x, - 6.8f, transform.position.z);
        }
    }
}