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
    public int jumpHeight;

    public float rayCastLenth = 0.01f;
    public float rayCastXDistFromOrigin = -0.4f;
    public float rayCastYDistFromOrigin = -0.51f;
    public float weaponPushBack = -100f;

    private float velX;
    private float velY;

    private InputAction movement;
    private InputAction jump;
    private InputAction aim;

    private bool isJumping = false;
    private bool move = false;

    private Vector2 moveVector;
    private Vector3 playerMove;
    public Vector2 weaponPos;


    private Rigidbody2D rb;
    public float maxSpeed = 100;
    public float jumpForce;

    public float dragX;
    public float airDragX;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weaponCont = GetComponentInChildren<WeaponScript>();
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
        moveVector = movement.ReadValue<Vector2>().normalized;

        Vector2 lookVector = aim.ReadValue<Vector2>();
        Vector2 mouseWorldVector = Camera.main.ScreenToWorldPoint(lookVector);
        weaponPos = new Vector2(mouseWorldVector.x - transform.position.x, mouseWorldVector.y - transform.position.y);
        weaponPos.Normalize();

        playerMove = new Vector3(moveVector.x, 0, 0);
        velX = rb.velocity.x;
        velY = rb.velocity.y;

        //if (isJumping)

        //{

        //    isJumping = false;
        // }

        if (velX > maxSpeed || velX < -maxSpeed)
        {
            move = false;
        }
        else
        {
            move = true;
        }

        if (velY > jumpHeight || velY < 0)
        {
            isJumping = false;
        }
        
        velY = jumpForce;
        playerMove.y = velY;

        velX = moveVector.x * moveSpeed;
        playerMove.x =velX;
    }

    private void FixedUpdate()
    {
        if (jump.IsInProgress() && isJumping)
        {
            rb.AddForce(Vector2.up * playerMove.y * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
        if (move)
        {
            rb.AddForce(Vector2.right * playerMove.x * Time.fixedDeltaTime, ForceMode2D.Force);
        }

        // adding drag
        if (CheckOnGround() && (moveVector.x < 0.01 && moveVector.x > -0.01))
        {
            rb.AddForce(Vector2.right * -rb.velocity.x * Time.fixedDeltaTime * dragX, ForceMode2D.Force);
        }
        else
        {
            rb.AddForce(Vector2.right * -rb.velocity.x * Time.fixedDeltaTime * airDragX, ForceMode2D.Force);
        }

        
        //rb.AddForce(new Vector2(0, -gravity) * Time.deltaTime);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (CheckOnGround())
        {
            isJumping = true;
        }
    }

    private Boolean CheckOnGround()
    {
        Vector3 temp = new Vector3(0, rayCastYDistFromOrigin, 0);
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

    private void StunPlayer()
    {
        movement.Disable();
        jump.Disable();
        aim.Disable();
    }
    private void UnStunPlayer()
    {
        movement.Enable();
        jump.Enable();
        aim.Enable();
    }
}