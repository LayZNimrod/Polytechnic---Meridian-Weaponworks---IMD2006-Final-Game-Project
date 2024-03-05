using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public PlayerControls playerCont;

    public int moveSpeed;
    public int jumpHeight;
    public float rayCastJumpHight = 0.01f;
    public float rayCastDistFromOrigin = -0.5f;

    private InputAction movement;
    private InputAction jump;
    private InputAction aim;

    public Vector2 weaponPos;
    private Vector2 moveVector;
    private Vector3 playerMove;


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
        aim = playerCont.Player.Look;
        aim.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        jump.Disable();
        aim.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookVector = aim.ReadValue<Vector2>();
        Vector2 mouseWorldVector = Camera.main.ScreenToWorldPoint(lookVector);
        weaponPos = new Vector2 (mouseWorldVector.x - transform.position.x, mouseWorldVector.y - transform.position.y);
        weaponPos.Normalize();
        
    }

    private void FixedUpdate()
    {
        moveVector = movement.ReadValue<Vector2>();
        playerMove = new Vector3(moveVector.x, 0, 0);

        rb = GetComponent<Rigidbody2D>();
        if (moveVector.magnitude == 0)
        {
            Vector2 lerpVel = new Vector2(Mathf.Lerp(rb.velocity.x, 0, Time.deltaTime*2),rb.velocity.y);
            rb.velocity = lerpVel;
        } 
        else
        {
            rb.AddForce(playerMove * moveSpeed * Time.deltaTime);
            playerMove.x = Mathf.Clamp(rb.velocity.x, -10, 10);
            playerMove.y = rb.velocity.y;
            rb.velocity = playerMove;
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (CheckOnGround())
        {
            Vector2 vel = new Vector2(0, jumpHeight);
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
