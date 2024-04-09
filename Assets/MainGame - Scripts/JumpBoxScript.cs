using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoxScript : MonoBehaviour
{
    public bool onGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        if (collision != null)
        {
            if (tag == "Ground" || tag == "FallThrough")
            {
                onGround = true;
            }
        }
    }
    private void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        if (collision != null)
        {
            if (tag == "Ground" || tag == "FallThrough")
            {
                onGround = false;
            }
        }
    }
}
