using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjMoveDown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.down*25;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "FallThrough")
        {
            Destroy(gameObject);
        }
    }
}
