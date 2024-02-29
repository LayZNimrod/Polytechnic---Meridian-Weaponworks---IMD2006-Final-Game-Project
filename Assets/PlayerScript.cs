using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public PlayerControls playerCont;

    public int moveSpeed;
    public int jumpHight;
    public float rayCastJumpHight = 0.01f;
    public float rayCastDistFromOrigin = -0.5f;


    private InputAction movement;
    private InputAction jump;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        playerCont = new PlayerControls();
    }

    private void OnEnable()
    {
        movement = playerCont.Player.Move;
        movement.Enable();
        jump = playerCont.Player.Jump;
        jump.Enable();
        jump.performed += Jump;
    }

    private void OnDisable()
    {
        movement.Disable();
        jump.Disable();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        Vector2 moveVector = movement.ReadValue<Vector2>();
        Vector3 playermove = new Vector3(moveVector.x, 0, 0);

        rb = GetComponent<Rigidbody2D>();
        if (moveVector.magnitude == 0)
        {
            Vector2 lerpVel = new Vector2(Mathf.Lerp(rb.velocity.x, 0, Time.deltaTime*2),rb.velocity.y);
            rb.velocity = lerpVel;
        } 
        else
        {
            rb.AddForce(playermove * moveSpeed * Time.deltaTime);
            playermove.x = Mathf.Clamp(rb.velocity.x, -10, 10);
            playermove.y = rb.velocity.y;
            rb.velocity = playermove;
        }
    }


    private void Jump(InputAction.CallbackContext context)
    {
        if (CheckOnGround())
        {
            Vector2 vel = new Vector2(0, jumpHight);
            rb.velocity += vel;
        }

    }

    private Boolean CheckOnGround()
    {
        Vector3 temp = new Vector3(0,rayCastDistFromOrigin,0);
        RaycastHit2D hit = Physics2D.Raycast(transform.position+temp, Vector2.down, rayCastJumpHight);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Ground")
            {
                return true;
            }
        }

        return false;
    }
}
