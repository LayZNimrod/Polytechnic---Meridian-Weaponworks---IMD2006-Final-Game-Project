using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjMoveLeft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.left*25;
    }
}
