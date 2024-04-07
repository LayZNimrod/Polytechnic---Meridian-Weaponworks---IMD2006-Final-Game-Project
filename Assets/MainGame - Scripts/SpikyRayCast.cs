using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikyRayCast : MonoBehaviour
{
    public float rayCastLenth;
    public RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.Raycast(transform.position, transform.forward, rayCastLenth);
        Debug.DrawRay(transform.position, transform.forward * rayCastLenth, Color.green);
    }
}
