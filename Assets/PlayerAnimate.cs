using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    public GameObject Player;
    Animator animator;
    SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Player.GetComponent<Rigidbody2D>().velocity != Vector2.zero){
            animator.SetFloat("Speed", 1.0f);
        }
        else
        animator.SetFloat("Speed", 0.0f);

        if(Player.GetComponent<Rigidbody2D>().velocity.x > 0){
            spr.flipX = false;
        }
        if(Player.GetComponent<Rigidbody2D>().velocity.x < 0){
            spr.flipX = true;
        }
    }
}
