using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D playerRB;
    private PlayerScript playerScript;
    public Animator animator;
    SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = player.GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerRB.velocity.x > 1.5 || playerRB.velocity.x < -1.5){
            animator.SetFloat("Speed", 1.0f);
        }
        else{
            animator.SetFloat("Speed", 0.0f);
        }
        
        if(playerRB.velocity.x > 0.01){
            spr.flipX = false;
        }
        if(playerRB.velocity.x < -0.01){
            spr.flipX = true;
        }

        if(playerScript.CheckOnGround()){
            animator.SetBool("In_Air", false);
        }
        else{
        animator.SetBool("In_Air", true);
        }
        
    }
}
