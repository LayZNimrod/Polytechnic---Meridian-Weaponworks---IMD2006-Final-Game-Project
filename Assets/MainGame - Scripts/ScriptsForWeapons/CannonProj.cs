using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonProj : MonoBehaviour
{
    private const int ballSpeed = 20;
    private float despawnTime;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        despawnTime += Time.deltaTime;
        if (despawnTime > 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            Destroy(gameObject,0.05f);
        }
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage();
        }
    }
    public void OnSpawn(Vector2 velocity, float rotate) 
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = velocity * ballSpeed;
        gameObject.transform.eulerAngles=new Vector3(0,0, rotate);

    }
}
