using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform camTarget;
    public Vector3 camOffset;
    public float camMoveTime;
    public Vector3 camVelocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        //The function to create the movement/following of the camTarget object
        Vector3 camTransform = new Vector3 (camTarget.position.x + camOffset.x, camTarget.position.y + camOffset.y, camOffset.z);
        //SmoothDamp function found via https://www.youtube.com/watch?v=ZBj3LBA2vUY
        //Uses camTarget, camOffset, camMoveTime, and camVelocity to have the camera follow the camTarget with a small bit of move time delay to smooth it.
        transform.position = Vector3.SmoothDamp(transform.position, camTransform, ref camVelocity, camMoveTime);
    }
}
