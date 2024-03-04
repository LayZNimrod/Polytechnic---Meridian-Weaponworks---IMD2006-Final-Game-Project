using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform camTarget;
    public Vector3 camOffset;
    public float camMoveTime;
    public Vector3 camVelocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camTransform = new Vector3 (camTarget.position.x + camOffset.x, camTarget.position.y + camOffset.y, camOffset.z);
        //SmoothDamp function found via https://www.youtube.com/watch?v=ZBj3LBA2vUY
        transform.position = Vector3.SmoothDamp(transform.position, camTransform, ref camVelocity, camMoveTime);
    }
}
