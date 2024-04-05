using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance;
    public PlayerControls playerCont;

    public WeaponScript weaponCont;

    public float moveSpeed;

    public float rayCastLenth = 0.01f;
    public float rayCastXDistFromOrigin = -0.4f;
    public float rayCastYDistFromOrigin = -0.51f;
    public float weaponPushBack = -100f;

    public float velX;
    private float velY;

    private InputAction movement;
    private InputAction jump;
    private InputAction aim;
    private InputAction fire;

    private bool isJumping = false;
    private bool move = false;
    private bool onGround = false;

    private Vector2 moveVector;
    private Vector3 playerMove;
    public Vector2 weaponPos;


    private Rigidbody2D rb;
    public float maxSpeed = 100;
    public float jumpForce;

    public float dragX;
    public float airDragX;
    private float coyoteTime;

    bool CanMove = true;
    private bool weaponFiredInAir = false;

    public void ToggleMove()
    {
        CanMove = !CanMove;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weaponCont = GetComponentInChildren<WeaponScript>();
        UnStunPlayer();
    }

    private void Awake()
    {
        Instance = this;
        playerCont = new PlayerControls();
    }

    private void OnEnable()
    {
        movement = playerCont.Player.Move;
        movement.Enable();
        jump = playerCont.Player.Jump;
        jump.Enable();
        jump.performed += Jump;
        jump.canceled += JumpCancelled;
        aim = playerCont.Player.Look;
        aim.Enable();
        fire = playerCont.Player.Fire;
        fire.performed += Fire;
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
        // Vector3 temp = new Vector3(rayCastXDistFromOrigin, rayCastYDistFromOrigin, 0);
        // Debug.DrawRay(transform.position + temp, Vector2.right * rayCastLenth, Color.green);

        onGround = CheckOnGround();
        if (onGround)
        {
            //jumpCancelled = false;
            weaponFiredInAir = false;
            coyoteTime = 0;
        } else
        {
            coyoteTime += Time.deltaTime;
        }

        if (CanMove)
        {
            moveVector = movement.ReadValue<Vector2>().normalized;

            Vector2 lookVector = aim.ReadValue<Vector2>();
            Vector2 mouseWorldVector = Camera.main.ScreenToWorldPoint(lookVector);
            weaponPos = new Vector2(mouseWorldVector.x - transform.position.x, mouseWorldVector.y - transform.position.y);
            weaponPos.Normalize();

            playerMove = new Vector3(moveVector.x, 0, 0);
            velX = rb.velocity.x;
            velY = rb.velocity.y;

            if (velX > maxSpeed || velX < -maxSpeed)
            {
                move = false;
            }
            else
            {
                move = true;
            }

            if (velY < 0 || weaponFiredInAir)
            {
                isJumping = false;
            }

            velY = jumpForce;
            playerMove.y = velY;

            velX = moveVector.x * moveSpeed;
            playerMove.x = velX;
        }


    }

    private void FixedUpdate()
    {
        //if (jump.IsInProgress() && isJumping && jumpCancelled==false)
        //{
        //    rb.AddForce(Vector2.up * playerMove.y * Time.fixedDeltaTime, ForceMode2D.Force);
        //}

        if (move && CanMove)
        {
            rb.AddForce(Vector2.right * playerMove.x * Time.fixedDeltaTime, ForceMode2D.Force);
        }

        // adding drag
        if (onGround && (moveVector.x < 0.01 && moveVector.x > -0.01))
        {
            rb.AddForce(Vector2.right * -rb.velocity.x * Time.fixedDeltaTime * dragX, ForceMode2D.Force);
        }
        else
        {
            rb.AddForce(Vector2.right * -rb.velocity.x * Time.fixedDeltaTime * airDragX, ForceMode2D.Force);
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (onGround || coyoteTime < 0.05)
        {
            isJumping = true;
            rb.AddForce(Vector2.up * playerMove.y, ForceMode2D.Force);
        }
    }

    private void JumpCancelled(InputAction.CallbackContext context)
    {
        //jumpCancelled = true;
        if (isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x,0f);
            rb.AddForce(Vector2.up * 0.5f, ForceMode2D.Force);
        }
    }

    public Boolean CheckOnGround()
    {
        Vector3 temp = new Vector3(rayCastXDistFromOrigin, rayCastYDistFromOrigin, 0);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + temp, Vector2.right, rayCastLenth);


        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Ground" || hit.collider.gameObject.tag == "FallThrough")
            {
                return true;
            }
        }
        return false;
    }

    public void StunPlayer()
    {
        movement.Disable();
        jump.Disable();
        fire.Disable();
    }
    public void UnStunPlayer()
    {
        movement.Enable();
        jump.Enable();
        fire.Enable();
    }

    private void Fire(InputAction.CallbackContext context)
    {
        weaponFiredInAir = true;
    }

}